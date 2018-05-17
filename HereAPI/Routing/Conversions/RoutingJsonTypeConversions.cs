using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
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
                            { typeof(Maneuver), (t) => ConvertAbstractObject((JToken) t) },
                            { typeof(Link), (t) => ConvertAbstractObject((JToken) t) },
                            { typeof(RouteSummary), (t) => ConvertAbstractObject((JToken) t) },
                        };
        }

        // TODO Must test this...
        public object ConvertAbstractObject(JToken token)
        {
            try
            {
                string _type = token.Value<string>("_type");

                if (_type == "PublicTransportManeuverType") return token.ToObject<PublicTransportManeuver>();
                if (_type == "PrivateTransportManeuverType") return token.ToObject<PrivateTransportManeuver>();

                if (_type == "PublicTransportLinkType") return token.ToObject<PublicTransportLink>();
                if (_type == "PrivateTransportLinkType") return token.ToObject<PrivateTransportLink>();

                if (_type == "RouteSummaryType") return token.ToObject<RouteSummary>();
                if (_type == "PublicTransportRouteSummaryType") return token.ToObject<PublicTransportRouteSummary>();

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
