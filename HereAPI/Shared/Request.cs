using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HereAPI.Shared
{
    public abstract class Request : IDisposable
    {

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new JsonEnumTypeConverter(), new JsonLocationConverter() }
        };


        private HttpClient httpClient;

        private string url { get; set; }

        public Request(string service, string path, string resource)
        {
            url = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?" +
                $"app_id={HereAPI.Instance.AppId}&app_code={HereAPI.Instance.AppCode}";

            httpClient = new HttpClient();
        }

        protected void AddParameter(string parameter, string value)
        {
            url += $"&{parameter}={value}";
        }

        protected abstract void ValidateParameters();
        
        protected async Task<T> GetAsync<T>() where T : class
        {
            var uri = new Uri(url);

            var json = await httpClient.GetStringAsync(uri).ConfigureAwait(false);

            var result = JsonConvert.DeserializeObject<T>(json, settings);

            return result;
        }

        protected T Get<T>() where T : class
        {
            return GetAsync<T>().GetAwaiter().GetResult();
        }

        protected async Task<Stream> GetStreamAsync()
        {
            var uri = new Uri(url);

            return await httpClient.GetStreamAsync(uri).ConfigureAwait(false);
        }

        protected Stream GetStream()
        {
            return GetStreamAsync().GetAwaiter().GetResult();
        }

        protected void Dispose()
        {
            if (httpClient != null) httpClient.Dispose();
        }
    }
}
