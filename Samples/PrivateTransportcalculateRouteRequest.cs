using HereAPI.Routing.Services;
using HereAPI.Routing.Services.TypeResponse;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
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
        public static string appId = "bC4fb9WQfCCZfkxspD4z";
        public static string appCode = "K2Cpd_EKDzrZb1tz0zdpeQ";

        static void Main(string[] args)
        {
            HereAPI.HereAPISession.Register(appId, appCode, true);

            CalculateRouteRequest request = new CalculateRouteRequest()
            {
                RoutingMode = new RequestRoutingMode(RoutingType.Fastest, TransportModeType.Car),
                Waypoints = new WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new GeoCoordinate(38.711428, -9.240167)),
                    new GeoWaypointParameter(1, new GeoCoordinate(38.857363, -9.165800))
                },
                Departure = new DateTime(2018, 05, 15, 19, 00, 00),

                RouteAttributes = new RouteAttributeType[] { RouteAttributeType.Shape, RouteAttributeType.Legs,
                    RouteAttributeType.Incidents, RouteAttributeType.Groups },

                LegAttributes = new RouteLegAttributeType[] { RouteLegAttributeType.Links },

                ManeuverAttributes = new ManeuverAttributeType[] { ManeuverAttributeType.Time, ManeuverAttributeType.TrafficTime,
                    ManeuverAttributeType.BaseTime, ManeuverAttributeType.Notes },

                InstructionFormat = InstructionFormatType.Text
            };

            CalculateRouteResponse calculateRoute = request.Get();

            Console.WriteLine(calculateRoute.Routes.First().Summary.Text);
            Console.ReadKey();
        }
    }
}
