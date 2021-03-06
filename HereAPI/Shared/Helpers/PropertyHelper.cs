﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace HereAPI.Shared.Requests.Helpers
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