using HereAPI.Shared.Conversions;
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

        private List<string> ValidationErrors = new List<string>();

        private string BaseUrl = "";
        private string UrlAttributes = "";

        protected ITypeConversions Conversions { get; set; }

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
            BaseUrl = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppId), HereAPI.Instance.AppId);
            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppCode), HereAPI.Instance.AppCode);
        }

        protected void AddAttribute(string attribute, string value)
        {
            UrlAttributes += $"&{attribute}={value}";
        }

        protected void AddIRequestAttribute(IRequestAttribute attribute)
        {
            UrlAttributes += $"&{attribute.GetAttributeName()}={attribute.GetAttributeValue()}";
        }

        /// <summary>
        /// Each request should implement a validation of the value of it's attributes where necessary,
        /// and validate the compatibility of each attribute with the rest.
        /// </summary>
        protected void ValidatetAttributes() {
            ValidationErrors.AddRange(AttributeValidator.Validate(this));
        }

        public bool IsValid()
        {

        }

        public string[] GetValidationErrors

        /// <summary>
        /// Each request must implement this method where AddAttribute() or AddIRequestAttribute() are called 
        /// for each non null Property
        /// </summary>
        protected abstract void AddSpecifiedAttributes();

        /// <summary>
        /// Each service (Routing, Geocoding, etc) must provide their own type conversions.
        /// Conversions for shared types can live in SharedJsonTypeConversions.cs
        /// </summary>
        protected abstract void SetConversions();

        public string GetCompiledUrl()
        {
            ValidatetAttributes();
            AddSpecifiedAttributes();
            return BaseUrl + UrlAttributes;
        }

        protected async Task<T> GetAsync<T>() where T : class
        {
            string finalUrl = GetCompiledUrl();

            var uri = new Uri(BaseUrl + UrlAttributes);
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

            var uri = new Uri(BaseUrl + UrlAttributes);
            return await HereAPI.Instance.HttpClient.GetStreamAsync(uri).ConfigureAwait(false);
        }

        protected Stream GetStream()
        {
            return GetStreamAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Convert some of the json response items to a more complex class
        /// </summary>
        /// <returns></returns>
        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            return  new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> {
                    new JsonTypesConverter(new SharedJsonTypeConversions().GetConversions()), // Conversions for shared types
                    new JsonTypesConverter(Conversions.GetConversions()) // Conversions for the service making this request
                }
            };
        }
        

    }
}
