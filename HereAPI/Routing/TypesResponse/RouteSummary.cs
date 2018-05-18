using HereAPI.Routing.TypesEnum;
using System;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// This type provides summary information for the entire route. This type of information
    /// includes travel time, distance, and descriptions of the overall route path.
    /// </summary>
    public abstract class RouteSummary
    {
        /// <summary>
        /// Indicates total travel distance for the route, in meters.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Contains the travel time estimate in seconds for this element, considering traffic and
        /// transport mode. Based on the TrafficSpeed. The service may also account for additional
        /// time penalties, so this may be greater than the element length divided by the TrafficSpeed.
        /// </summary>
        public double TrafficTime { get; set; }

        /// <summary>
        /// Contains the travel time estimate in seconds for this element, considering transport mode
        /// but not traffic conditions. Based on the BaseSpeed. The service may also account for
        /// additional time penalties, therefore this may be greater than the element length divided
        /// by the BaseSpeed.
        /// </summary>
        public double BaseTime { get; set; }

        /// <summary>
        /// Special link characteristics (like ferry or motorway usage) which are covered by the route.
        /// </summary>
        public RouteLinkFlagType[] Flags { get; set; }

        /// <summary>
        /// Textual description of route summary.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Total travel time in seconds optionally considering traffic depending on the request parameters.
        /// </summary>
        public double TravelTime { get; set; }

        /// <summary>
        /// Estimation of the carbon dioxyde emmision for the given Route. The value depends on the
        /// VehicleType request parameter which specifies the average fuel consumption per 100 km and
        /// the type of combustion engine (diesel or gasoline). Unit is kilograms with precision to
        /// three decimal places.
        /// </summary>
        public double Co2Emission { get; set; }
    }

    /// <summary>
    /// This type provides summary information for the private transport route. This type is derived
    /// from RouteSummaryType.
    /// </summary>
    public class PrivateTransportRouteSummary : RouteSummary
    {
        //This class is only necessary because newtonsoft JSON gets into an infinite loop when trying to deserialize into RouteSummary
    }

    /// <summary>
    /// This type provides summary information for the entire public transport route. This type is
    /// derived from RouteSummaryType.
    /// </summary>
    public class PublicTransportRouteSummary : RouteSummary
    {
        /// <summary>
        /// Start date and time of the route.
        /// </summary>
        public DateTime Departure { get; set; }

        /// <summary>
        /// Summarizes special characteristics of the public transport sections of this route.
        /// </summary>
        public PublicTransportFlagType[] PublicTransportFlags { get; set; }
    }
}