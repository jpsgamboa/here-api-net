using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Define which attributes are included in the response as part of the 
    /// data representation of the route.<para/>
    /// </summary>
    public enum RouteAttributeType
    {
        /// <summary>
        /// Indicates Whether Via Points Shall Be Included In The Route.
        /// </summary>
        [Description("wp")] Waypoints,

        /// <summary>
        /// Indicates Whether A Route Summary Shall Be Provided For The Route.
        /// </summary>
        [Description("sm")] Summary,

        /// <summary>
        /// Indicates Whether A Country-Based Route Summary Shall Be Provided For The Route.
        /// </summary>
        [Description("sc")] SummaryByCountry,

        /// <summary>
        /// Indicates Whether The Shape Of The Route Shall Be Provided For The Route.
        /// </summary>
        [Description("sh")] Shape,

        /// <summary>
        /// Indicates Whether The Bounding Box Of The Route Shall Be Provided For The Route.
        /// </summary>
        [Description("bb")] BoundingBox,

        /// <summary>
        /// Indicates Whether The Legs Of The Route Shall Be Provided For The Route.
        /// </summary>
        [Description("lg")] Legs,

        /// <summary>
        /// Indicates Whether Additional Notes Shall Be Provided For The Route.
        /// </summary>
        [Description("no")] Notes,

        /// <summary>
        /// Indicates Whether Publictransportlines Shall Be Provided For The Route.
        /// </summary>
        [Description("li")] Lines,

        /// <summary>
        /// Indicates Whether Publictransporttickets Shall Be Provided For The Route.
        /// </summary>
        [Description("tx")] Tickets,

        /// <summary>
        /// Indicates Whether Labels Shall Be Provided For The Route. Labels Are Useful To Distinguish Between Alternative Routes.
        /// </summary>
        [Description("la")] Labels,

        /// <summary>
        /// Indicates Whether Routeid Shall Be Calculated And Provided For The Route. There Are Cases When Routeid Calculation Is Not Possible (E.G. Publictransport) Or Fails Even Though The Rest Of The Route Is Properly Calculated.
        /// </summary>
        [Description("ri")] RouteId,

        /// <summary>
        /// Indicates Whether Maneuver Groups Should Be Included In The Route. Maneuver Groups Are Useful For Multi Modal Routes.
        /// </summary>
        [Description("gr")] Groups,

        /// <summary>
        /// Indicates Whether Incidents On The Route Shall Be Provided For The Route.
        /// </summary>
        [Description("ic")] Incidents,

        /// <summary>
        /// Indicates Whether Crossed Zones Shall Be Provided For The Route
        /// </summary>
        [Description("zo")] Zones,

    }
}
