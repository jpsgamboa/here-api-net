using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Conversions
{
    interface ITypeConversions
    {

        Dictionary<Type, Func<string, object>> GetConversions();

    }
}
