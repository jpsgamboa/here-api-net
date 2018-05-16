using HereAPI.Routing.Services.CalculateRoute;
using HereAPI.Routing.TypesRequest;
using HereAPI.Shared.Types;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
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

            VehicleType vt = new VehicleType(~VehicleType.EngineType.Diesel, 5.28f);


            HereAPI.HereAPI.Register(appId, appCode, true);

            CalculateRouteRequest cr = new CalculateRouteRequest()
            {
                RoutingMode = new RoutingMode(RoutingMode.RoutingType.Fastest, RoutingMode.TransportMode.Car),
                Waypoints = new WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new GeoPoint(38.711428, -9.240167)),
                    new GeoWaypointParameter(1, new GeoPoint(38.857363, -9.165800))
                },
                Departure = new DateTime(2018,05,15,19,00,00),
                RouteAttributes = new RouteRepresentationOptions.RouteAttribute[] { RouteRepresentationOptions.RouteAttribute.Shape}
            };

            Console.WriteLine(cr.GetCompiledUrl());

            Console.ReadKey();
        }


        static string GetDescription<T>(Expression<Func<T>> expr)
        {
            try
            {
                var mexpr = expr.Body as MemberExpression;
                object[] attrs = mexpr.Member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                DescriptionAttribute desc = attrs[0] as DescriptionAttribute;
                return desc.Description;

            } catch
            {
                throw new Exception($"The property {typeof(T).Name}.{((MemberExpression)expr.Body).Member.Name} is missing a description");
            }
        }
        
    }
}
