using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Define which attributes are included in the response as part of the data representation of the route links.<para/>
    /// 
    /// shape:
    ///     Indicates whether the link should include its geometry<para/>
    /// length:
    ///     Indicates whether the link should include its length<para/>
    /// speedLimit:
    ///     Indicates whether the link should include SpeedLimit<para/>
    /// dynamicSpeedInfo:
    ///     Indicates whether the link should include dynamic speed information<para/>
    /// truckRestrictions:
    ///     Indicates whether the link should include truck restrictions<para/>
    /// flags:
    ///     Indicates whether the link should include link flags<para/>
    /// roadNumber:
    ///     Indicates whether the link should include the link's road number<para/>
    /// roadName:
    ///     Indicates whether the link should include the link's road number<para/>
    /// timezone:
    ///     Indicates whether the link should include the timezone.
    ///     Note: Requesting timezone information is known to slow down responses.<para/>
    /// nextLink:
    ///     Indicates whether the link should include the link which will be next when following the route<para/>
    /// publicTransportLine:
    ///     Indicates whether the link should include information about the public transport line.<para/>
    /// remainTime:
    ///     Indicates whether the link should include information about the remaining time until the destination is
    ///     reached.<para/>
    /// remainDistance:
    ///     Indicates whether the link should include information about the remaining distance until the destination
    ///     is reached.<para/>
    /// maneuver:
    ///     Indicates whether the link should include information about the associated maneuver.<para/>
    /// functionalClass:
    ///     Indicates whether the link should include information about the functional class.<para/>
    /// nextStopName:
    ///     Indicates whether the link should include information about the next stop.<para/>
    /// indices:
    ///     Indicates whether shape index information(FirstPoint, LastPoint) should be included in links instead of
    ///    copying shape points.<para/>
    /// consumption:
    ///     Indicates whether the link should include information on energy consumption. If a consumption model is not
    ///    provided, the consumption value in the response is set to 0.<para/>
    /// </summary>
    public enum RouteLinkAttributeType
    {
        [Description("sh")] Shape,
        [Description("le")] Length,
        [Description("sl")] Speedlimit,
        [Description("ds")] Dynamicspeedinfo,
        [Description("tr")] Truckrestrictions,
        [Description("fl")] Flags,
        [Description("rn")] Roadnumber,
        [Description("ro")] Roadname,
        [Description("tz")] Timezone,
        [Description("nl")] Nextlink,
        [Description("pt")] Publictransportline,
        [Description("rt")] Remaintime,
        [Description("rd")] Remaindistance,
        [Description("ma")] Maneuver,
        [Description("fc")] Functionalclass,
        [Description("ns")] Nextstopname,
        [Description("ix")] Indices,
        [Description("cn")] Consumption
    }
}
