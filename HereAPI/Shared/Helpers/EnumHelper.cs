using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace HereAPI.Shared.Helpers
{
    class EnumHelper
    {
        
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static Enum GetValue(string description, Type enumType)
        {
            foreach (Enum value in Enum.GetValues(enumType))
            {
                if (GetDescription(value).CompareTo(description) == 0)
                {
                    return value;
                }
            }
            throw new Exception($"Description not found: {description}, for enum type: {enumType}");
        }

    }

   
}
