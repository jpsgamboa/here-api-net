using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json;

namespace HereAPI.Routing.TypesResponse
{
    public class Route
    {
        /// <summary>
        /// Permanent unique identifier of the route, generated based on route links. Can be used to
        /// reproduce any previously calculated route.
        /// <para/>
        /// If a RouteId is requested, but fails to be calculated for any reason(e.g. public
        /// transport enabled), then the RouteId element is not available in the response.The rest of
        /// the route is intact. <see href="https://developer.here.com/documentation/routing/topics/resource-type-route.html"/>
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// List of waypoints that have been defined when requesting for a route calculation. The
        /// first waypoint is defined as the start of the route; the last waypoint marks the
        /// destination. Any points in between the two are considered via points.
        /// </summary>
        public WayPoint[] Waypoints { get; set; }

        /// <summary>
        /// ettings for route calculation. One mode can be specified for each route.
        /// </summary>
        public ResponseRoutingMode Mode { get; set; }

        /// <summary>
        /// Shape of the route as a polyline. The accuracy might depend on the resolution specified
        /// in mpp (meters per pixel) when requesting the route. In some use cases (like web
        /// portals), only the route's shape is required without the nested structure of a route and
        /// detailed knowledge of the links and LinkIds. In this case, the shape does not need to be
        /// acquired by traversing the route's links, but can be represented using this attribute at
        /// route level.
        /// </summary>
        public GeoPolyline Shape { get; set; }

        /// <summary>
        /// Bounding Box of the route.
        /// </summary>
        public GeoBoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Partition of the route into legs between the different waypoints.
        /// </summary>
        public Leg[] Legs { get; set; }

        /// <summary>
        /// List of all public transport lines which are used by public transport links and maneuvers
        /// of the route.
        /// </summary>
        public PublicTransportLine[] PublicTransportLines { get; set; }

        /// <summary>
        /// For public transport routes, a list of ticketing options for the provided route. Each
        /// option is a list of tickets covering those parts of the route for which ticketing
        /// information is supported.
        /// </summary>
        [JsonProperty("PublicTransportTicketss")] // I know..
        public PublicTransportTickets[] PublicTransportTickets { get; set; }

        /// <summary>
        /// Notes that are either related to the calculation (violated routing options) or that refer
        /// the route as a whole. In addition to these notes additional notes can be attached to
        /// maneuvers. The maneuver notes are usually related to the route segment following the
        /// maneuver and would be of interest when passing this segment.
        /// </summary>
        public RouteNote[] Note { get; set; }

        /// <summary>
        /// Overall route distance and time summary.
        /// </summary>
        public RouteSummary Summary { get; set; }

        /// <summary>
        /// Route distance and time summary per traversed country.
        /// </summary>
        public RouteSummaryByCountry[] SummaryByCountry { get; set; }

        /// <summary>
        /// A simplified base polyline with a given tolerance parameter used to reduce the number of
        /// points. The points in the base polyline are implicitly referenced by index.
        /// </summary>
        public Generalization[] Generalizations { get; set; }

        /// <summary>
        /// Maneuvers organized into sections based on TransportModeType. It provides the user
        /// grouped itinerary summary and brief route instructions.
        /// </summary>
        public ManeuverGroup[] ManueverGroups { get; set; }

        /// <summary>
        /// An incident describes a temporary event on a route. It typically refers to a real world
        /// incident (accident, road construction, etc.) spanning on one or several subsequent links.
        /// </summary>
        public Incident Incident { get; set; }

        /// <summary>
        /// Unique names within a route used to distinguish between alternative routes. They can be
        /// city names, road names or something else that makes the distinction possible.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// A list of routing zones crossed by the route.
        /// </summary>
        public RoutingZone Zone { get; set; }
    }
}