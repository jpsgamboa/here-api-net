using System;
using System.Collections.Generic;

namespace HereAPI.Shared.Conversions
{
    public interface ITypeConversions
    {
        Dictionary<Type, Func<object, object>> GetConversions();
    }
}