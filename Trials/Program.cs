using HereAPI.Routing.Services.CalculateRoute;
using HereAPI.Routing.Services.TypeResponse;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.TypeEnums;
using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static HereAPI.Routing.TypesRequest.WaypointParameter;

namespace Trials
{
    class Program
    {
        //Codes from Here Maps
        public static string appId  = "bC4fb9WQfCCZfkxspD4z";
        public static string appCode = "K2Cpd_EKDzrZb1tz0zdpeQ";

        static void Main(string[] args)
        {

            HereAPI.HereAPI.Register(appId, appCode, true);

            CalculateRouteRequest cr = new CalculateRouteRequest()
            {
                RoutingMode = new RequestRoutingMode(RoutingType.Fastest, TransportModeType.Car),
                Waypoints = new WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new GeoCoordinate(38.711428, -9.240167)),
                    new GeoWaypointParameter(1, new GeoCoordinate(38.857363, -9.165800))
                },
                Departure = new DateTime(2018,05,15,19,00,00),
                RouteAttributes = new RouteAttributeType[] { RouteAttributeType.Shape, RouteAttributeType.Legs, RouteAttributeType.Incidents, RouteAttributeType.Groups},
                LegAttributes = new RouteLegAttributeType[] {RouteLegAttributeType.Links},
                ManeuverAttributes = new ManeuverAttributeType[] {ManeuverAttributeType.Time, ManeuverAttributeType.TrafficTime, ManeuverAttributeType.BaseTime, ManeuverAttributeType.Notes},
                
            };

            CalculateRouteResponse calculateRoute = cr.Get();

            try
            {
                Console.WriteLine(cr.URL);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }        

    }
}
