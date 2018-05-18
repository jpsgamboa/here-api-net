using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HereAPI.Routing.TypesRequest
{
    public class RequestRoutingMode : IRequestAttribute
    {
        public RoutingType Type { get; set; }

        public TransportModeType Mode { get; set; }

        public TrafficModeType? Traffic { get; set; }

        public RouteFeature[] Features { get; set; }

        /// <summary>
        /// The RoutingMode specifies how the route is calculated.
        /// <para/>
        /// Parameter representation:
        /// <para/>
        /// RoutingMode = Type + [TransportModes] + [TrafficMode] + [Feature]
        /// <para/>
        /// https://developer.here.com/documentation/routing/topics/resource-param-type-routing-mode.html
        /// </summary>
        /// <param name="routingType"></param>
        /// <param name="transportMode"></param>
        /// <param name="trafficMode"></param>
        /// <param name="routeFeatures"></param>
        public RequestRoutingMode(RoutingType routingType, TransportModeType mode, TrafficModeType? trafficMode = null, params RouteFeature[] routeFeatures)
        {
            Type = routingType;
            Mode = mode;
            Traffic = trafficMode;
            Features = routeFeatures;
        }

        public string GetAttributeValue()
        {
            return $"{EnumHelper.GetDescription(Type)}" +
                    $";{EnumHelper.GetDescription(Mode)}" +
                    $";traffic:{(Traffic != null ? $"{EnumHelper.GetDescription(Traffic)}" : $"{EnumHelper.GetDescription(TrafficModeType.Default)}")}" +
                    $";{(Features.Length > 0 ? $"{String.Join(",", Features.Select(f => f.GetAttributeValue()).ToArray())}" : "")}";
        }

        public string GetAttributeName()
        {
            return "mode";
        }

        public string[] Validate()
        {
            var errors = new List<string>();
            if (Mode == TransportModeType.Truck || Mode == TransportModeType.PublicTransport || Mode == TransportModeType.PublicTransportTimeTable)
            {
                if (Type == RoutingType.Shortest) errors.Add("When calculating Public Transport and Truck routes, always use fastest mode");
            }
            errors.AddRange(AttributeValidator.Validate(this));
            return errors.ToArray();
        }
    }
}