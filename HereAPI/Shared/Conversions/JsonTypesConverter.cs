using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;

namespace HereAPI.Shared.Conversions
{
    public class JsonTypesConverter : JsonConverter
    {
        private Dictionary<Type, Func<object, object>> _conversions;

        public JsonTypesConverter(Dictionary<Type, Func<object, object>> conversions)
        {
            _conversions = conversions;
        }

        public override bool CanConvert(Type objectType)
        {
            return _conversions.Keys.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                JToken token = JToken.Load(reader);
                var items = token.ToObject<string[]>();
                return _conversions[objectType](items);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                JToken token = JToken.Load(reader);
                string _type = token.Value<string>("_type");

                return _conversions[objectType](token);
            }
            else
            {
                return _conversions[objectType](reader.Value.ToString());
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
    }
}
