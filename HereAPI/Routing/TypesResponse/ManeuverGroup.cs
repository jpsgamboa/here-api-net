using HereAPI.Routing.TypesEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Maneuver groups organize maneuvers into sections based on TransportModeType to better provide the user with an itinerary summary and brief route instructions.
    /// </summary>
    public class ManeuverGroup
    {

        /// <summary>
        /// ID of the first maneuver in a group. 
        /// </summary>
        public string FirstManeuver { get; set; }

        /// <summary>
        /// ID of the last maneuver in a group. 
        /// </summary>
        public string LastManeuver { get; set; }

        /// <summary>
        /// Settings for route calculation. One mode can be specified for each route. 
        /// </summary>
        public ResponseRoutingMode Mode { get; set; }

        /// <summary>
        /// Describes summary of a maneuver group. 
        /// </summary>
        public string SummaryDescription { get; set; }

        /// <summary>
        /// Describes arrival instructions of a maneuver group. 
        /// </summary>
        public string ArrivalDescription { get; set; }

        /// <summary>
        /// Describes wait instructions of a maneuver group. 
        /// </summary>
        public string WaitDescription { get; set; }

        /// <summary>
        /// Type of public transport used in a group of maneuvers. 
        /// </summary>
        public PublicTransportType? PublicTransportType { get; set; }

    }
}
