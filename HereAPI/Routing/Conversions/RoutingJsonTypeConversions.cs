using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HereAPI.Routing.Conversions
{
    public class RoutingJsonTypeConversions : ITypeConversions
    {

        public Dictionary<Type, Func<string, object>> GetConversions()
        {
            return new Dictionary<Type, Func<string, object>>
                        {
                            { typeof(LinkId), (s) => ConvertLinkId(s) },
                            { typeof(Enum), (s) => ConvertEnumType<Enum>(s) },
                        };
        }

        public LinkId ConvertLinkId(string s)
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

        public T ConvertEnumType<T>(string s)
        {
            try
            {
                return EnumHelper.GetValue<T>(s);
            }
            catch
            {
                return default(T);
            }
        }
        

    }
}
