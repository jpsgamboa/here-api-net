using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Enumeration to identify different action types needed for public transport maneuvers. 
    /// </summary>
    public enum PublicTransportAcionType
    {
        [Description("enter")] Enter,
        [Description("change")] Ciesel,
        [Description("leave")] Leave
    }
}
