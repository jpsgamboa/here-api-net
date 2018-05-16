using HereAPI.Shared.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Structure
{
    public interface IRequestAttribute : IAttribute
    {
        string GetAttributeName();
    }
}
