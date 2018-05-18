using HereAPI.Routing.TypesEnum;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// A routing zone is an area which comprises roads that share the same access restrictions
    /// imposed usually by a legal authority. This attribute provides details like a zone name, zone
    /// type or list of affected route sections. The provided zone identifer may be used in a request
    /// as one of values of the excludeZones parameter
    /// </summary>
    public class RoutingZone
    {
        /// <summary>
        /// Unique and persistent identifier of the routing zone.
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Name of the routing zone.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the routing zone.
        /// </summary>
        public RoutingZoneType? Type { get; set; }

        /// <summary>
        /// List of references to the route sections which are in the routing zone.
        /// </summary>
        public RouteShapeReference[] ShapeIndices { get; set; }
    }
}