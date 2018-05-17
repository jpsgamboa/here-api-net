using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Conversions
{
    public interface ITypeConversions
    {
        Dictionary<Type, Func<object, object>> GetConversions();
    }
}
