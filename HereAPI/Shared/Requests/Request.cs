﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HereAPI.Shared.Requests
{
    /// <summary>
    /// Generic JSON requests helper class with support for JsonSerializerSettings
    /// </summary>
    public abstract class Request
    {
        private string _url;

        public string URL
        {
            get
            {
                _url = SetUrl();
                return _url;
            }
        }

        private JsonSerializerSettings _jsonSettings;

        private JsonSerializerSettings JsonSettings
        {
            get
            {
                _jsonSettings = new JsonSerializerSettings { Converters = SetJsonConverters() };
                return _jsonSettings;
            }
        }

        public Request()
        {
        }

        /// <summary>
        /// Each subclass of Request must provide their own Json Type Converters
        /// </summary>
        /// <returns></returns>
        protected abstract List<JsonConverter> SetJsonConverters();

        protected abstract string SetUrl();

        protected async Task<T> GetAsync<T>()
        {
            var uri = new Uri(URL);
            var json = await HereAPISession.Instance.HttpClient.GetStringAsync(uri).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(json, JsonSettings);
            return result;
        }

        protected T Get<T>()
        {
            return GetAsync<T>().GetAwaiter().GetResult();
        }
    }
}