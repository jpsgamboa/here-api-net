using HereAPI.Shared.Requests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HereAPI.Shared.Conversions
{
    /// <summary> Provides a way to convert the JSON response into the desired objects.<para/> Example:<para/>
    /// - Parse the Shape attribute of the JSON response (a string array) into a <see
    ///   cref="GeoPolyline"/> object <para/>
    /// - Parse enum types (a string in the JSON response) into the appropriate <see cref="Enum"/>
    ///   object <para/> <para/>
    ///
    /// The values are converted using functions defined in classes implementing <see
    /// cref="ITypeConversions"/>. <para/> The class <see cref="SharedJsonTypeConversions"/> defines
    /// conversions for types shared across multiple services (such as Routing, Geocoding - both use
    /// <see cref="GeoCoordinate"/> for example). </para> <para/>
    ///
    /// Each service then implements it's own class implementing <see
    /// cref="ITypeConversions"/>.<para/> For example, the Routing service has the class <see
    /// cref="RoutingJsonTypeConversions"/> which defines conversions specific for the routing
    /// service.<para/> <para/>
    ///
    /// The <see cref="ITypeConversions"/> interface ensures that the conversion are loaded into a
    /// <see cref="Dictionary{Type, Func{object, object}}"/> which key is the type of the object to
    /// convert (<see cref="Enum"/>, <see cref="GeoCoordinate"/>, etc.) and the value is a <see
    /// cref="Func{}"/> that points to the function to run.<para/>
    ///
    /// The idea behind separating the convertions between the service was the fear that loading too
    /// many conversions into the <see cref="JsonConverter"/> could slow things down.
    ///
    /// </summary>
    public class JsonTypesConverter : JsonConverter
    {
        private Dictionary<Type, Func<object, object>> _conversions;

        public JsonTypesConverter(Dictionary<Type, Func<object, object>> conversions)
        {
            _conversions = conversions;
        }

        /// <summary>
        /// Checks if the object type to convert is one of the types defined in the conversions
        /// dictionary. (Except for Enums, which must always be converted)
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (EnumHelper.IsEnum(objectType)) return true;

            return _conversions.Keys.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Case of coordinate arrays. Must be parsed to a string array
            if (reader.TokenType == JsonToken.StartArray)
            {
                JToken token = JToken.Load(reader);
                var items = token.ToObject<string[]>();
                return _conversions[objectType](items);
            }

            // Case of derived objects such as those derived from Maneuver that must be routed to the
            // desired object using the _type attribute in the json response
            else if (reader.TokenType == JsonToken.StartObject)
            {
                JToken token = JToken.Load(reader);
                string _type = token.Value<string>("_type");

                return _conversions[objectType](new { s = serializer, t = token });
            }

            // Case of enums. Most of the enum types are nullable by choice (so that they are null
            // when not present in the JSON response). To deal with the nullability factor, some
            // extra steps have to be taken to ensure the conversion works. See the class EnumHelper
            // for more info.
            else if (EnumHelper.IsEnum(objectType))
            {
                try
                {
                    var value = EnumHelper.GetValue(reader.Value.ToString(), EnumHelper.GetEnumType(objectType));
                    var result = value != null ? Enum.ToObject(EnumHelper.GetEnumType(objectType), value) : null;
                    return result;
                }
                catch
                {
                    return null;
                }
            }

            // Default case - the value is parsed into a string
            else
            {
                return _conversions[objectType](reader.Value.ToString());
            }
        }

        /// <summary>
        /// Not implemente since no JSON is written
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}