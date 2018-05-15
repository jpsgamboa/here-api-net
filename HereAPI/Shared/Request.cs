using HereAPI.Shared.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HereAPI.Shared
{
    public abstract class Request
    {
        JsonSerializerSettings settings = null;
        //JsonSerializerSettings settings = new JsonSerializerSettings
        //{
        //    Converters = new List<JsonConverter> { new JsonEnumTypeConverter(), new JsonLocationConverter() }
        //};

        private string baseUrl { get; set; } = "";
        private string urlParameters { get; set; } = "";

        public Request(string service, string path, string resource)
        {
            baseUrl = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddParameter(PropertyHelper.GetDescription(() => HereAPI.Instance.AppId), HereAPI.Instance.AppId);
            AddParameter(PropertyHelper.GetDescription(() => HereAPI.Instance.AppCode), HereAPI.Instance.AppCode);

            //url = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?" +
            //    $"app_id={HereAPI.Instance.AppId}&app_code={HereAPI.Instance.AppCode}";

        }

        protected void AddParameter(string parameter, string value)
        {
            urlParameters += $"&{parameter}={value}";
        }

        protected void AddIUrlParameter(IUrlParameter parameter)
        {
            urlParameters += $"&{parameter.GetParameterName()}={parameter.GetParameterValue()}";
        }

        protected abstract void ValidateParameters();
        protected abstract void AddSpecifiedParameters();
        
        protected async Task<T> GetAsync<T>() where T : class
        {
            string finalUrl = GetFinalUrl();

            var uri = new Uri(baseUrl + urlParameters);
            var json = await HereAPI.Instance.HttpClient.GetStringAsync(uri).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(json, settings);
            //var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        protected T Get<T>() where T : class
        {
            return GetAsync<T>().GetAwaiter().GetResult();
        }

        protected async Task<Stream> GetStreamAsync()
        {
            string finalUrl = GetFinalUrl();

            var uri = new Uri(baseUrl + urlParameters);
            return await HereAPI.Instance.HttpClient.GetStreamAsync(uri).ConfigureAwait(false);
        }

        protected Stream GetStream()
        {
            return GetStreamAsync().GetAwaiter().GetResult();
        }

        public string GetFinalUrl()
        {
            ValidateParameters();
            AddSpecifiedParameters();
            return baseUrl + urlParameters;
        }

    }
}
