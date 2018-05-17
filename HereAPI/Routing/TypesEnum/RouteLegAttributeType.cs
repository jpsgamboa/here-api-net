using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of the route legs.<para/>
    /// </summary>
    public enum RouteLegAttributeType
    {
        /// <summary>
        /// Indicates Whether The Waypoint Shall Be Included In The Route Leg.
        /// </summary>
        [Description("wp")] Waypoint,

        /// <summary>
        /// Indicates Whether The Maneuvers Of The Route Leg Shall Be Provided.
        /// </summary>
        [Description("mn")] Maneuvers,

        /// <summary>
        /// Indicates Whether The Links Along The Route Leg Shall Be Provided.
        /// </summary>
        [Description("li")] Links,

        /// <summary>
        /// Indicates Whether The Route Leg Should Include Its Length
        /// </summary>
        [Description("le")] Length,

        /// <summary>
        /// Indicates Whether The Route Leg Should Include Its Duration
        /// </summary>
        [Description("tt")] TravelTime,

        /// <summary>
        /// Indicates Whether The Shape Of The Segment To The Next Maneuver Should Be Included In The Maneuvers.
        /// </summary>
        [Description("sh")] Shape,

        /// <summary>
        /// Indicates Whether Shape Index Information (Firstpoint, Lastpoint) Should Be Included In The Maneuvers Instead Of Copying Shape Points To The Maneuver.
        /// </summary>
        [Description("ix")] Indices,

        /// <summary>
        /// Indicates Whether The Bounding Box Of The Maneuver Shall Be Provided.
        /// </summary>
        [Description("bb")] BoundingBox,

        /// <summary>
        /// Indicates Whether The Basetime Information Should Be Provided In Routelegs.
        /// </summary>
        [Description("bt")] BaseTime,

        /// <summary>
        /// Indicates Whether The Traffictime Information Should Be Included In Routelegs.
        /// </summary>
        [Description("tm")] TrafficTime,

        /// <summary>
        /// Indicates Whether Distance And Time Summary Information Should Be Included In Routelegs.
        /// </summary>
        [Description("sm")] Summary,

    }
}
