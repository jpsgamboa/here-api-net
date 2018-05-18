using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary> 180 degree turns are allowed for stopOver but not for passThrough.<para/> Waypoints
    /// defined through a drag-n-drop action should be marked as pass-through. <para/> PassThrough
    /// waypoints will not appear in the list of maneuvers. <para/> <see
    /// href'="https://developer.here.com/documentation/routing/topics/resource-type-enumerations.html#resource-type-enumerations__enum-waypoint-parameter-type"/> </summary>
    public enum WaypointType
    {
        /// <summary>
        /// The route will stop at the waypoint and a stop time can be provided. 180 degree turns are allowed.
        /// </summary>
        [Description("stopOver")] StopOver,

        /// <summary>
        /// The route won't stop at the waypoint. PassThrough waypoints will not appear in the list
        /// of maneuvers. Waypoints defined through a drag-n-drop action should be marked as pass-through.
        /// </summary>
        [Description("passThrough")] PassThrough
    }
}