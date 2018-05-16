using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HereAPI.Shared.Json
{
    class JsonTypesConverter : JsonConverter
    {
        private Dictionary<Type, Func<string, object>> _conversions;

        public JsonTypesConverter(Dictionary<Type, Func<string, object>> conversions)
        {
            _conversions = conversions;
        }

        public override bool CanConvert(Type objectType)
        {
            return _conversions.Keys.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return _conversions[objectType](reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


    }
}
