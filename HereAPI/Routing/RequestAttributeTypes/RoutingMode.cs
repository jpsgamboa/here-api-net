using HereAPI.Shared.Requests;
using HereAPI.Shared.Requests.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HereAPI.Routing.RequestAttributeTypes
{
    public class RoutingMode : IRequestAttribute
    {

        public RoutingType Type { get; set; }
        public TransportMode Transport { get; set; }
        public TrafficMode? Traffic { get; set; }
        public RouteFeature[] Features { get; set; }

        /// <summary>
        /// The RoutingMode specifies how the route is calculated. <para/>
        /// Parameter representation:<para/>
        /// RoutingMode = Type + [TransportModes] + [TrafficMode] + [Feature]<para/>
        /// https://developer.here.com/documentation/routing/topics/resource-param-type-routing-mode.html
        /// </summary>
        /// <param name="routingType"></param>
        /// <param name="transportMode"></param>
        /// <param name="trafficMode"></param>
        /// <param name="routeFeatures"></param>
        /// 
        public RoutingMode(RoutingType routingType, TransportMode transportMode, TrafficMode? trafficMode = null, params RouteFeature[] routeFeatures)
        {
            Type = routingType;
            Transport = transportMode;
            Traffic = trafficMode;
            Features = routeFeatures;

            if (Transport == TransportMode.Truck || Transport == TransportMode.PublicTransport || Transport == TransportMode.PublicTransportTimeTable)
            {
                if (Type == RoutingType.Shortest) throw new Exception("When calculating Public Transport and Truck routes, always use fastest mode");
            }

        }

        public string GetAttributeValue()
        {            
            return $"{EnumHelper.GetDescription(Type)}" +
                $"{$";{EnumHelper.GetDescription(Transport)}"}" +
                $"{(Traffic != null ? $";traffic:{EnumHelper.GetDescription(Traffic)}" : "")}" +
                $"{(Features.Length > 0 ? $";{String.Join(",", Features.Select(f => f.GetParameterValue()).ToArray())}" : "")}";
        }

        public string GetAttributeName()
        {
            return "mode";
        }

        /// <summary>
        /// RoutingType provides identifiers for different optimizations which can be applied during the route calculation. 
        /// Selecting the routing type affects which constraints, speed attributes and weights are taken into account during route calculation.<para/>
        /// When calculating Public Transport and truck routes, always use fastest mode.<para/>
        /// fastest: <para/>
        ///         Route calculation from start to destination optimized by travel time.
        ///         Depending on the traffic mode provided by the request, travel time is determined with or
        ///         without traffic information. In some cases, the route returned by the fastest mode may not
        ///         be the route with the shortest possible travel time. 
        ///         For example, the routing service may favor a route that remains on a highway, even if a shorter travel
        ///         time can be achieved by taking a detour or shortcut through a side road.<para/>
        /// shortest: <para/>
        ///         Route calculation from start to destination disregarding any speed information. 
        ///         In this mode, the distance of the route is minimized, while keeping the route sensible. 
        ///         This includes, for example, penalizing turns. Because of that, the resulting route will
        ///         not necessarily be the one with minimal distance.
        /// </summary>
        public enum RoutingType
        {
            [Description("fastest")] Fastest,
            [Description("shortest")] Shortest
        }

        /// <summary>
        /// enabled:<para/>
        ///    No departure time provided: <para/>
        ///        This behavior is deprecated and will return error in the future.
        ///        Static time based restrictions: Ignored
        ///        Real-time traffic closures: Valid for entire length of route.
        ///        Real-time traffic flow events: Speed at calculation time used for entire length of route.
        ///        Historical and predictive traffic speed: Ignored<para/>
        ///
        ///    Departure time provided:<para/>
        ///        Static time based restrictions: Avoided if road would be traversed within validity period of the
        ///        restriction.
        ///        Real-time traffic closures: Avoided if road would be traversed within validity period of the
        ///        incident.
        ///        Real-time traffic flow events: Speed used if road would be traversed within validity period of the
        ///        flow event.
        ///        Historical and predictive traffic: Used.<para/>
        ///
        ///disabled: 	<para/>
        ///    No departure time provided:<para/>
        ///        Static time based restrictions: Ignored
        ///        Real-time traffic closures: Ignored.
        ///        Real-time traffic flow speed: Ignored.
        ///        Historical and predictive traffic: Ignored<para/>
        ///
        ///    Departure time provided:<para/>
        ///        Static time based restrictions: Avoided if road would be traversed within validity period of the
        ///        restriction.
        ///        Real-time traffic closures: Valid for entire length of route.
        ///        Real-time traffic flow speed: Ignored.
        ///        Historical and predictive traffic: Ignored<para/>
        ///
        ///    Note: Difference between traffic disabled and enabled affects only the calculation of the route.
        ///    Traffic time of the route will still be calculated for all routes using the same rules as for
        ///    traffic:enabled.<para/>
        ///
        ///default:<para/>
        ///    Let the service automatically apply traffic related constraints that are suitable
        ///    for the selected routing type, transport mode, and departure time.
        ///    Also user entitlements will be taken into consideration.<para/>
        /// </summary>
        public enum TrafficMode
        {
            [Description("enabled")] Enabled,
            [Description("disabled")] Disabled,
            [Description("default")] Default
        }


        /// <summary>
        /// car:
        ///     Route calculation for cars.<para/>
        ///
        /// carHOV:
        ///     Route calculation for HOV(high-occupancy vehicle) cars.<para/>
        ///
        /// pedestrian:
        ///     Route calculation for a pedestrian.As one effect, maneuvers will be optimized for walking, i.e.
        ///     segments will consider actions relevant for pedestrians and maneuver instructions will contain
        ///     texts suitable for a walking person. This mode disregards any traffic information.<para/>
        ///
        /// publicTransport:
        ///     Route calculation using public transport lines and walking parts to get to stations.It is based on
        ///     static map data, so the results are not aligned with officially published timetable.<para/>
        ///
        /// publicTransportTimeTable:
        ///     Route calculation using public transport lines and walking parts to get to stations.This mode uses
        ///     additional officially published timetable information to provide most precise routes and
        ///     times.In case the timetable data is unavailable, the service will use estimated results based on
        ///     static map data(same as from publicTransport mode).<para/>
        ///
        /// truck:
        ///     Route calculation for trucks.This mode considers truck limitations on links and uses different
        ///     speed assumptions when calculating the route.<para/>
        ///
        /// bicycle:
        ///     Route calculation for bicycles.This mode uses the pedestrian road network, but uses different speeds
        ///     based on each road's suitability for cycling. Pedestrian roads that are also open for cars in
        ///     the travel direction are considered open for cycling, as are pedestrian roads located in parks.
        ///     These roads use full bicycle speed for routing. Other pedestrian roads, including travelling the
        ///     wrong way down one-way streets, are considered at the pedestrian walking speed, as it is assumed the
        ///     bicycle must be pushed.<para/>
        /// </summary>
        public enum TransportMode
        {
            [Description("car")] Car,
            [Description("carHOV")] CarHOV,
            [Description("pedestrian")] Pedestrian,
            [Description("publicTransport")] PublicTransport,
            [Description("publicTransportTimeTable")] PublicTransportTimeTable,
            [Description("truck")] Truck,
            [Description("bicycle")] Bicycle
        }

        public class RouteFeature
        {

            public RouteFeatureType FeatureType { get; set; }
            public RouteFeatureWeight FeatureWeight { get; set; }
            
            /// <summary>
            /// </summary>
            /// <param name="routeFeatureType">Type of the route feature.</param>
            /// <param name="routeFeatureWeight">The route feature weight.</param>
            public RouteFeature(RouteFeatureType routeFeatureType, RouteFeatureWeight routeFeatureWeight)
            {
                FeatureType = routeFeatureType;
                FeatureWeight = routeFeatureWeight;
            }

            public string GetParameterValue()
            {
                return $"{EnumHelper.GetDescription(FeatureType)}:{EnumHelper.GetDescription(FeatureWeight)}";
            }

            /// <summary>
            /// tollroad: Identifier for toll roads<para/>
            /// motorway: Identifier for motorways<para/>
            /// boatFerry: Identifier for boat ferries<para/>
            /// railFerry: Identifier for rail ferries<para/>
            /// tunnel: Identifier for tunnels<para/>
            /// dirtRoad: Identifier for dirt roads<para/>
            /// park: Identifier for links through parks.This route feature is only applicable for pedestrian and bicycle routing.<para/>
            /// </summary>
            public enum RouteFeatureType
            {
                [Description("tollroad")] Tollroad,
                [Description("motorway")] Motorway,
                [Description("boatFerry")] BoatFerry,
                [Description("railFerry")] RailFerry,
                [Description("tunnel")] Tunnel,
                [Description("dirtRoad")] DirtRoad,
                [Description("park")] Park            
            }

            /// <summary>
            /// strictExclude: The routing engine guarantees that the route does not contain strictly excluded features. If the condition cannot be fulfilled no route is returned.<para/>
            /// softExclude: The routing engine does not consider links containing the corresponding feature.If no route can be found because of these limitations the condition is weakened.<para/>
            /// avoid: The routing engine assigns penalties for links containing the corresponding feature.<para/>
            /// normal: The routing engine does not alter the ranking of links containing the corresponding feature.<para/>
            /// </summary>
            public enum RouteFeatureWeight
            {
                [Description("-3")] StrictExclude,
                [Description("-2")] SoftExclude,
                [Description("-1")] Avoid,
                [Description("0")]  Normal,

            }
        }

    }
}
