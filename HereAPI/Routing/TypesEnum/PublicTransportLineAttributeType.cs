using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Sequence of attribute keys of the fields that are included in public transport line elements.<para/>
    ///
    /// foreground:
    ///     Indicates whether the foreground color shall be included in the line.
    /// background:
    ///     Indicates whether the background color of the line shall be provided.<para/>
    /// lineStyle:
    ///     Indicates whether the line style of the public transport line shall be provided.<para/>
    /// companyShortName:
    ///     Indicates whether the company short name should be included in the public transport line.<para/>
    /// companyLogo:
    ///     Indicates whether the company logo should be included in the public transport line.<para/>
    /// flags:
    ///     Indicates whether the flags should be included in the public transport line.<para/>
    /// typeName:
    ///     Indicates whether the type name should be included in the public transport line.<para/>
    /// lineId:
    ///     Indicates whether the line Id should be included in the public transport line.<para/>
    /// companyId:
    ///     Indicates whether the company Id should be included in the public transport line.<para/>
    /// systemId:
    ///     Indicates whether the system Id should be included in the public transport line.<para/>
    /// stops:
    ///     Indicates whether stops should be included in the public transport line.<para/>
    /// </summary>
    public enum PublicTransportLineAttributeType
    {
        [Description("fg")] Foreground,
        [Description("bg")] Background,
        [Description("ls")] Linestyle,
        [Description("cs")] Companyshortname,
        [Description("cl")] Companylogo,
        [Description("fl")] Flags,
        [Description("tn")] Typename,
        [Description("li")] Lineid,
        [Description("ci")] Companyid,
        [Description("si")] Systemid,
        [Description("st")] Stops
    }
}
