using HereAPI.Routing.Services;
using HereAPI.Routing.Services.TypeResponse;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HereAPI.Routing.TypesRequest.WaypointParameter;

namespace Samples
{
    class PrivateTransportCalculateRouteRequest
    {
        //Codes from Here Maps
        //public static string appId   =   "bC4fb9WQfCCZfkxspD4z";
        //public static string appCode = "K2Cpd_EKDzrZb1tz0zdpeQ";

        //My codes
        public static string appId = "ZKWRYPOpslvd4FvTz6uw";
        public static string appCode = "Jy3FG7wDmJ5ZdfLQqfMqkQ";

        static void Main(string[] args)
        {
            HereAPI.HereAPISession.Register(appId, appCode, true);

            //CalculateRouteResponse route = CalculateRouteSample();
            //Console.WriteLine(route.Routes.First().Summary.Text);

            //GetRouteResponse route2 = GetRouteSample(route.Routes[0].RouteId);
            //Console.WriteLine(route2.Routes.First().Summary.Text);

            CalculateIsolineResponse isoline = CalculateIsolineSample();
            Console.WriteLine(isoline.Isoline.Components[0].Shape.Coordinates.Count());
            

            Console.ReadKey();
        }


        private static CalculateRouteResponse CalculateRouteSample()
        {
            CalculateRouteRequest cr = new CalculateRouteRequest()
            {
                RoutingMode = new RequestRoutingMode(RoutingType.Fastest, TransportModeType.Car),
                Waypoints = new WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new GeoCoordinate(51.459047, -0.4415217)),
                    new GeoWaypointParameter(1, new GeoCoordinate(51.542026, 0.281487))
                },
                Departure = new DateTime(2018, 05, 15, 19, 00, 00),

                RouteAttributes = new RouteAttributeType[] { RouteAttributeType.Shape, RouteAttributeType.Legs,
                    RouteAttributeType.Incidents, RouteAttributeType.Groups, RouteAttributeType.RouteId },

                LegAttributes = new RouteLegAttributeType[] { RouteLegAttributeType.Links },

                ManeuverAttributes = new ManeuverAttributeType[] { ManeuverAttributeType.Time, ManeuverAttributeType.TrafficTime,
                    ManeuverAttributeType.BaseTime, ManeuverAttributeType.Notes },

                InstructionFormat = InstructionFormatType.Text
            };
            Console.WriteLine(cr.URL);
            CalculateRouteResponse crr = cr.Get();
            return crr;
        }

        private static GetRouteResponse GetRouteSample(string routeID)
        {
            GetRouteRequest gr = new GetRouteRequest()
            {
                RouteId = routeID
            };
            Console.WriteLine(gr.URL);
            GetRouteResponse grr = gr.Get();
            return grr;
        }


        private static CalculateIsolineResponse CalculateIsolineSample()
        {
            CalculateIsolineRequest ci = new CalculateIsolineRequest()
            {
                RoutingMode = new RequestRoutingMode(RoutingType.Fastest, TransportModeType.Car),
                Start = new GeoWaypointParameter(0, new GeoCoordinate(51.459047, -0.4415217)),
                Departure = new DateTime(2018, 05, 15, 19, 00, 00),
                Ranges = new int[] { 500, 1000 },
                RangeType = RangeType.Distance
            };
            Console.WriteLine(ci.URL);
            CalculateIsolineResponse cir = ci.Get();
            return cir;
        }

    }
}
