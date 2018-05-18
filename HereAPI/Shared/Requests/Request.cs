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
    /// <summary>
    /// Generic JSON requests helper class with support for JsonSerializerSettings
    /// </summary>
    public abstract class Request
    {
        private string _url;
        public string URL { get {
                _url = SetUrl();
                return _url;
            }}

        private JsonSerializerSettings _jsonSettings;
        private JsonSerializerSettings JsonSettings { get {
                _jsonSettings = new JsonSerializerSettings { Converters = SetJsonConverters() };
                return _jsonSettings;
            }}


        public Request() { }

        /// <summary>
        /// Each subclass of Request must provide their own Json Type Converters
        /// </summary>
        /// <returns></returns>
        protected abstract List<JsonConverter> SetJsonConverters();
        
        protected abstract string SetUrl();

        protected async Task<T> GetAsync<T>() 
        {
            var uri = new Uri(URL);
            var json = await HereAPI.Instance.HttpClient.GetStringAsync(uri).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(json, JsonSettings);
            return result;
        }


        protected T Get<T>()
        {

            var uri = new Uri(URL);
            var json = HereAPI.Instance.HttpClient.GetStringAsync(uri).GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<T>(json, JsonSettings);
            return result;

            //return GetAsync<T>().GetAwaiter().GetResult();
        }

        //protected T Get<T>()
        //{
        //    return GetAsync<T>().GetAwaiter().GetResult();
        //}

    }
}
