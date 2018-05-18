using HereAPI.Routing.TypesEnum;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Defines the information available for a public transport line.
    /// </summary>
    public class PublicTransportLine
    {
        /// <summary>
        /// Name of the line
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// Color that is to be used as foreground color when drawing the line.
        /// </summary>
        public string LineForeground { get; set; }

        /// <summary>
        /// Color that is to be used as background color when drawing the line.
        /// </summary>
        public string LineBackground { get; set; }

        /// <summary>
        /// Style that is to be used when drawing the line.
        /// </summary>
        public LineStyleType? LineStyle { get; set; }

        /// <summary>
        /// Name of the transit line's company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Short name of the transit line's company
        /// </summary>
        public string CompanyShortName { get; set; }

        /// <summary>
        /// Logo of the transit line's company
        /// </summary>
        public ExternalResource CompanyLogo { get; set; }

        /// <summary>
        /// Final destination of the transport line
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Additional attributes classifying the transport line
        /// </summary>
        public PublicTransportLinkFlagType[] Flags { get; set; }

        /// <summary>
        /// Type of the transport line
        /// </summary>
        public PublicTransportType Type { get; set; }

        /// <summary>
        /// Name of the transport line's type (such as "ICE", "TGV", etc.).
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// List of all stops on this public transport line.
        /// </summary>
        public PublicTransportStop[] Stops { get; set; }
    }
}