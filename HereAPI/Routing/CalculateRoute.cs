﻿using HereAPI.Routing.ParameterTypes;
using HereAPI.Shared;
using HereAPI.Shared.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using static HereAPI.Routing.ParameterTypes.EnumTypes;
using static HereAPI.Routing.ParameterTypes.RouteRepresentationOptions;
using static HereAPI.Shared.Geometry;

namespace HereAPI.Routing
{

    public class CalculateRoute : Request
    {

        // #### Required parameters

        /// <summary>
        /// The routing mode determines how the route is calculated. 
        /// </summary>
        public RoutingMode RoutingMode { get; set; }

        /// <summary>
        /// List of waypoints that define a route. 
        /// The first element marks the start, the last the end point. 
        /// Waypoints in between are interpreted as via points.
        /// </summary>
        public List<WaypointParameter> Waypoints { get; set; }

        // #### Optional parameters

        // #### Implementing IUrlParameter
        /// <summary>
        /// Specifies the resolution of the view and a possible snap resolution in meters per pixel in the response. 
        /// You must specify a whole, positive integer.<para/>
        /// If you specify only one value, then this value defines the view resolution only.<para/>
        /// You can use snap resolution to adjust waypoint links to the resolution of the client display.
        /// </summary>
        public Resolution Resolution { get; set; }

        /// <summary>
        /// Flag to control JSON output. 
        /// </summary>
        public JsonRepresentation JsonAttributes { get; set; }

        /// <summary>
        /// Specifies the desired tolerances for generalizations of the base route geometry. 
        /// Tolerances are given in degrees of longitude or latitude on a spherical approximation of the Earth. 
        /// One meter is approximately equal to 0:00001 degrees at typical latitudes.
        /// </summary>
        public GeneralizationTolerance GeneralizationTolerances { get; set; }

        /// <summary>
        /// Specifies type of vehicle engine and average fuel consumption, which can be used to estimate CO2 emission for the route summary 
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// If you request information on consumption, you must provide a consumption model. 
        /// The possible values are default and standard. When you specify the value standard, 
        /// you must provide additional information in the query parameter customconsumptiondetails
        /// </summary>
        public ConsumptionModel ConsumptionModel { get; set; }

        /// <summary>
        /// Provides vehicle specific information for use in the consumption model. 
        /// This information can include such things as the amount of energy consumed while travelling at a given speed.
        /// </summary>
        public ConsumptionModel.CustomConsumptionDetails CustomConsumptionDetails { get; set; }


        //// #### Not Implementing IUrlParameter

