using HereAPI.Shared.TypeObjects;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// The Routing API returns a top-level element, CalculateIsolineResponse, as the answer to a CalculateIsolineRequest.
    /// </summary>
    public class CalculateIsolineResponse
    {
        /// <summary>
        /// Provides details about the request itself, such as the time at which it was processed, a
        /// request id, or the map version on which the calculation was based. <see href="https://developer.here.com/documentation/routing/topics/resource-type-route-response-meta-info.html#resource-type-route-response-meta-info"/>
        /// </summary>
        public RouteResponseMetaInfo MetaInfo { get; set; }

        /// <summary>
        /// Center of the resulting isolines. The center is the coordinate representation in the
        /// routing network of the start or destination waypoint defined in the request. This is
        /// supported only if the Start/Destination in a request is defined by GeoWaypointType or one
        /// LinkID. Otherwise 0 (zero) is returned. This parameter is deprecated, please use start
        /// and destination instead.
        /// </summary>
        public GeoCoordinate Center { get; set; }

        /// <summary>
        /// Represents reached area. <seealso href="https://developer.here.com/documentation/routing/topics/resource-type-isoline.html#resource-type-isoline"/>
        /// </summary>
        public Isoline Isoline { get; set; }

        /// <summary>
        /// Start waypoint of the resulting isolines. It is returned only if start parameter was
        /// provided in the request.
        /// </summary>
        public WayPoint Start { get; set; }

        /// <summary>
        /// Destination waypoint of the resulting isolines. It is returned only if destination
        /// parameter was provided in the request.
        /// </summary>
        public WayPoint Destination { get; set; }
    }
}