using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Defines a list of special characteristics that may apply to the public transport sections of a route. 
    /// </summary>
    public enum PublicTransportFlagType
    {
        /// <summary>
        /// The route contains a public transport leg which uses estimated times based on known transit frequency 
        /// </summary>
        [Description("containsTimeEstimate")] ContainsTimeEstimate,

    }
}
