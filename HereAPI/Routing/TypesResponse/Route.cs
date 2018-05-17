using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    public class Route
    {
        /// <summary>
        /// Permanent unique identifier of the route, generated based on route links. 
        /// Can be used to reproduce any previously calculated route.<para/>
        /// If a RouteId is requested, but fails to be calculated for any reason(e.g. public transport enabled), 
        /// then the RouteId element is not available in the response.The rest of the route is intact.
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// List of waypoints that have been defined when requesting for a route calculation. 
        /// The first waypoint is defined as the start of the route; 
        /// the last waypoint marks the destination. Any points in between the two are considered via points. 
        /// </summary>
        public WayPoint[] Waypoints { get; set; }

        /// <summary>
        /// ettings for route calculation. One mode can be specified for each route. 
        /// </summary>
        public ResponseRoutingMode Mode { get; set; }

        /// <summary>
        /// Shape of the route as a polyline. The accuracy might depend on the resolution specified in mpp (meters per pixel) 
        /// when requesting the route. In some use cases (like web portals), only the route's shape is required without the nested 
        /// structure of a route and detailed knowledge of the links and LinkIds. In this case, the shape does not need to be acquired 
        /// by traversing the route's links, but can be represented using this attribute at route level. 
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


        public PublicTransportLine[] PublicTransportLines     { get; set; }
        public PublicTransportTicket[] PublicTransportTickets  { get; set; }
        public RouteNote Note                    { get; set; }
        public RouteSummary Summary                 { get; set; }
        public RouteSummaryByCountry SummaryByCountry        { get; set; }
        public _____ Generalizations         { get; set; }
        public _____ ManueverGroup           { get; set; }
        public _____ Incident                { get; set; }
        public string Label                   { get; set; }
        public _____ Zone { get; set; }

    }
}
