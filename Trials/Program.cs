using HereAPI.Routing;
using HereAPI.Routing.CalculateRoute;
using HereAPI.Routing.RequestAttributeTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HereAPI.Routing.RequestAttributeTypes.WaypointParameter;

namespace Trials
{
    class Program
    {

        public static string appId  = "bC4fb9WQfCCZfkxspD4z";
        public static string appCode = "K2Cpd_EKDzrZb1tz0zdpeQ";
        
        static void Main(string[] args)
        {

            VehicleType vt = new VehicleType(~VehicleType.EngineType.Diesel, 5.28f);


            HereAPI.HereAPI.Register(appId, appCode, true);

            CalculateRouteRequest cr = new CalculateRouteRequest()
            {
                RoutingMode = new HereAPI.Routing.RequestAttributeTypes.RoutingMode(HereAPI.Routing.RequestAttributeTypes.RoutingMode.RoutingType.Fastest, HereAPI.Routing.RequestAttributeTypes.RoutingMode.TransportMode.Car),
                Waypoints = new HereAPI.Routing.RequestAttributeTypes.WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new HereAPI.Shared.Geometry.GeoPoint(38.711428, -9.240167)),
                    new GeoWaypointParameter(1, new HereAPI.Shared.Geometry.GeoPoint(38.857363, -9.165800))
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

        //public static string GetDescription<T>(string fieldName)
        //{
        //    string result;
        //    FieldInfo fi = typeof(T).GetField(fieldName.ToString());
        //    if (fi != null)
        //    {
        //        try
        //        {
        //            object[] descriptionAttrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        //            DescriptionAttribute description = (DescriptionAttribute)descriptionAttrs[0];
        //            result = (description.Description);
        //        }
        //        catch
        //        {
        //            result = null;
        //        }
        //    }
        //    else
        //    {
        //        result = null;
        //    }

        //    return result;
        //}


        //public static class AttributeHelper
        //{
        //    public static TOut GetConstFieldAttributeValue<T, TOut, TAttribute>(
        //        string fieldName,
        //        Func<TAttribute, TOut> valueSelector)
        //        where TAttribute : Attribute
        //    {
        //        var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
        //        if (fieldInfo == null)
        //        {
        //            return default(TOut);
        //        }
        //        var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        //        return att != null ? valueSelector(att) : default(TOut);
        //    }
        //}
    }
}
