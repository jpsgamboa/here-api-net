using HereAPI.Shared.TypeObjects;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// The service defines a route leg as the portion of a route between one waypoint and the next.
    /// RouteLegType contains information about a route leg, such as the time required to traverse
    /// it, its shape, start and end point, as well as information about any sublegs contained in the
    /// leg due to the presence of passthrough waypoints. <see href="https://developer.here.com/documentation/routing/topics/resource-type-route-leg.html"/>
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// Route waypoint that is located at the start of this route leg. This waypoint matches one
        /// of the waypoints in the Route.
        /// </summary>
        public WayPoint Start { get; set; }

        /// <summary>
        /// Route waypoint that is located at the end of this route leg. This waypoint matches one of
        /// the waypoints in the Route.
        /// </summary>
        public WayPoint End { get; set; }

        /// <summary>
        /// Length of the leg.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// The time in seconds needed to travel along this route leg. Considers any available
        /// traffic information, if enabled and authorized for the user.
        /// </summary>
        public double TravelTime { get; set; }

        /// <summary>
        /// List of all maneuvers which are included in this portion of the route.
        /// </summary>
        public Maneuver[] Maneuvers { get; set; }

        /// <summary>
        /// List of all links which are included in this portion of the route.
        /// </summary>
        public Link[] Links { get; set; }

        /// <summary>
        /// Bounding Box of the leg.
        /// </summary>
        public GeoBoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Shape of route leg.
        /// </summary>
        public GeoPolyline Shape { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the first point of the shape subsegment
        /// associated with this leg. Must be followed by LastPoint.
        /// </summary>
        public int FirstPoint { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the last point of the shape subsegment
        /// associated with this leg. Must be preceded by FirstPoint.
        /// </summary>
        public int LastPoint { get; set; }

        /// <summary>
        /// Time in seconds required for this route leg, taking available traffic information into account.
        /// </summary>
        public double TrafficTime { get; set; }

        /// <summary>
        /// Estimated time in seconds spent on this leg, without considering traffic conditions. The
        /// service may also account for additional time penalties, therefore this may be greater
        /// than the leg length divided by the base speed.
        /// </summary>
        public double BaseTime { get; set; }

        /// <summary>
        /// Distance and time summary information for the route leg.
        /// </summary>
        public RouteSummary Summary { get; set; }

        /// <summary>
        /// Distance and time summary information for any sub legs of this route leg. The service
        /// defines sub legs where passThrough waypoints are used, so the list may be empty if no
        /// such waypoints exist within this route leg.
        /// </summary>
        public RouteSummary[] SubLegSummary { get; set; }
    }
}