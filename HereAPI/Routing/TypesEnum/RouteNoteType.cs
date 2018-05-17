using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Defines type identifiers for RoutingNote objects. 
    /// </summary>
    public enum RouteNoteType
    {
        /// <summary>
        /// Indicates an additional information for the maneuver or the segment leading to the maneuver, 
        /// like "border crossing", "segment includes tunnel/bridge/toll/unpaved/etc."
        /// </summary>
        [Description("info")] Info,

        /// <summary>
        /// ndicates a note with warning character, like "sharp curve ahead"
        /// </summary>
        [Description("warning")] Warning,

        /// <summary>
        /// Indicates a note providing additional information about time dependent restrictions on the 
        /// segment ("road closed during winter").
        /// </summary>
        [Description("restriction")] Restriction,

        /// <summary>
        /// Indicates a note providing additional information about violated routing options, 
        /// such as route contains tollroads even though it has been requested to avoid tollroads.
        /// </summary>
        [Description("violation")] Violation,

        /// <summary>
        /// Indicates a note providing additional information on traffic.
        /// </summary>
        [Description("traffic")] Traffic
    }
}
