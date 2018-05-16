using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using System;
using System.ComponentModel;
using System.Linq;

namespace HereAPI.Routing.TypesRequest
{
    public class RoutingMode : IRequestAttribute
    {

        public RoutingType Type { get; set; }
        public TransportModeType Transport { get; set; }
        public TrafficModeType? Traffic { get; set; }
        public RouteFeature[] Features { get; set; }

        /// <summary>
        /// The RoutingMode specifies how the route is calculated. <para/>
        /// Parameter representation:<para/>
        /// RoutingMode = Type + [TransportModes] + [TrafficMode] + [Feature]<para/>
        /// https://developer.here.com/documentation/routing/topics/resource-param-type-routing-mode.html
        /// </summary>
        /// <param name="routingType"></param>
        /// <param name="transportMode"></param>
        /// <param name="trafficMode"></param>
        /// <param name="routeFeatures"></param>
        /// 
        public RoutingMode(RoutingType routingType, TransportModeType transportMode, TrafficModeType? trafficMode = null, params RouteFeature[] routeFeatures)
        {
            Type = routingType;
            Transport = transportMode;
            Traffic = trafficMode;
            Features = routeFeatures;

            if (Transport == TransportModeType.Truck || Transport == TransportModeType.PublicTransport || Transport == TransportModeType.PublicTransportTimeTable)
            {
                if (Type == RoutingType.Shortest) throw new Exception("When calculating Public Transport and Truck routes, always use fastest mode");
            }

        }

        public string GetAttributeValue()
        {            
            return $"{EnumHelper.GetDescription(Type)}" +
                $"{$";{EnumHelper.GetDescription(Transport)}"}" +
                $"{(Traffic != null ? $";traffic:{EnumHelper.GetDescription(Traffic)}" : "")}" +
                $"{(Features.Length > 0 ? $";{String.Join(",", Features.Select(f => f.GetAttributeValue()).ToArray())}" : "")}";
        }

        public string GetAttributeName()
        {
            return "mode";
        }

        public class RouteFeature : IAttribute
        {

            public RouteFeatureType FeatureType { get; set; }
            public RouteFeatureWeightType FeatureWeight { get; set; }
            
            /// <summary>
            /// </summary>
            /// <param name="routeFeatureType">Type of the route feature.</param>
            /// <param name="routeFeatureWeight">The route feature weight.</param>
            public RouteFeature(RouteFeatureType routeFeatureType, RouteFeatureWeightType routeFeatureWeight)
            {
                FeatureType = routeFeatureType;
                FeatureWeight = routeFeatureWeight;
            }

            public string GetAttributeValue()
            {
                return $"{EnumHelper.GetDescription(FeatureType)}:{EnumHelper.GetDescription(FeatureWeight)}";
            }




        }

    }
}
