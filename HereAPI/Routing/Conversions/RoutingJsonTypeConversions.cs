using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HereAPI.Routing.Conversions
{
    public class RoutingJsonTypeConversions : ITypeConversions
    {
        public Dictionary<Type, Func<object, object>> GetConversions()
        {
            return new Dictionary<Type, Func<object, object>>
                        {
                            { typeof(LinkId), (s) => ConvertLinkId((string) s) },
                            { typeof(RouteFeature), (s) => ConvertRouteFeature((string) s) },
                            { typeof(Maneuver), (d) => ConvertAbstractObject((dynamic) d) },
                            { typeof(Link), (d) => ConvertAbstractObject((dynamic) d) },
                            { typeof(RouteSummary), (d) => ConvertAbstractObject((dynamic) d) },
                        };
        }

        // TODO Add test for this...
        public object ConvertAbstractObject(dynamic d)
        {
            JToken token = d.t;
            JsonSerializer serializer = d.s;

            try
            {
                string _type = token.Value<string>("_type");

                if (_type == "PublicTransportManeuverType") return token.ToObject<PublicTransportManeuver>(serializer);
                if (_type == "PrivateTransportManeuverType") return token.ToObject<PrivateTransportManeuver>(serializer);

                if (_type == "PublicTransportLinkType") return token.ToObject<PublicTransportLink>(serializer);
                if (_type == "PrivateTransportLinkType") return token.ToObject<PrivateTransportLink>(serializer);

                if (_type == "RouteSummaryType") return token.ToObject<PrivateTransportRouteSummary>(serializer);
                if (_type == "PublicTransportRouteSummaryType") return token.ToObject<PublicTransportRouteSummary>(serializer);

                return null;
            }
            catch
            {
                return null;
            }
        }

        public LinkId ConvertLinkId(string s)
        {
            try
            {
                if (LinkId.DIRECTION_SYMBOLS.Contains(s[0]))
                {
                    return new LinkId(int.Parse(s.Substring(1)), EnumHelper.GetValue<LinkId.LinkDirection>(s.Substring(0, 1)));
                }
                else
                {
                    return new LinkId(int.Parse(s), LinkId.LinkDirection.Any);
                }
            }
            catch
            {
                return null;
            }
        }

        public RouteFeature ConvertRouteFeature(string s)
        {
            try
            {
                RouteFeatureType type = EnumHelper.GetValue<RouteFeatureType>(s.Split(':')[0]);
                RouteFeatureWeightType weight = EnumHelper.GetValue<RouteFeatureWeightType>(s.Split(':')[1]);

                return new RouteFeature(type, weight);
            }
            catch
            {
                return null;
            }
        }
    }
}