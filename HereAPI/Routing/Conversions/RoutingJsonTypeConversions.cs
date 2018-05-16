using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HereAPI.Routing.Conversions
{
    public static class RoutingJsonTypeConversions
    {

        public  static Dictionary<Type, Func<string, object>> CONVERSIONS = new Dictionary<Type, Func<string, object>>
        {
            { typeof(LinkId), (s) => ConvertLinkId(s) },
            { typeof(WaypointType?), (s) => ConvertWaypointType(s) },
        };


        public static LinkId ConvertLinkId(string s)
        {
            try
            {
                if (LinkId.DIRECTION_SYMBOLS.Contains(s[0]))
                {
                    return new LinkId(int.Parse(s.Substring(1)), EnumHelper.GetValue<LinkId.LinkDirection>(s.Substring(0, 1)));
                }
                else
                {
                    return new LinkId(int.Parse(s), LinkId.LinkDirection.Any);
                }
            }
            catch
            {
                return null;
            }              
        }

        //TODO TENTAR CONVERTER TODOS OS ENUM TYPES GENERICAMENTE

        public static T ConvertEnumType<T>(string s)
        {
            try
            {
                return EnumHelper.GetValue<T>(s);
            }
            catch
            {
                return null;
            }
        }

        public static WaypointType? ConvertWaypointType(string s)
        {
            try
            {
                return EnumHelper.GetValue<WaypointType>(s);
            }
            catch
            {
                return null;
            }
        }

        public static SideOfStreetType ConvertSideOfStreetType(string s)
        {
            try
            {
                return EnumHelper.GetValue<SideOfStreetType>(s);
            }
            catch
            {
                return null;
            }
        }



    }
}
