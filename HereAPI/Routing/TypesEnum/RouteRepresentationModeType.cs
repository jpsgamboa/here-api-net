using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// The enumeration type RouteRepresentationMode defines which parts of the route are returned by
    /// services for standard use cases.Any custom route representation definition besides these
    /// predefined modes is possible by using the detailed AttributeType switches
    /// </summary>
    public enum RouteRepresentationModeType
    {
        /// <summary>
        /// Overview Mode Only Returns The Route And The Routesummary Object
        /// </summary>
        [Description("overview")] Overview,

        /// <summary>
        /// Display Mode That Allows To Show The Route With All Maneuvers. Links Won'T Be Included In
        /// The Response
        /// </summary>
        [Description("display")] Display,

        /// <summary>
        /// Drag And Drop Mode To Be Used During Drag And Drop (Re-Routing) Actions. The Response
        /// Will Only Contain The Shape Of The Route Restricted To The View Bounds Provided In The
        /// Representation Options.
        /// </summary>
        [Description("dragNDrop")] DragNDrop,

        /// <summary>
        /// Navigation Mode To Provide All Information Necessary To Support A Navigation Device. This
        /// Mode Activates The Most Extensive Data Response As All Link Information Will Be Included
        /// In The Response To Allow A Detailed Display While Navigating. Routeid Will Not Be
        /// Calculated In This Mode However, Unless It Is Additionally Requested.
        /// </summary>
        [Description("navigation")] Navigation,

        /// <summary>
        /// Paging Mode That Will Be Used When Incrementally Loading Links While Navigating Along The
        /// Route. The Response Will Be Limited To Link Information.
        /// </summary>
        [Description("linkPaging")] LinkPaging,

        /// <summary>
        /// Turn By Turn Mode To Provide All Information Necessary To Support Turn By Turn. This Mode
        /// Activates All Data Needed For Navigation Excluding Any Redundancies. Routeid Will Not Be
        /// Calculated In This Mode However, Unless It Is Additionally Requested.
        /// </summary>
        [Description("turnByTurn")] TurnByTurn,
    }
}