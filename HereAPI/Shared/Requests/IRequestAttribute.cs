using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Requests
{
    public interface IRequestAttribute
    {
        string GetAttributeName();
        string GetAttributeValue();

    }
}
