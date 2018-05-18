using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Defines a list of supported resource type identifiers.
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// Identifier For The Bitmap Representing The Junction View
        /// </summary>
        [Description("junctionView")] JunctionView,

        /// <summary>
        /// Identifier For The Bitmap Representing The Sign-As-Real Information
        /// </summary>
        [Description("signAsReal")] SignAsReal,

        /// <summary>
        /// Identifier For The Bitmap Representing The Direction Arrow At A Junction. Displayed On
        /// Top Of The Junction View
        /// </summary>
        [Description("directionArrow")] DirectionArrow,

        /// <summary>
        /// Identifier For The Bitmap Representing Any Kind Of Advertisement
        /// </summary>
        [Description("advertising")] Advertising,

        /// <summary>
        /// Identifier For The Bitmap Representing The Vendor Icon, Such As Of A Public Transport System.
        /// </summary>
        [Description("vendorIcon")] VendorIcon,

        /// <summary>
        /// Identifier For The Bitmap Representing The Vendor Logo, Such As Of A Public Transport System
        /// </summary>
        [Description("vendorLogo")] VendorLogo,

        /// <summary>
        /// Identifier For The Svg Resource Representing A Template For Displaying Routes (Such As
        /// Highway Signs). Clients Will Have To Include The Route Number In The Graphic To Display A
        /// Concrete Route Sign
        /// </summary>
        [Description("routeTemplate")] RouteTemplate,
    }
}