using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of the route maneuvers.<para/>
    /// 
    /// position:
    ///     Indicates whether the position should be included in the maneuvers.<para/>
    /// shape:
    ///     Indicates whether the shape of the segment to the next maneuver should be included in the maneuvers.<para/>
    /// travelTime:
    ///     Indicates whether the time needed to the next maneuver should be included in the maneuvers.<para/>
    /// length:
    ///     Indicates whether the distance to the next maneuver should be included in the maneuvers.<para/>
    /// time:
    ///     Indicates whether the point in time when the maneuver will take place should be included in the maneuvers.<para/>
    /// link:
    ///     Indicates whether the link where the maneuver takes place shall be included in the maneuver.<para/>
    /// publicTransportLine:
    ///     Indicates whether the information about the public transport line should be included in the maneuvers.<para/>
    /// publicTransportTickets:
    ///     Indicates whether the information about the public transport tickets should be included in the maneuvers.<para/>
    /// platform:
    ///     Indicates whether the platform information for a public transport line should be included in the maneuvers.<para/>
    /// roadName:
    ///     Indicates whether the road name should be included in the maneuvers.<para/>
    /// nextRoadName:
    ///     Indicates whether the name of the next road shall be included in the maneuvers.<para/>
    /// roadNumber:
    ///     Indicates whether the road number should be included in the maneuvers.<para/>
    /// nextRoadNumber:
    ///     Indicates whether the number of the next road should be included in the maneuvers.<para/>
    /// signPost:
    ///     Indicates whether the sign post information should be included in the maneuvers.<para/>
    /// notes:
    ///     Indicates whether additional notes should be included in the maneuvers.<para/>
    /// action:
    ///     Indicates whether actions should be included in the maneuvers.<para/>
    /// direction:
    ///     Indicates whether directions should be included in the maneuvers.<para/>
    /// nextManeuver:
    ///     Indicates whether a reference to the next maneuver should be included in the maneuvers.<para/>
    /// freewayExit:
    ///     Indicates whether the freeway exit should be included in the maneuvers.<para/>
    /// freewayJunction:
    ///     Indicates whether the freeway junction should be included in the maneuvers.<para/>
    /// baseTime:
    ///     Indicates whether the BaseTime information should be included in the maneuvers. By default, BaseTime
    ///     information is not included in the maneuvers.<para/>
    /// trafficTime:
    ///     Indicates whether the TrafficTime information should be included in the maneuvers. By default, TrafficTime
    ///     information is not included in the maneuvers.<para/>
    /// indices:
    ///     Indicates whether shape index information (FirstPoint, LastPoint) should be included in the maneuvers
    ///     instead of copying shape points to the maneuver.<para/>
    /// boundingBox:
    ///     Indicates whether the bounding box of the route shall be provided for the route.<para/>
    /// roadShield:
    ///     Indicates whether road shield information should be included in the maneuvers.<para/>
    /// startAngle:
    ///     Indicates whether start angle information should be included in the maneuvers.<para/>
    /// waitTime:
    ///     Indicates whether wait time information should be included in public transport maneuvers.<para/>
    /// shapeQuality:
    ///     Indicates whether information about shape quality should be included in maneuvers.<para/>
    /// publicTransportDelays:
    ///    Indicates whether the delay information should be included in the public transport maneuvers.<para/>
    /// </summary>
    public enum ManeuverAttributeType
    {
        [Description("po")] Position,
        [Description("sh")] Shape,
        [Description("tt")] TravelTime,
        [Description("le")] Length,
        [Description("ti")] Time,
        [Description("li")] Link,
        [Description("pt")] PublicTransportLine,
        [Description("tx")] PublicTransportTickets,
        [Description("td")] PublicTransportDelays,
        [Description("pl")] Platform,
        [Description("rn")] RoadName,
        [Description("nr")] NextRoadName,
        [Description("ru")] RoadNumber,
        [Description("nu")] NextRoadNumber,
        [Description("sp")] SignPost,
        [Description("no")] Notes,
        [Description("ac")] Action,
        [Description("di")] Direction,
        [Description("nm")] NextManeuver,
        [Description("fe")] FreewayExit,
        [Description("fj")] FreewayJunction,
        [Description("bt")] BaseTime,
        [Description("tm")] TrafficTime,
        [Description("ix")] Indices,
        [Description("bb")] BoundingBox,
        [Description("rs")] RoadShield,
        [Description("sa")] StartAngle,
        [Description("wt")] WaitTime,
        [Description("sq")] ShapeQuality,
    }
}
