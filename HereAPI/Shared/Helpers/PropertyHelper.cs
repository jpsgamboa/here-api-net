using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HereAPI.Shared.Helpers
{
    public class PropertyHelper
    {

        public static string GetDescription<T>(Expression<Func<T>> expr)
        {
            try
            {
                var mexpr = expr.Body as MemberExpression;
                object[] attrs = mexpr.Member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                DescriptionAttribute desc = attrs[0] as DescriptionAttribute;
                return desc.Description;

            }
            catch
            {
                throw new Exception($"The property {typeof(T).Name}.{((MemberExpression)expr.Body).Member.Name} is missing a description");
            }
        }
    }
}
