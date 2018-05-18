namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Rather than providing the entire route summary as a single summary, you can use this type to
    /// return summary information for each country in the route.
    /// </summary>
    public class RouteSummaryByCountry : RouteSummary
    {
        /// <summary>
        /// Country code of the associated route summary, using the ISO 3166-1-alpha-3 format.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Total distance of toll roads on the route within the country, in meters
        /// </summary>
        public double TollRoadDistance { get; set; }
    }
}