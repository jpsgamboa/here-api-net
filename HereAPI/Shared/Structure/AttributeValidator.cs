using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HereAPI.Shared.Structure
{
    class AttributeValidator
    {

        public static List<string> Validate(object o)
        {
            return TypeDescriptor
                .GetProperties(o.GetType())
                .Cast<PropertyDescriptor>()
                .SelectMany(pd => pd.Attributes.OfType<ValidationAttribute>()
                                    .Where(va => !va.IsValid(pd.GetValue(o))))
                                    .Select(xx => xx.ErrorMessage).ToList();
        }        

    }
}
