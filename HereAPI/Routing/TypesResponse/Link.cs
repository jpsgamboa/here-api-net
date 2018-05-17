using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{

    /// <summary>
    /// A link is a path segment in the routing network, such as a road. This type is an abstract base class for  PublicTransportLinkType and  PrivateTransportLinkType . It includes the common attributes that every that every link type provides.<para/>
    /// In this type, FirstPoint and LastPoint be used as alternative representation to avoid repeating shapes already provided at the route level. 
    /// <see href="https://developer.here.com/documentation/routing/topics/resource-type-route-link.html"/>
    /// <seealso href="https://developer.here.com/documentation/routing/topics/resource-type-public-transport-link.html"/>
    /// <seealso href="https://developer.here.com/documentation/routing/topics/resource-type-private-transport-link.html"/>
    /// </summary>
    public abstract class Link
    {
        /// <summary>
        /// Permanent ID which references a network link. When presented with a minus sign as the first character, this ID indicates that the link should be traversed in the opposite direction of its default coding (for example, walking SW on a link that is coded as one-way traveling NE). 
        /// </summary>
        public LinkId LinkId { get; set; }

        /// <summary>
        /// A polyline representation of the parent element (for example, route, route leg, link, etc.). 
        /// </summary>
        public GeoPolyline Shape { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the first point of the shape subsegment for the associated element (for example, maneuver, link). Must be followed by LastPoint. 
        /// </summary>
        public int FirstPoint { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the last point of the shape subsegment for the associated element (for example, maneuver, link). Must be preceded by FirstPoint. 
        /// </summary>
        public int LastPoint { get; set; }

        /// <summary>
        /// Length of the parent element, always provided in meters. 
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Distance from the start of this element to the destination of the route. 
        /// </summary>
        public double RemainDistance { get; set; }

        /// <summary>
        /// Time needed from the start of this element to the destination of the route. Considers any available traffic information, if enabled and the authorized for the user. 
        /// </summary>
        public double RemainTime { get; set; }

        /// <summary>
        /// Reference to the next link on the recommended route. 
        /// </summary>
        public LinkId NextLink { get; set; }

        /// <summary>
        /// Reference to the maneuver that needs to take place to go from the current link to the next link in the route.<para/>
        /// Last maneuver has zero length, as it is an "arrive" maneuver.It is not referenced by any link.
        /// </summary>
        public string Maneuver { get; set; }

    }

    /// <summary>
    /// A public transport link is a link traversed in a route using public transport.
    /// </summary>
    public class PublicTransportLink : Link
    {
        /// <summary>
        /// Name of the stop at the end of the link.
        /// </summary>
        public string NextStopName { get; set; }

        /// <summary>
        /// Reference key to the PublicTransportLine object. To reduce data volume, the PublicTransport element is not directly embedded in the ManeuverType object, but is swapped out into the Route element. 
        /// </summary>
        public string Line { get; set; }
    }

    /// <summary>
    /// A private transport link is a link traversed in a route using private mode of transportation such as car, truck, pedestrian
    /// </summary>
    public class PrivateTransportLink : Link
    {

        /// <summary>
        /// Legal speed limit in m/s (based on link only, unrelated to vehicle type). Contains the following reserved values:<para/>
        /// 999: indicates that there is no speed restriction for link<para/>
        /// 998:<para/>
        /// -  United States: marked on ramps as from/toward reference speed limit<para/>
        /// -  Europe: marked on ramps as from/toward reference speed limit, if no posted speed limit or motorway symbol exists<para/>
        /// 0: no speed limit available, value will be hidden in the response.
        /// </summary>
        public double SpeedLimit { get; set; }

        /// <summary>
        /// Dynamic speed information on the link which can change over time, such as traffic information (if enabled) or time-dependent road closures. 
        /// </summary>
        public DynamicSpeedInfo DynamicSpeedInfo { get; set; }

        /// <summary>
        /// Flags that describe special characteristics of the link, such as "motorway", "tollroad", "ferry", etc. 
        /// </summary>
        public RouteLinkFlagType? MyProperty { get; set; }

        /// <summary>
        /// The functional class is used to classify roads depending on the speed, importance and connectivity of the road.<para/>
        /// The value represents one of the five levels:<para/>
        /// 1: allowing for high volume, maximum speed traffic movement<para/>
        /// 2: allowing for high volume, high speed traffic movement<para/>
        /// 3: providing a high volume of traffic movement<para/>
        /// 4: providing for a high volume of traffic movement at moderate speeds between neighbourhoods<para/>
        /// 5: roads whose volume and traffic movement are below the level of any functional class<para/>
        /// </summary>
        public int FunctionalClass { get; set; }

        /// <summary>
        /// Number of the road (such as A5, B49, etc.) that the link is passing. 
        /// </summary>
        public string RoadNumber { get; set; }

        /// <summary>
        /// Timezone in which the link is located. Includes daylight savings information. 
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Restrictions that apply to trucks on this link. (Only relevant if truck has been selected as TransportMode).
        /// </summary>
        public TruckRestriction[] TruckRestrictions { get; set; }

        /// <summary>
        /// Name of the road the link is passing. 
        /// </summary>
        public string RoadName { get; set; }

        /// <summary>
        /// Energy or fuel consumed while traversing link. If a consumption model is not provided, the consumption value is set to 0 
        /// </summary>
        public double Consumption { get; set; }
    }
}
