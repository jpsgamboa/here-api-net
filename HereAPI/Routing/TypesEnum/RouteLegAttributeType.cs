using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of the route legs.<para/>
    /// 
    /// waypoint:
    ///     Indicates whether the waypoint shall be included in the route leg.<para/>
    /// maneuvers:
    ///     Indicates whether the maneuvers of the route leg shall be provided.<para/>
    /// links:
    ///     Indicates whether the links along the route leg shall be provided.<para/>
    /// length:
    ///     Indicates whether the route leg should include its length<para/>
    /// travelTime:
    ///     Indicates whether the route leg should include its duration<para/>
    /// shape:
    ///     Indicates whether the shape of the segment to the next maneuver
    ///     should be included in the maneuvers.<para/>
    /// indices:
    ///     Indicates whether shape index information (FirstPoint, LastPoint)
    ///     should be included in the maneuvers instead of copying shape points to the maneuver.<para/>
    /// boundingBox:
    ///     Indicates whether the bounding box of the maneuver shall be provided.<para/>
    /// baseTime:
    ///     Indicates whether the BaseTime information should be provided in RouteLegs.<para/>
    /// trafficTime:
    ///     Indicates whether the TrafficTime information should be included in RouteLegs.<para/>
    /// summary:
    ///     Indicates whether distance and time summary information should be included in RouteLegs<para/>
    /// 
    /// </summary>
    public enum RouteLegAttributeType
    {
        [Description("wp")] Waypoint,
        [Description("mn")] Maneuvers,
        [Description("li")] Links,
        [Description("le")] Length,
        [Description("tt")] Traveltime,
        [Description("sh")] Shape,
        [Description("ix")] Indices,
        [Description("bb")] Boundingbox,
        [Description("bt")] Basetime,
        [Description("tm")] Traffictime,
        [Description("sm")] Summary
    }
}
