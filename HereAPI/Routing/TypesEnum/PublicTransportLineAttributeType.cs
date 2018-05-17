using System;
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
        /// <summary>
        /// Indicates Whether The Foreground Color Shall Be Included In The Line.
        /// </summary>
        [Description("fg")] Foreground,

        /// <summary>
        /// Indicates Whether The Background Color Of The Line Shall Be Provided.
        /// </summary>
        [Description("bg")] Background,

        /// <summary>
        /// Indicates Whether The Line Style Of The Public Transport Line Shall Be Provided.
        /// </summary>
        [Description("ls")] LineStyle,

        /// <summary>
        /// Indicates Whether The Company Short Name Should Be Included In The Public Transport Line.
        /// </summary>
        [Description("cs")] CompanyShortName,

        /// <summary>
        /// Indicates Whether The Company Logo Should Be Included In The Public Transport Line.
        /// </summary>
        [Description("cl")] CompanyLogo,

        /// <summary>
        /// Indicates Whether The Flags Should Be Included In The Public Transport Line.
        /// </summary>
        [Obsolete("Unsupported public transport line attribute", true)]
        [Description("fl")] Flags, //Unsupported public transport line attribute

        /// <summary>
        /// Indicates Whether The Type Name Should Be Included In The Public Transport Line.
        /// </summary>
        [Description("tn")] TypeName,

        /// <summary>
        /// Indicates Whether The Line Id Should Be Included In The Public Transport Line.
        /// </summary>
        [Obsolete("Unsupported public transport line attribute", true)]
        [Description("li")] LineId, //Unsupported public transport line attribute

        /// <summary>
        /// Indicates Whether The Company Id Should Be Included In The Public Transport Line.
        /// </summary>
        [Obsolete("Unsupported public transport line attribute", true)]
        [Description("ci")] CompanyId, //Unsupported public transport line attribute

        /// <summary>
        /// Indicates Whether The System Id Should Be Included In The Public Transport Line.
        /// </summary>
        [Obsolete("Unsupported public transport line attribute", true)]
        [Description("si")] SystemId, 

        /// <summary>
        /// Indicates Whether Stops Should Be Included In The Public Transport Line.
        /// </summary>
        [Description("st")] Stops,

    }
}
