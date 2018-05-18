using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Conversions
{
    public class SharedJsonTypeConversions : ITypeConversions
    {

        public Dictionary<Type, Func<object, object>> GetConversions()
        {
            return new Dictionary<Type, Func<object, object>>
                        {
                            //{ typeof(Enum), (s) => ConvertEnumType<Enum>((string) s) },
                            { typeof(GeoPolyline), (s) => ConvertShape((string[]) s) },
                            { typeof(KeyValuePair), (s) => ConvertKeyValuePair((string) s) },
                        };
        }

        //public T ConvertEnumType<T>(string s)
        //{
        //    try
        //    {
        //        return EnumHelper.GetValue<T>(s);
        //    }
        //    catch
        //    {
        //        return default(T);
        //    }
        //}

        public GeoPolyline ConvertShape(string[] s)
        {
            try
            {
                var coordinates = new List<GeoCoordinate>();

                foreach (string c in s)
                {
                    var parts = c.Split(',');

                    bool hasAltitude = parts.Length > 2;

                    double lat = double.Parse(parts[0]);
                    double lon = double.Parse(parts[1]);
                    double? alt = null;

                    if (hasAltitude) alt = double.Parse(parts[2]);

                    coordinates.Add(new GeoCoordinate(lat, lon, alt));
                }

                return new GeoPolyline(coordinates.ToArray());
            }
            catch
            {
                return null;
            }
        }

        // TODO Never seen as example of this in a responde. Not sure if this conversion if correct..
        public KeyValuePair ConvertKeyValuePair(string s)
        {
            try
            {
                var parts = s.Replace("\",\"", "|").Split('|');
                return new KeyValuePair(parts[0], parts[1]);                
            }
            catch
            {
                return null;
            }
        }


    }
}
