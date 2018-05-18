using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of
    /// the route links.
    /// <para/>
    /// </summary>
    public enum RouteLinkAttributeType
    {
        /// <summary>
        /// Indicates Whether The Link Should Include Its Geometry
        /// </summary>
        [Description("sh")] Shape,

        /// <summary>
        /// Indicates Whether The Link Should Include Its Length
        /// </summary>
        [Description("le")] Length,

        /// <summary>
        /// Indicates Whether The Link Should Include Speedlimit
        /// </summary>
        [Description("sl")] SpeedLimit,

        /// <summary>
        /// Indicates Whether The Link Should Include Dynamic Speed Information
        /// </summary>
        [Description("ds")] DynamicSpeedInfo,

        /// <summary>
        /// Indicates Whether The Link Should Include Truck Restrictions
        /// </summary>
        [Description("tr")] TruckRestrictions,

        /// <summary>
        /// Indicates Whether The Link Should Include Link Flags
        /// </summary>
        [Description("fl")] Flags,

        /// <summary>
        /// Indicates Whether The Link Should Include The Link'S Road Number
        /// </summary>
        [Description("rn")] RoadNumber,

        /// <summary>
        /// Indicates Whether The Link Should Include The Link'S Road Number
        /// </summary>
        [Description("ro")] RoadName,

        /// <summary>
        /// Indicates Whether The Link Should Include The Timezone. Note: Requesting Timezone
        /// Information Is Known To Slow Down Responses.
        /// </summary>
        [Description("tz")] Timezone,

        /// <summary>
        /// Indicates Whether The Link Should Include The Link Which Will Be Next When Following The Route
        /// </summary>
        [Description("nl")] NextLink,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Public Transport Line.
        /// </summary>
        [Description("pt")] PublicTransportLine,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Remaining Time Until The
        /// Destination Is Reached.
        /// </summary>
        [Description("rt")] RemainTime,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Remaining Distance Until
        /// The Destination Is Reached.
        /// </summary>
        [Description("rd")] RemainDistance,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Associated Maneuver.
        /// </summary>
        [Description("ma")] Maneuver,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Functional Class.
        /// </summary>
        [Description("fc")] FunctionalClass,

        /// <summary>
        /// Indicates Whether The Link Should Include Information About The Next Stop.
        /// </summary>
        [Description("ns")] NextStopName,

        /// <summary>
        /// Indicates Whether Shape Index Information (Firstpoint, Lastpoint) Should Be Included In
        /// Links Instead Of Copying Shape Points.
        /// </summary>
        [Description("ix")] Indices,

        /// <summary>
        /// Indicates Whether The Link Should Include Information On Energy Consumption. If A
        /// Consumption Model Is Not Provided, The Consumption Value In The Response Is Set To 0.
        /// </summary>
        [Description("cn")] Consumption,
    }
}