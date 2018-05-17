using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Type of the routing zone. 
    /// </summary>
    public enum RoutingZoneType
    {
        /// <summary>
        /// A zone where a vignette is required to use affiliated roads. 
        /// </summary>
        [Description("vignette")] Vignette,

        /// <summary>
        /// A zone of roads where a congestion pricing system applies. 
        /// </summary>
        [Description("congestionPricing")] CongestionPricing,

        /// <summary>
        /// A zone of roads with a specific administrative class specified by an official transport regulations (often country specific). 
        /// <seealso href="https://developer.here.com/documentation/routing/topics/country-specific-regulations.html">Country Specific Regulations.</seealso> 
        /// </summary>
        [Description("adminClass")] AdminClass,

    }
}
