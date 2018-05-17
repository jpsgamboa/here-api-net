using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Line style used to draw a line. 
    /// </summary>
    public enum LineStyleType
    {
        [Description("solid")] Solid,
        [Description("dotted")] Dotted,
        [Description("dash")] Dash
    }
}
