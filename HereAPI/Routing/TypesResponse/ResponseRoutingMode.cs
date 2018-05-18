using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;

namespace HereAPI.Routing.TypesResponse
{
    public class ResponseRoutingMode
    {
        public RoutingType Type { get; set; }

        public TransportModeType[] TransportModes { get; set; }

        public TrafficModeType? Traffic { get; set; }

        public RouteFeature[] Feature { get; set; }
    }
}