        /// <summary>
        /// Clients may pass in an arbitrary string to trace request processing through the system. 
        /// The RequestId is mirrored in the MetaInfo element of the response structure. 
        /// </summary>
        [Description("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Areas which the route must not cross.
        /// </summary>
        [Description("avoidAreas")]
        public List<BoundingBox> AvoidAreas { get; set; }

        /// <summary>
        /// Links which the route must not cross. 
        /// </summary>
        [Description("avoidLinks")]
        public List<LinkId> AvoidLinks { get; set; }

        /// <summary>
        /// The optional avoid seasonal closures boolean flag can be specified to avoid usage of seasonally closed links
        /// </summary>
        [Description("avoidSeasonalClosures")]
        public bool? AvoidSeasonalClosures { get; set; }

        /// <summary>
        /// List of turn types that the route should avoid. Defaults to empty list.
        /// Note: Currently, truck routing is the only mode that supports the avoidTurns option 
        /// and only complex intersections can have the turn type difficult. 
        /// The route always avoids trivial u-turns, also when you don't specify the avoidTurns parameter. 
        /// </summary>
        [Description("avoidTurns")]
        public List<TurnType> AvoidTurns { get; set; }

        /// <summary>
        /// Identifiers of zones which the route must not cross at any circumstances.
        /// </summary>
        [Description("excludeZones")]
        public List<ulong> ExcludeZones { get; set; }

        /// <summary>
        /// Countries that must be excluded from route calculation. <para/>
        /// Country code according to ISO 3166-1-alpha-3
        /// </summary>
        [Description("excludeCountries")]
        public List<String> ExcludeCountries { get; set; }

        /// <summary>
        /// Time when travel is expected to start. 
        /// Traffic speed and incidents are taken into account when calculating the route. 
        /// Specify either departure or arrival, not both.
        /// </summary>
        [Description("departure")]
        public DateTime? Departure { get; set; }

        /// <summary>
        /// Time when travel is expected to end. Specify either departure or arrival, not both.
        /// </summary>
        [Description("arrival")]
        public DateTime? Arrival { get; set; }

        /// <summary>
        /// Maximum number of alternative routes that will be calculated and returned. 
        /// Alternative routes can be unavailable, thus they are not guaranteed to be returned. 
        /// If at least one via point is used in a route request, returning alternative routes is not supported. 
        /// 0 stands for "no alternative routes", i.e. only best route is returned.
        /// </summary>
        [Description("alternatives")]
        public uint? Alternatives { get; set; }

        /// <summary>
        /// Defines the measurement system used in instruction text. When imperial is selected, 
        /// units used are based on the language specified in the request. Defaults to metric when not specified. 
        /// </summary>
        [Description("metricSystem")]
        public UnitSystem? UnitSystem { get; set; }

        /// <summary>
        /// If the view bounds are given in the request then only route shape points which fit into these bounds will be returned. 
        /// The route shape beyond the view bounds is reduced to the points which are referenced by links, legs or maneuvers. 
        /// A common use case for this is the drag and drop scenario where the client is only interested in a rough visual 
        /// update of the route in the currently visible bounds.
        /// </summary>
        [Description("viewBounds")]
        public BoundingBox ViewBounds { get; set; }

        /// <summary>
        /// Defines the representation format of the maneuver's instruction text. 
        /// </summary>
        [Description("instructionFormat")]
        public InstructionFormatType? InstructionFormat { get; set; }

        /// <summary>
        /// A list of languages for all textual information, the first supported language is used. 
        /// If there are no matching supported languages the response is an error. Defaults to en-us.
        /// </summary>
        [Description("language")]
        public Language? Language { get; set; }

        /// <summary>
        /// Name of a user-defined function used to wrap the JSON response. 
        /// </summary>
        [Description("jsonCallback")]
        public string JsonCallback { get; set; }

        /// <summary>
        /// Define which elements are included in the response as part of the data representation of the route.
        /// </summary>
        [Description("representation")]
        public RouteRepresentationMode? Representation { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route. 
        /// Defaults to waypoints, summary, legs and additionally lines if publicTransport or publicTransportTimeTable mode is used.
        /// </summary>
        [Description("routeAttributes")]
        public List<RouteAttribute> RouteAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route legs. 
        /// Defaults to maneuvers, waypoint, length, travelTime. 
        /// </summary>
        [Description("legAttributes")]
        public List<RouteLegAttribute> LegAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route maneuvers. 
        /// Defaults to position, length, travelTime.
        /// </summary>
        [Description("maneuverAttributes")]
        public List<ManeuverAttribute> ManeuverAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route links. Defaults to shape, speedLimit. 
        /// </summary>
        [Description("linkAttributes")]
        public List<RouteLinkAttribute> LinkAttributes { get; set; }

        /// <summary>
        /// Sequence of attribute keys of the fields that are included in public transport line elements. 
        /// If not specified, defaults to lineForeground, lineBackground.
        /// </summary>
        [Description("lineAttributes")]
        public List<PublicTransportLineAttribute> LineAttributes { get; set; }

        /// <summary>
        /// Restricts number of changes in a public transport route to a given value. 
        /// The parameter does not filter resulting alternatives. Instead, it affects 
        /// route calculation so that only routes containing at most the given number of changes are considered. 
        /// The provided value must be between 0 and 10.
        /// </summary>
        [Description("maxNumberOfChanges")]
        public uint? MaxNumberOfChanges { get; set; }

        /// <summary>
        /// Public transport types that shall not be included in the response route. 
        /// </summary>
        [Description("avoidTransportTypes")]
        public List<PublicTransportType> AvoidTransportTypes { get; set; }

        /// <summary>
        /// Allows to prefer or avoid public transport routes with longer walking distances. 
        /// A value > 1.0 means a slower walking speed and will prefer routes with less walking distance. 
        /// The provided value must be between 0.01 and 100.
        /// </summary>
        [Description("walkTimeMultiplier")]
        public float? WalkTimeMultiplier { get; set; }

        /// <summary>
        /// Specifies speed which will be used by a service as a walking speed for pedestrian routing (meters per second). 
        /// This parameter affects pedestrian, publicTransport and publicTransportTimetable modes. 
        /// The provided value must be between 0.5 and 2.
        /// </summary>
        [Description("walkSpeed")]
        public float? WalkSpeed { get; set; }

        /// <summary>
        /// Allows the user to specify a maximum distance to the start and end stations of a public transit route. 
        /// Only valid for publicTransport and publicTransportTimetable routes. 
        /// The provided value must be between 0 and 6000.
        /// </summary>
        [Description("walkRadius")]
        public float? WalkRadius { get; set; }

        /// <summary>
        /// Enables the change maneuver in the route response, which indicates a public transit line change. 
        /// In the absence of this maneuver, each line change is represented with a pair of subsequent enter and leave maneuvers. 
        /// We recommend enabling combineChange behavior wherever possible, to simplify client-side development.
        /// </summary>
        [Description("combineChange")]
        public bool? CombineChange { get; set; }

        /// <summary>
        /// Truck routing only, specifies the vehicle type. Defaults to truck. <para/>
        /// Note: Relevant for restrictions that apply exclusively to tractors with semi-trailers (observed in North America). <para/>
        /// Such restrictions are taken into account only in case of the truckType set to tractorTruck and the trailers count greater than 0 
        /// (for example &truckType=tractorTruck&trailersCount=1). <para/>
        /// The truck type is irrelevant in case of restrictions common for all types of trucks. 
        /// </summary>
        [Description("truckType")]
        public TruckType? TruckType { get; set; }

        /// <summary>
        /// Truck routing only, specifies number of trailers pulled by a vehicle. 
        /// The provided value must be between 0 and 4. Defaults to 0. 
        /// </summary>
        [Description("trailersCount")]
        public uint? TrailersCount { get; set; }

        /// <summary>
        /// Truck routing only, list of hazardous materials in the vehicle. 
        /// Please refer to the enumeration type HazardousGoodTypeType for available values. 
        /// </summary>
        [Description("shippedHazardousGoods")]
        public List<HazardousGoodType> ShippedHazardousGoods { get; set; }

        /// <summary>
        /// Truck routing only, vehicle weight including trailers and shipped goods, in tons. 
        /// The provided value must be between 0 and 1000. 
        /// </summary>
        [Description("limitedWeight")]
        public float? LimitedWeight { get; set; }

        /// <summary>
        /// Truck routing only, vehicle weight per axle in tons. The provided value must be between 0 and 1000.
        /// </summary>
        [Description("weightPerAxle")]
        public float? WeightPerAxle { get; set; }

        /// <summary>
        /// Truck routing only, vehicle height in meters. The provided value must be between 0 and 50.
        /// </summary>
        [Description("height")]
        public float? Height { get; set; }

        /// <summary>
        /// Truck routing only, vehicle width in meters. The provided value must be between 0 and 50.
        /// </summary>
        [Description("width")]
        public float? Width { get; set; }

        /// <summary>
        /// Truck routing only, vehicle length in meters. The provided value must be between 0 and 300.
        /// </summary>
        [Description("length")]
        public float? Length { get; set; }

        /// <summary>
        /// Truck routing only, specifies the tunnel category to restrict certain route links. 
        /// The route will pass only through tunnels of a less strict category.
        /// </summary>
        [Description("tunnelCategory")]
        public TunnelCategory? TunnelCategory { get; set; }

        /// <summary>
        /// Truck routing only, specifies the penalty type on violated truck restrictions. 
        /// Defaults to strict. Refer to the enumeration type TruckRestrictionPenaltyType for details on available values. 
        /// Note that the route computed with the penalty type soft will use links with a violated truck restriction if there is no alternative to avoid them. 
        /// The route violating truck restrictions is then indicated with dedicated route and maneuver notes in the response
        /// </summary>
        [Description("truckRestrictionPenalty")]
        public TruckRestrictionPenalty? TruckRestrictionPenalty { get; set; }

        /// <summary>
        /// If set to true, all shapes inside routing response will consist of 3 values instead of 2. Third value will be elevation. 
        /// If there are no elevation data available for given shape point, elevation will be interpolated from surrounding points. 
        /// In case there is no elevation data available for any of the shape points, elevation will be 0.0. If jsonattributes=32, elevation cannot be returned.
        /// </summary>
        [Description("returnElevation")]
        public bool? ReturnElevation { get; set; }

        /// <summary>
        /// Use the calculateroute resource to return a route between two waypoints. 
        /// The required parameters for this resource are app_id and app_code, two or more waypoints
        /// (waypoint0 and waypoint1, to waypointN) and mode (specifying how to calculate the route, 
        /// and for what mode of transport). For some modes departure or arrival (if applicable) is required. 
        /// This includes publicTransportTimeTable, publicTransport and all modes with enabled traffic. 
        /// Other parameters can be left unspecified.
        /// 
        /// <see href="https://developer.here.com/documentation/routing/topics/resource-calculate-route.html">API</see>
        /// </summary>
        public CalculateRoute() : base("route", "routing/7.2", "calculateroute") { }

        protected override void ValidateParameters()
        {
            if (RoutingMode == null) throw new ArgumentException("RoutingMode is mandatory.");

            if (Waypoints == null) throw new ArgumentException("Waypoints are mandatory.");

            if (AvoidTurns != null && RoutingMode.Transport != RoutingMode.TransportMode.Truck)
                throw new ArgumentException("Currently, truck routing is the only mode that supports the avoidTurns option.");

            if (Departure != null && Arrival != null) throw new ArgumentException("Specify either departure or arrival, not both.");

            if (ConsumptionModel != null && ConsumptionModel.Model == ConsumptionModel.ConsumptionModelType.Standard)
                if (CustomConsumptionDetails == null) throw new ArgumentException("When you specify the value standard, you must provide additional information with CustomConsumptionDetails");

            if (RoutingMode.Transport != RoutingMode.TransportMode.PublicTransport && RoutingMode.Transport != RoutingMode.TransportMode.PublicTransportTimeTable && LineAttributes != null)
                throw new ArgumentException("Public Transport Line Attributes are only available for Public Transport modes.");

            if (MaxNumberOfChanges != null && MaxNumberOfChanges > 10) throw new ArgumentException("Max Number of Changes should be an int between 0 and 10");

            if (WalkTimeMultiplier != null && (WalkTimeMultiplier < 0.01 || WalkTimeMultiplier > 100)) throw new ArgumentException("Walk Time Multiplier should be a float between 0.01 and 100");
            if (WalkSpeed != null && (WalkSpeed < 0.5 || WalkSpeed > 2)) throw new ArgumentException("Walk Speed should be a float between 0.5 and 2");
            if (WalkRadius != null && (WalkRadius < 0 || WalkRadius > 6000)) throw new ArgumentException("Walk Radius should be a float between 0 and 6000");

            if (RoutingMode.Transport != RoutingMode.TransportMode.Truck)
            {
                if (TruckType != null) throw new ArgumentException("TruckType attribute is only available for Truck routing mode");
                if (TrailersCount != null) throw new ArgumentException("TrailersCount attribute is only available for Truck routing mode");
                if (ShippedHazardousGoods != null) throw new ArgumentException("ShippedHazardousGoods attribute is only available for Truck routing mode");
                if (LimitedWeight != null) throw new ArgumentException("LimitedWeight attribute is only available for Truck routing mode");
                if (WeightPerAxle != null) throw new ArgumentException("WeightPerAxle attribute is only available for Truck routing mode");
                if (Height != null) throw new ArgumentException("Height attribute is only available for Truck routing mode");
                if (Width != null) throw new ArgumentException("Width attribute is only available for Truck routing mode");
                if (Length != null) throw new ArgumentException("Length attribute is only available for Truck routing mode");
                if (TunnelCategory != null) throw new ArgumentException("TunnelCategory attribute is only available for Truck routing mode");
                if (TruckRestrictionPenalty != null) throw new ArgumentException("TruckRestrictionPenalty attribute is only available for Truck routing mode");
            }

            if (TrailersCount != null && (TrailersCount > 4)) throw new ArgumentException("TrailersCount attribute should be an int between 0 and 4");
            if (LimitedWeight != null && (LimitedWeight < 0 || LimitedWeight > 1000)) throw new ArgumentException("LimitedWeight attribute should be a float between 0 and 1000");
            if (WeightPerAxle != null && (WeightPerAxle < 0 || WeightPerAxle > 1000)) throw new ArgumentException("WeightPerAxle attribute should be a float between 0 and 1000");
            if (Height != null && (Height < 0 || Height > 50)) throw new ArgumentException("Height attribute should be a float between 0 and 50");
            if (Width != null && (Width < 0 || Width > 50)) throw new ArgumentException("Width attribute should be a float between 0 and 50");
            if (Length != null && (Length < 0 || Length > 300)) throw new ArgumentException("Length attribute should be a float between 0 and 300");
            
        }

        protected override void AddSpecifiedParameters()
        {
            //Add IUrlType parameters
            AddIUrlParameter(RoutingMode);
            Waypoints.ForEach(wp => AddIUrlParameter(wp));
            if (Resolution != null) AddIUrlParameter(Resolution);
            if (JsonAttributes != null) AddIUrlParameter(JsonAttributes);
            if (GeneralizationTolerances != null) AddIUrlParameter(GeneralizationTolerances);
            if (VehicleType != null) AddIUrlParameter(VehicleType);
            if (ConsumptionModel != null) AddIUrlParameter(ConsumptionModel);
            if (CustomConsumptionDetails != null) AddIUrlParameter(CustomConsumptionDetails);

            //Other parameters
            if (RequestId != null) AddParameter(PropertyHelper.GetDescription(() => RequestId), RequestId);
            if (AvoidAreas != null) AddParameter(PropertyHelper.GetDescription(() => AvoidAreas), string.Join("!", AvoidAreas.Select(aa => aa.GetParameterValue()).ToArray()));
            if (AvoidLinks != null) AddParameter(PropertyHelper.GetDescription(() => AvoidLinks), string.Join(",", AvoidLinks.Select(al => al.GetParameterValue()).ToArray()));
            if (AvoidSeasonalClosures != null) AddParameter(PropertyHelper.GetDescription(() => AvoidSeasonalClosures), AvoidSeasonalClosures.ToString().ToLower());
            if (AvoidTurns != null) AddParameter(PropertyHelper.GetDescription(() => AvoidTurns), string.Join(",", AvoidTurns.Select(at => EnumHelper.GetDescription(at))));
            if (ExcludeZones != null) AddParameter(PropertyHelper.GetDescription(() => ExcludeZones), string.Join(",", ExcludeZones));
            if (ExcludeCountries != null) AddParameter(PropertyHelper.GetDescription(() => ExcludeCountries), string.Join(",", ExcludeCountries));
            if (Departure != null) AddParameter(PropertyHelper.GetDescription(() => Departure), ((DateTime) Departure).ToString("s"));
            if (Arrival != null) AddParameter(PropertyHelper.GetDescription(() => Arrival), ((DateTime)Arrival).ToString("s"));
            if (Alternatives != null) AddParameter(PropertyHelper.GetDescription(() => Alternatives), Alternatives.ToString());
            if (UnitSystem != null) AddParameter(PropertyHelper.GetDescription(() => UnitSystem), EnumHelper.GetDescription(UnitSystem));
            if (ViewBounds != null) AddParameter(PropertyHelper.GetDescription(() => ViewBounds), ViewBounds.GetParameterValue());
            if (InstructionFormat != null) AddParameter(PropertyHelper.GetDescription(() => InstructionFormat), EnumHelper.GetDescription(InstructionFormat));
            if (Language != null) AddParameter(PropertyHelper.GetDescription(() => Language), EnumHelper.GetDescription(Language));
            if (JsonCallback != null) AddParameter(PropertyHelper.GetDescription(() => JsonCallback), JsonCallback);
            if (Representation != null) AddParameter(PropertyHelper.GetDescription(() => Representation), EnumHelper.GetDescription(Representation));
            if (RouteAttributes != null) AddParameter(PropertyHelper.GetDescription(() => RouteAttributes), string.Join(",", RouteAttributes.Select(ra => EnumHelper.GetDescription(ra))));
            if (LegAttributes != null) AddParameter(PropertyHelper.GetDescription(() => LegAttributes), string.Join(",", LegAttributes.Select(la => EnumHelper.GetDescription(la))));
            if (ManeuverAttributes != null) AddParameter(PropertyHelper.GetDescription(() => ManeuverAttributes), string.Join(",", ManeuverAttributes.Select(ma => EnumHelper.GetDescription(ma))));
            if (LinkAttributes != null) AddParameter(PropertyHelper.GetDescription(() => LinkAttributes), string.Join(",", LinkAttributes.Select(la => EnumHelper.GetDescription(la))));
            if (LineAttributes != null) AddParameter(PropertyHelper.GetDescription(() => LineAttributes), string.Join(",", LineAttributes.Select(la => EnumHelper.GetDescription(la))));

            if (MaxNumberOfChanges != null) AddParameter(PropertyHelper.GetDescription(() => MaxNumberOfChanges), MaxNumberOfChanges.ToString());
            if (AvoidTransportTypes != null) AddParameter(PropertyHelper.GetDescription(() => AvoidTransportTypes), string.Join(",", AvoidTransportTypes.Select(tt => EnumHelper.GetDescription(tt))));

            if (WalkTimeMultiplier != null) AddParameter(PropertyHelper.GetDescription(() => WalkTimeMultiplier), WalkTimeMultiplier.ToString());
            if (WalkSpeed != null) AddParameter(PropertyHelper.GetDescription(() => WalkSpeed), WalkSpeed.ToString());
            if (WalkRadius != null) AddParameter(PropertyHelper.GetDescription(() => WalkRadius), WalkRadius.ToString());
            if (CombineChange != null) AddParameter(PropertyHelper.GetDescription(() => CombineChange), CombineChange.ToString().ToLower());
            if (TruckType != null) AddParameter(PropertyHelper.GetDescription(() => TruckType), EnumHelper.GetDescription(TruckType));
            if (TrailersCount != null) AddParameter(PropertyHelper.GetDescription(() => TrailersCount), TrailersCount.ToString());

            if (ShippedHazardousGoods != null) AddParameter(PropertyHelper.GetDescription(() => ShippedHazardousGoods), string.Join(",", ShippedHazardousGoods.Select(sg => EnumHelper.GetDescription(sg))));

            if (LimitedWeight != null) AddParameter(PropertyHelper.GetDescription(() => LimitedWeight), LimitedWeight.ToString());
            if (WeightPerAxle != null) AddParameter(PropertyHelper.GetDescription(() => WeightPerAxle), WeightPerAxle.ToString());
            if (Height != null) AddParameter(PropertyHelper.GetDescription(() => Height), Height.ToString());
            if (Width != null) AddParameter(PropertyHelper.GetDescription(() => Width), Width.ToString());
            if (Length != null) AddParameter(PropertyHelper.GetDescription(() => Length), Length.ToString());

            if (TunnelCategory != null) AddParameter(PropertyHelper.GetDescription(() => TunnelCategory), EnumHelper.GetDescription(TunnelCategory));
            if (TruckRestrictionPenalty != null) AddParameter(PropertyHelper.GetDescription(() => TruckRestrictionPenalty), EnumHelper.GetDescription(TruckRestrictionPenalty));

            if (ReturnElevation != null) AddParameter(PropertyHelper.GetDescription(() => ReturnElevation), ReturnElevation.ToString().ToLower());

        }
        
        public void GetAsync()
        {

        }


    }
}
