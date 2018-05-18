using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HereAPI.Shared.Structure
{
    public class AttributeValidator
    {
        /// <summary>
        /// Validates objects containing data annotations constraints
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string[] Validate(object o)
        {
            var errors = new List<string>();

            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach(var pInfo in properties)
            {
                var valAttrs = pInfo.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach(ValidationAttribute vAttr in valAttrs)
                {
                    if (!vAttr.IsValid(pInfo.GetValue(o))) errors.Add(vAttr.ErrorMessage);
                }

                if (typeof(IAttribute).IsAssignableFrom(pInfo.GetType()))
                {
                    errors.AddRange(((IAttribute) pInfo.GetValue(o)).Validate());
                }
            }

            return errors.ToArray();

            //TypeDescriptor.GetProperties(o.GetType()).Cast<PropertyDescriptor>().

            //return TypeDescriptor
            //    .GetProperties(o.GetType())
            //    .Cast<PropertyDescriptor>()
            //    .SelectMany(pd => pd.Attributes.OfType<ValidationAttribute>()
            //                        .Where(va => !va.IsValid(pd.GetValue(o))))
            //                        .Select(xx => xx.ErrorMessage).ToArray();
        }

    }

}
