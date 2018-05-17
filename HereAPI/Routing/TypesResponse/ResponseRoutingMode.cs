using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using System;
using System.Collections.Generic;
using System.Text;

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
