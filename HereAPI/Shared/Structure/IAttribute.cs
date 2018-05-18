using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Structure
{

    /// <summary>
    /// All atributes that make part of the request must implement a method to get the formatted attribute
    /// and a method to validate it.
    /// </summary>
    public interface IAttribute
    {
        string GetAttributeValue();

        string[] Validate();
    }
}
