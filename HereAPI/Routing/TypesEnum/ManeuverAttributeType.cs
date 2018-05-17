using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of the route maneuvers.<para/>
    /// </summary>
    public enum ManeuverAttributeType
    {
        /// <summary>
        /// Indicates Whether The Position Should Be Included In The Maneuvers.
        /// </summary>
        [Description("po")] Position,

        /// <summary>
        /// Indicates Whether The Shape Of The Segment To The Next Maneuver Should Be Included In The Maneuvers.
        /// </summary>
        [Description("sh")] Shape,

        /// <summary>
        /// Indicates Whether The Time Needed To The Next Maneuver Should Be Included In The Maneuvers.
        /// </summary>
        [Description("tt")] TravelTime,

        /// <summary>
        /// Indicates Whether The Distance To The Next Maneuver Should Be Included In The Maneuvers.
        /// </summary>
        [Description("le")] Length,

        /// <summary>
        /// Indicates Whether The Point In Time When The Maneuver Will Take Place Should Be Included In The Maneuvers.
        /// </summary>
        [Description("ti")] Time,

        /// <summary>
        /// Indicates Whether The Link Where The Maneuver Takes Place Shall Be Included In The Maneuver.
        /// </summary>
        [Description("li")] Link,

        /// <summary>
        /// Indicates Whether The Information About The Public Transport Line Should Be Included In The Maneuvers.
        /// </summary>
        [Description("pt")] PublicTransportLine,

        /// <summary>
        /// Indicates Whether The Information About The Public Transport Tickets Should Be Included In The Maneuvers.
        /// </summary>
        [Description("tx")] PublicTransportTickets,

        /// <summary>
        /// Indicates Whether The Platform Information For A Public Transport Line Should Be Included In The Maneuvers.
        /// </summary>
        [Description("pl")] Platform,

        /// <summary>
        /// Indicates Whether The Road Name Should Be Included In The Maneuvers.
        /// </summary>
        [Description("rn")] RoadName,

        /// <summary>
        /// Indicates Whether The Name Of The Next Road Shall Be Included In The Maneuvers.
        /// </summary>
        [Description("nr")] NextRoadName,

        /// <summary>
        /// Indicates Whether The Road Number Should Be Included In The Maneuvers.
        /// </summary>
        [Description("ru")] RoadNumber,

        /// <summary>
        /// Indicates Whether The Number Of The Next Road Should Be Included In The Maneuvers.
        /// </summary>
        [Description("nu")] NextRoadNumber,

        /// <summary>
        /// Indicates Whether The Sign Post Information Should Be Included In The Maneuvers.
        /// </summary>
        [Description("sp")] SignPost,

        /// <summary>
        /// Indicates Whether Additional Notes Should Be Included In The Maneuvers.
        /// </summary>
        [Description("no")] Notes,

        /// <summary>
        /// Indicates Whether Actions Should Be Included In The Maneuvers.
        /// </summary>
        [Description("ac")] Action,

        /// <summary>
        /// Indicates Whether Directions Should Be Included In The Maneuvers.
        /// </summary>
        [Description("di")] Direction,

        /// <summary>
        /// Indicates Whether A Reference To The Next Maneuver Should Be Included In The Maneuvers.
        /// </summary>
        [Description("nm")] NextManeuver,

        /// <summary>
        /// Indicates Whether The Freeway Exit Should Be Included In The Maneuvers.
        /// </summary>
        [Description("fe")] FreewayExit,

        /// <summary>
        /// Indicates Whether The Freeway Junction Should Be Included In The Maneuvers.
        /// </summary>
        [Description("fj")] FreewayJunction,

        /// <summary>
        /// Indicates Whether The Basetime Information Should Be Included In The Maneuvers. By Default, Basetime Information Is Not Included In The Maneuvers.
        /// </summary>
        [Description("bt")] BaseTime,

        /// <summary>
        /// Indicates Whether The Traffictime Information Should Be Included In The Maneuvers. By Default, Traffictime Information Is Not Included In The Maneuvers.
        /// </summary>
        [Description("tm")] TrafficTime,

        /// <summary>
        /// Indicates Whether Shape Index Information (Firstpoint, Lastpoint) Should Be Included In The Maneuvers Instead Of Copying Shape Points To The Maneuver.
        /// </summary>
        [Description("ix")] Indices,

        /// <summary>
        /// Indicates Whether The Bounding Box Of The Route Shall Be Provided For The Route.
        /// </summary>
        [Description("bb")] BoundingBox,

        /// <summary>
        /// Indicates Whether Road Shield Information Should Be Included In The Maneuvers.
        /// </summary>
        [Description("rs")] RoadShield,

        /// <summary>
        /// Indicates Whether Start Angle Information Should Be Included In The Maneuvers.
        /// </summary>
        [Description("sa")] StartAngle,

        /// <summary>
        /// Indicates Whether Wait Time Information Should Be Included In Public Transport Maneuvers.
        /// </summary>
        [Description("wt")] WaitTime,

        /// <summary>
        /// Indicates Whether Information About Shape Quality Should Be Included In Maneuvers.
        /// </summary>
        [Description("sq")] ShapeQuality,

        /// <summary>
        /// Indicates Whether The Delay Information Should Be Included In The Public Transport Maneuvers.
        /// </summary>
        [Description("td")] PublicTransportDelays,

    }
}
