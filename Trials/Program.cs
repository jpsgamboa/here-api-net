using HereAPI.Routing.Services.CalculateRoute;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
using HereAPI.Shared.Conversions;
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

            var t = new TestC()
            {
                A = 11
            };
            t.A = 11;
            t.A = -45;
            

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

            Console.WriteLine(cr.GetCompiledUrl());

            Console.ReadKey();
        }

        class TestC
        {
            [RangeAttribute(1, 10, ErrorMessage = "Ikh")]
            public int A { get; set; }
        }
            //static string GetDescription<T>(Expression<Func<T>> expr)
            //{
            //    try
            //    {
            //        var mexpr = expr.Body as MemberExpression;
            //        object[] attrs = mexpr.Member.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //        DescriptionAttribute desc = attrs[0] as DescriptionAttribute;
            //        return desc.Description;

            //    } catch
            //    {
            //        throw new Exception($"The property {typeof(T).Name}.{((MemberExpression)expr.Body).Member.Name} is missing a description");
            //    }
            //}


            //public static void ConvertShape()
            //{
            //    var json = "{\"Shape\":[\"38.7114429,-9.2402852\",\"38.7114751,-9.2405963\",\"38.7116575,-9.2408967\",\"38.7116683,-9.2409396\"]}";
            //    var json2 = "{\"Shape\":\"38.7114429,-9.2402852\"}";

            //    //var c1 = JsonConvert.DeserializeObject<C1>(json);

            //    var testClassResult = DeserializeJson(json);
            //}

            //class C1
            //{
            //    public string[] Shape { get; set; }
            //}

            //public static TestClass DeserializeJson(string json)
            //{
            //    var settings = GetSettingsFor(new RoutingJsonTypeConversions().GetConversions());
            //    return JsonConvert.DeserializeObject<TestClass>(json, settings);
            //}

            public static JsonSerializerSettings GetSettingsFor(Dictionary<Type, Func<object, object>> conversions)
        {
            return new JsonSerializerSettings { Converters = new List<JsonConverter> { new JsonTypesConverter(conversions) } };
        }

        //internal class TestClass
        //{
        //    public LinkId LinkId { get; set; }
        //    public WaypointType? WaypointType { get; set; }
        //    public RoutingType RoutingType { get; set; }
        //    public GeoCoordinate MappedPosition { get; set; }
        //    public GeoPolyline Shape { get; set; }
        //}


    }
}
