using HereAPI.Routing.Conversions;
using HereAPI.Shared.Json;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HereAPI.Shared.Requests
{
    public abstract class Request
    {

        private string baseUrl { get; set; } = "";
        private string urlAttributes { get; set; } = "";

        private static JsonSerializerSettings _serializerSettings;

        /// <summary>
        /// Creates the base URL for the api service, appends the App ID and App Code defined in HereAPI.Register()
        /// and handles the option to run in the production server of the custumer integration test (cit) server.
        /// "route", "routing/7.2", "calculateroute"
        /// </summary>
        /// <param name="service">The service API. Example: route, places, geocoder </param>
        /// <param name="path">The path, including the API version. Example: routing/7.2, places/v1, 6.2 </param>
        /// <param name="resource">The </param>
        public Request(string service, string path, string resource)
        {
            baseUrl = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppId), HereAPI.Instance.AppId);
            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppCode), HereAPI.Instance.AppCode);
        }

        protected void AddAttribute(string attribute, string value)
        {
            urlAttributes += $"&{attribute}={value}";
        }

        protected void AddIRequestAttribute(IRequestAttribute attribute)
        {
            urlAttributes += $"&{attribute.GetAttributeName()}={attribute.GetAttributeValue()}";
        }

        /// <summary>
        /// Each request should implement a validation of the value of it's attributes where necessary,
        /// and validate the compatibility of each attribute with the rest.
        /// </summary>
        protected abstract void ValidateRequestAttributes();

        /// <summary>
        /// Each request must implement this method where AddAttribute() or AddIRequestAttribute() are called 
        /// for each non null Property
        /// </summary>
        protected abstract void AddSpecifiedAttributes();


        public string GetCompiledUrl()
        {
            ValidateRequestAttributes();
            AddSpecifiedAttributes();
            return baseUrl + urlAttributes;
        }

        protected async Task<T> GetAsync<T>() where T : class
        {
            string finalUrl = GetCompiledUrl();

            var uri = new Uri(baseUrl + urlAttributes);
            var json = await HereAPI.Instance.HttpClient.GetStringAsync(uri).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(json, GetJsonSerializerSettings());
            return result;
        }

        protected T Get<T>() where T : class
        {
            return GetAsync<T>().GetAwaiter().GetResult();
        }

        protected async Task<Stream> GetStreamAsync()
        {
            string finalUrl = GetCompiledUrl();

            var uri = new Uri(baseUrl + urlAttributes);
            return await HereAPI.Instance.HttpClient.GetStreamAsync(uri).ConfigureAwait(false);
        }

        protected Stream GetStream()
        {
            return GetStreamAsync().GetAwaiter().GetResult();
        }

        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            if (_serializerSettings == null)
            {
                _serializerSettings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> {
                        new JsonTypesConverter(RoutingJsonTypeConversions.CONVERSIONS),

                    }
                };
            }
            return _serializerSettings;
        }
        

    }
}
