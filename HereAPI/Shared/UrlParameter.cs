using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared
{
    public interface IUrlParameter
    {
        string GetParameterName();
        string GetParameterValue();

    }
}
