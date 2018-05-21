using HereAPI.Routing.Services.TypeResponse;
using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.TypeEnums;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static HereAPI.Routing.TypesEnum.EnumTypes;
using static HereAPI.Routing.TypesRequest.JsonRepresentation;

namespace HereAPI.Routing.Services
{
    public class CalculateRouteRequest : RoutingRequest
    {

        #region Attributes

        // #### Required parameters

        /// <summary>
        /// The routing mode determines how the route is calculated.
        /// </summary>
        [Required(ErrorMessage = "RoutingMode is mandatory")]
        public RequestRoutingMode RoutingMode { get; set; }

        /// <summary>
        /// List of waypoints that define a route. The first element marks the start, the last the
        /// end point. Waypoints in between are interpreted as via points.
        /// </summary>
        [Required(ErrorMessage = "Waypoints are mandatory")]
        public WaypointParameter[] Waypoints { get; set; }

        // #### Optional parameters

        // #### Implementing IRequestAttribute
        /// <summary>
        /// Specifies the resolution of the view and a possible snap resolution in meters per pixel
        /// in the response. You must specify a whole, positive integer.
        /// <para/>
        /// If you specify only one value, then this value defines the view resolution only.
        /// <para/>
        /// You can use snap resolution to adjust waypoint links to the resolution of the client display.
        /// </summary>
        public Resolution Resolution { get; set; }

        /// <summary>
        /// Flag to control JSON output.
        /// </summary>
        public JsonRepresentation JsonAttributes { get; set; }

        /// <summary>
        /// Specifies the desired tolerances for generalizations of the base route geometry.
        /// Tolerances are given in degrees of longitude or latitude on a spherical approximation of
        /// the Earth. One meter is approximately equal to 0:00001 degrees at typical latitudes.
        /// </summary>
        public GeneralizationTolerance GeneralizationTolerances { get; set; }

        /// <summary>
        /// Specifies type of vehicle engine and average fuel consumption, which can be used to
        /// estimate CO2 emission for the route summary
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// If you request information on consumption, you must provide a consumption model. The
        /// possible values are default and standard. When you specify the value standard, you must
        /// provide additional information in the query parameter customconsumptiondetails
        /// </summary>
        public ConsumptionModel ConsumptionModel { get; set; }

        /// <summary>
        /// Provides vehicle specific information for use in the consumption model. This information
        /// can include such things as the amount of energy consumed while travelling at a given speed.
        /// </summary>
        public ConsumptionModel.CustomConsumptionDetails CustomConsumptionDetails { get; set; }

        //// #### Not Implementing IRequestAttribute

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
        public GeoBoundingBox[] AvoidAreas { get; set; }

        /// <summary>
        /// Links which the route must not cross.
        /// </summary>
        [Description("avoidLinks")]
        public LinkId[] AvoidLinks { get; set; }

        /// <summary>
        /// The optional avoid seasonal closures boolean flag can be specified to avoid usage of
        /// seasonally closed links
        /// </summary>
        [Description("avoidSeasonalClosures")]
        public bool? AvoidSeasonalClosures { get; set; }

        /// <summary>
        /// List of turn types that the route should avoid. Defaults to empty list.
        /// Note: Currently, truck routing is the only mode that supports the avoidTurns option and
        /// only complex intersections can have the turn type difficult. The route always avoids
        /// trivial u-turns, also when you don't specify the avoidTurns parameter.
        /// </summary>
        [Description("avoidTurns")]
        public TurnType[] AvoidTurns { get; set; }

        /// <summary>
        /// Identifiers of zones which the route must not cross at any circumstances.
        /// </summary>
        [Description("excludeZones")]
        public ulong[] ExcludeZones { get; set; }

        /// <summary>
        /// Countries that must be excluded from route calculation.
        /// <para/>
        /// Country code according to ISO 3166-1-alpha-3
        /// </summary>
        [Description("excludeCountries")]
        public String[] ExcludeCountries { get; set; }

        /// <summary>
        /// Time when travel is expected to start. Traffic speed and incidents are taken into account
        /// when calculating the route. Specify either departure or arrival, not both.
        /// </summary>
        [Description("departure")]
        public DateTime? Departure { get; set; }

        /// <summary>
        /// Time when travel is expected to end. Specify either departure or arrival, not both.
        /// </summary>
        [Description("arrival")]
        public DateTime? Arrival { get; set; }

        /// <summary>
        /// Maximum number of alternative routes that will be calculated and returned. Alternative
        /// routes can be unavailable, thus they are not guaranteed to be returned. If at least one
        /// via point is used in a route request, returning alternative routes is not supported. 0
        /// stands for "no alternative routes", i.e. only best route is returned.
        /// </summary>
        [Description("alternatives")]
        public uint? Alternatives { get; set; }

        /// <summary>
        /// Defines the measurement system used in instruction text. When imperial is selected, units
        /// used are based on the language specified in the request. Defaults to metric when not specified.
        /// </summary>
        [Description("metricSystem")]
        public UnitSystemType? UnitSystem { get; set; }

        /// <summary>
        /// If the view bounds are given in the request then only route shape points which fit into
        /// these bounds will be returned. The route shape beyond the view bounds is reduced to the
        /// points which are referenced by links, legs or maneuvers. A common use case for this is
        /// the drag and drop scenario where the client is only interested in a rough visual update
        /// of the route in the currently visible bounds.
        /// </summary>
        [Description("viewBounds")]
        public GeoBoundingBox ViewBounds { get; set; }

        /// <summary>
        /// Defines the representation format of the maneuver's instruction text.
        /// </summary>
        [Description("instructionFormat")]
        public InstructionFormatType? InstructionFormat { get; set; }

        /// <summary>
        /// A list of languages for all textual information, the first supported language is used. If
        /// there are no matching supported languages the response is an error. Defaults to en-us.
        /// </summary>
        [Description("language")]
        public LanguageCodeType? Language { get; set; }

        /// <summary>
        /// Name of a user-defined function used to wrap the JSON response.
        /// </summary>
        [Description("jsonCallback")]
        public string JsonCallback { get; set; }

        /// <summary>
        /// Define which elements are included in the response as part of the data representation of
        /// the route.
        /// </summary>
        [Description("representation")]
        public RouteRepresentationModeType? Representation { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation
        /// of the route. Defaults to waypoints, summary, legs and additionally lines if
        /// publicTransport or publicTransportTimeTable mode is used.
        /// </summary>
        [Description("routeAttributes")]
        public RouteAttributeType[] RouteAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation
        /// of the route legs. Defaults to maneuvers, waypoint, length, travelTime.
        /// </summary>
        [Description("legAttributes")]
        public RouteLegAttributeType[] LegAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation
        /// of the route maneuvers. Defaults to position, length, travelTime.
        /// </summary>
        [Description("maneuverAttributes")]
        public ManeuverAttributeType[] ManeuverAttributes { get; set; }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation
        /// of the route links. Defaults to shape, speedLimit.
        /// </summary>
        [Description("linkAttributes")]
        public RouteLinkAttributeType[] LinkAttributes { get; set; }

        /// <summary>
        /// Sequence of attribute keys of the fields that are included in public transport line
        /// elements. If not specified, defaults to lineForeground, lineBackground.
        /// </summary>
        [Description("lineAttributes")]
        public PublicTransportLineAttributeType[] LineAttributes { get; set; }

        /// <summary>
        /// Restricts number of changes in a public transport route to a given value. The parameter
        /// does not filter resulting alternatives. Instead, it affects route calculation so that
        /// only routes containing at most the given number of changes are considered. The provided
        /// value must be between 0 and 10.
        /// </summary>
        [Description("maxNumberOfChanges")]
        public uint? MaxNumberOfChanges { get; set; }

        /// <summary>
        /// Public transport types that shall not be included in the response route.
        /// </summary>
        [Description("avoidTransportTypes")]
        public PublicTransportType[] AvoidTransportTypes { get; set; }

        /// <summary>
        /// Allows to prefer or avoid public transport routes with longer walking distances. A value
        /// &gt; 1.0 means a slower walking speed and will prefer routes with less walking distance.
        /// The provided value must be between 0.01 and 100.
        /// </summary>
        [Range(0.01, 100, ErrorMessage = "WalkTimeMultiplier must be between 0.01 and 100")]
        [Description("walkTimeMultiplier")]
        public float? WalkTimeMultiplier { get; set; }

        /// <summary>
        /// Specifies speed which will be used by a service as a walking speed for pedestrian routing
        /// (meters per second). This parameter affects pedestrian, publicTransport and
        /// publicTransportTimetable modes. The provided value must be between 0.5 and 2.
        /// </summary>
        [Range(0.5, 2, ErrorMessage = "WalkSpeed must be between 0.5 and 2")]
        [Description("walkSpeed")]
        public float? WalkSpeed { get; set; }

        /// <summary>
        /// Allows the user to specify a maximum distance to the start and end stations of a public
        /// transit route. Only valid for publicTransport and publicTransportTimetable routes. The
        /// provided value must be between 0 and 6000.
        /// </summary>
        [Range(0, 6000, ErrorMessage = "WalkRadius must be between 0 and 6000")]
        [Description("walkRadius")]
        public float? WalkRadius { get; set; }

        /// <summary>
        /// Enables the change maneuver in the route response, which indicates a public transit line
        /// change. In the absence of this maneuver, each line change is represented with a pair of
        /// subsequent enter and leave maneuvers. We recommend enabling combineChange behavior
        /// wherever possible, to simplify client-side development.
        /// </summary>
        [Description("combineChange")]
        public bool? CombineChange { get; set; }

        /// <summary> Truck routing only, specifies the vehicle type. Defaults to truck. <para/>
        /// Note: Relevant for restrictions that apply exclusively to tractors with semi-trailers
        ///       (observed in North America). <para/> Such restrictions are taken into account only
        /// in case of the truckType set to tractorTruck and the trailers count greater than 0 (for
        /// example &truckType=tractorTruck&trailersCount=1). <para/> The truck type is irrelevant in
        /// case of restrictions common for all types of trucks. </summary>
        [Description("truckType")]
        public TruckType? TruckType { get; set; }

        /// <summary>
        /// Truck routing only, specifies number of trailers pulled by a vehicle. The provided value
        /// must be between 0 and 4. Defaults to 0.
        /// </summary>
        [Range(0, 4, ErrorMessage = "TrailersCount must be between 0 and 4")]
        [Description("trailersCount")]
        public uint? TrailersCount { get; set; }

        /// <summary>
        /// Truck routing only, list of hazardous materials in the vehicle. Please refer to the
        /// enumeration type HazardousGoodTypeType for available values.
        /// </summary>
        [Description("shippedHazardousGoods")]
        public HazardousGoodType[] ShippedHazardousGoods { get; set; }

        /// <summary>
        /// Truck routing only, vehicle weight including trailers and shipped goods, in tons. The
        /// provided value must be between 0 and 1000.
        /// </summary>
        [Range(0, 1000, ErrorMessage = "LimitedWeight must be between 0 and 1000")]
        [Description("limitedWeight")]
        public float? LimitedWeight { get; set; }

        /// <summary>
        /// Truck routing only, vehicle weight per axle in tons. The provided value must be between 0
        /// and 1000.
        /// </summary>
        [Range(0, 1000, ErrorMessage = "WeightPerAxle must be between 0 and 1000")]
        [Description("weightPerAxle")]
        public float? WeightPerAxle { get; set; }

        /// <summary>
        /// Truck routing only, vehicle height in meters. The provided value must be between 0 and 50.
        /// </summary>
        [Range(0, 50, ErrorMessage = "Height must be between 0 and 50")]
        [Description("height")]
        public float? Height { get; set; }

        /// <summary>
        /// Truck routing only, vehicle width in meters. The provided value must be between 0 and 50.
        /// </summary>
        [Range(0, 50, ErrorMessage = "Width must be between 0 and 50")]
        [Description("width")]
        public float? Width { get; set; }

        /// <summary>
        /// Truck routing only, vehicle length in meters. The provided value must be between 0 and 300.
        /// </summary>
        [Range(0, 300, ErrorMessage = "Length must be between 0 and 300")]
        [Description("length")]
        public float? Length { get; set; }

        /// <summary>
        /// Truck routing only, specifies the tunnel category to restrict certain route links. The
        /// route will pass only through tunnels of a less strict category.
        /// </summary>
        [Description("tunnelCategory")]
        public TunnelCategoryType? TunnelCategory { get; set; }

        /// <summary>
        /// Truck routing only, specifies the penalty type on violated truck restrictions. Defaults
        /// to strict. Refer to the enumeration type TruckRestrictionPenaltyType for details on
        /// available values. Note that the route computed with the penalty type soft will use links
        /// with a violated truck restriction if there is no alternative to avoid them. The route
        /// violating truck restrictions is then indicated with dedicated route and maneuver notes in
        /// the response
        /// </summary>
        [Description("truckRestrictionPenalty")]
        public TruckRestrictionPenaltyType? TruckRestrictionPenalty { get; set; }

        /// <summary>
        /// If set to true, all shapes inside routing response will consist of 3 values instead of 2.
        /// Third value will be elevation. If there are no elevation data available for given shape
        /// point, elevation will be interpolated from surrounding points. In case there is no
        /// elevation data available for any of the shape points, elevation will be 0.0. If
        /// jsonattributes=32, elevation cannot be returned.
        /// </summary>
        [Description("returnElevation")]
        public bool? ReturnElevation { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Use the calculateroute resource to return a route between two waypoints. The required
        /// parameters for this resource are app_id and app_code, two or more waypoints (waypoint0
        /// and waypoint1, to waypointN) and mode (specifying how to calculate the route, and for
        /// what mode of transport). For some modes departure or arrival (if applicable) is required.
        /// This includes publicTransportTimeTable, publicTransport and all modes with enabled
        /// traffic. Other parameters can be left unspecified.
        ///
        /// <see href="https://developer.here.com/documentation/routing/topics/resource-calculate-route.html">API</see>
        /// </summary>
        public CalculateRouteRequest() : base("route", "routing/7.2", "calculateroute") { }

        #endregion

        public override string[] ValidateConditionalAttributes()
        {
            var errors = new List<string>();

            if (AvoidTurns != null && RoutingMode.Mode != TransportModeType.Truck)
                errors.Add("Currently, truck routing is the only mode that supports the avoidTurns option.");

            if (Departure != null && Arrival != null) errors.Add("Specify either departure or arrival, not both.");

            if (ConsumptionModel != null && ConsumptionModel.Model == ConsumptionModel.ConsumptionModelType.Standard)
                if (CustomConsumptionDetails == null) errors.Add("When you specify the value standard, you must provide additional information with CustomConsumptionDetails");

            if (RoutingMode.Mode != TransportModeType.PublicTransport && RoutingMode.Mode != TransportModeType.PublicTransportTimeTable && LineAttributes != null)
                errors.Add("Public Transport Line Attributes are only available for Public Transport modes.");

            if (MaxNumberOfChanges != null && MaxNumberOfChanges > 10) errors.Add("Max Number of Changes should be an int between 0 and 10");

            if (RoutingMode.Mode != TransportModeType.Truck)
            {
                if (TruckType != null) errors.Add("TruckType attribute is only available for Truck routing mode");
                if (TrailersCount != null) errors.Add("TrailersCount attribute is only available for Truck routing mode");
                if (ShippedHazardousGoods != null) errors.Add("ShippedHazardousGoods attribute is only available for Truck routing mode");
                if (LimitedWeight != null) errors.Add("LimitedWeight attribute is only available for Truck routing mode");
                if (WeightPerAxle != null) errors.Add("WeightPerAxle attribute is only available for Truck routing mode");
                if (Height != null) errors.Add("Height attribute is only available for Truck routing mode");
                if (Width != null) errors.Add("Width attribute is only available for Truck routing mode");
                if (Length != null) errors.Add("Length attribute is only available for Truck routing mode");
                if (TunnelCategory != null) errors.Add("TunnelCategory attribute is only available for Truck routing mode");
                if (TruckRestrictionPenalty != null) errors.Add("TruckRestrictionPenalty attribute is only available for Truck routing mode");
            }
            return errors.ToArray();
        }

        protected override void AddSpecifiedAttributes()
        {
            //Add IRequestAttribute types
            AddAttribute(RoutingMode);
            foreach (var wp in Waypoints) { AddAttribute(wp); }
            if (Resolution != null) AddAttribute(Resolution);
            if (JsonAttributes != null) AddAttribute(JsonAttributes);
            if (GeneralizationTolerances != null) AddAttribute(GeneralizationTolerances);
            if (VehicleType != null) AddAttribute(VehicleType);
            if (ConsumptionModel != null) AddAttribute(ConsumptionModel);
            if (CustomConsumptionDetails != null) AddAttribute(CustomConsumptionDetails);

            AddAttribute(new JsonRepresentation(JsonAttribute.Include_TypeElement, JsonAttribute.UsePluralNamingForCollections, JsonAttribute.SupressJsonResponseObjectWrapper));

            //Other parameters
            if (RequestId != null) AddAttribute(PropertyHelper.GetDescription(() => RequestId), RequestId);
            if (AvoidAreas != null) AddAttribute(PropertyHelper.GetDescription(() => AvoidAreas), string.Join("!", AvoidAreas.Select(aa => aa.GetAttributeValue()).ToArray()));
            if (AvoidLinks != null) AddAttribute(PropertyHelper.GetDescription(() => AvoidLinks), string.Join(",", AvoidLinks.Select(al => al.GetAttributeValue()).ToArray()));
            if (AvoidSeasonalClosures != null) AddAttribute(PropertyHelper.GetDescription(() => AvoidSeasonalClosures), AvoidSeasonalClosures.ToString().ToLower());
            if (AvoidTurns != null) AddAttribute(PropertyHelper.GetDescription(() => AvoidTurns), string.Join(",", AvoidTurns.Select(at => EnumHelper.GetDescription(at))));
            if (ExcludeZones != null) AddAttribute(PropertyHelper.GetDescription(() => ExcludeZones), string.Join(",", ExcludeZones));
            if (ExcludeCountries != null) AddAttribute(PropertyHelper.GetDescription(() => ExcludeCountries), string.Join(",", ExcludeCountries));
            if (Departure != null) AddAttribute(PropertyHelper.GetDescription(() => Departure), ((DateTime)Departure).ToString("s"));
            if (Arrival != null) AddAttribute(PropertyHelper.GetDescription(() => Arrival), ((DateTime)Arrival).ToString("s"));
            if (Alternatives != null) AddAttribute(PropertyHelper.GetDescription(() => Alternatives), Alternatives.ToString());
            if (UnitSystem != null) AddAttribute(PropertyHelper.GetDescription(() => UnitSystem), EnumHelper.GetDescription(UnitSystem));
            if (ViewBounds != null) AddAttribute(PropertyHelper.GetDescription(() => ViewBounds), ViewBounds.GetAttributeValue());
            if (InstructionFormat != null) AddAttribute(PropertyHelper.GetDescription(() => InstructionFormat), EnumHelper.GetDescription(InstructionFormat));
            if (Language != null) AddAttribute(PropertyHelper.GetDescription(() => Language), EnumHelper.GetDescription(Language));
            if (JsonCallback != null) AddAttribute(PropertyHelper.GetDescription(() => JsonCallback), JsonCallback);
            if (Representation != null) AddAttribute(PropertyHelper.GetDescription(() => Representation), EnumHelper.GetDescription(Representation));
            if (RouteAttributes != null) AddAttribute(PropertyHelper.GetDescription(() => RouteAttributes), string.Join(",", RouteAttributes.Select(ra => EnumHelper.GetDescription(ra))));
            if (LegAttributes != null) AddAttribute(PropertyHelper.GetDescription(() => LegAttributes), string.Join(",", LegAttributes.Select(la => EnumHelper.GetDescription(la))));
            if (ManeuverAttributes != null) AddAttribute(PropertyHelper.GetDescription(() => ManeuverAttributes), string.Join(",", ManeuverAttributes.Select(ma => EnumHelper.GetDescription(ma))));
            if (LinkAttributes != null) AddAttribute(PropertyHelper.GetDescription(() => LinkAttributes), string.Join(",", LinkAttributes.Select(la => EnumHelper.GetDescription(la))));
            if (LineAttributes != null) AddAttribute(PropertyHelper.GetDescription(() => LineAttributes), string.Join(",", LineAttributes.Select(la => EnumHelper.GetDescription(la))));

            if (MaxNumberOfChanges != null) AddAttribute(PropertyHelper.GetDescription(() => MaxNumberOfChanges), MaxNumberOfChanges.ToString());
            if (AvoidTransportTypes != null) AddAttribute(PropertyHelper.GetDescription(() => AvoidTransportTypes), string.Join(",", AvoidTransportTypes.Select(tt => EnumHelper.GetDescription(tt))));

            if (WalkTimeMultiplier != null) AddAttribute(PropertyHelper.GetDescription(() => WalkTimeMultiplier), WalkTimeMultiplier.Value.ToString(HereAPISession.Culture));
            if (WalkSpeed != null) AddAttribute(PropertyHelper.GetDescription(() => WalkSpeed), WalkSpeed.Value.ToString(HereAPISession.Culture));
            if (WalkRadius != null) AddAttribute(PropertyHelper.GetDescription(() => WalkRadius), WalkRadius.Value.ToString(HereAPISession.Culture));
            if (CombineChange != null) AddAttribute(PropertyHelper.GetDescription(() => CombineChange), CombineChange.ToString().ToLower());
            if (TruckType != null) AddAttribute(PropertyHelper.GetDescription(() => TruckType), EnumHelper.GetDescription(TruckType));
            if (TrailersCount != null) AddAttribute(PropertyHelper.GetDescription(() => TrailersCount), TrailersCount.ToString());

            if (ShippedHazardousGoods != null) AddAttribute(PropertyHelper.GetDescription(() => ShippedHazardousGoods), string.Join(",", ShippedHazardousGoods.Select(sg => EnumHelper.GetDescription(sg))));

            if (LimitedWeight != null) AddAttribute(PropertyHelper.GetDescription(() => LimitedWeight), LimitedWeight.Value.ToString(HereAPISession.Culture));
            if (WeightPerAxle != null) AddAttribute(PropertyHelper.GetDescription(() => WeightPerAxle), WeightPerAxle.Value.ToString(HereAPISession.Culture));
            if (Height != null) AddAttribute(PropertyHelper.GetDescription(() => Height), Height.Value.ToString(HereAPISession.Culture));
            if (Width != null) AddAttribute(PropertyHelper.GetDescription(() => Width), Width.Value.ToString(HereAPISession.Culture));
            if (Length != null) AddAttribute(PropertyHelper.GetDescription(() => Length), Length.Value.ToString(HereAPISession.Culture));

            if (TunnelCategory != null) AddAttribute(PropertyHelper.GetDescription(() => TunnelCategory), EnumHelper.GetDescription(TunnelCategory));
            if (TruckRestrictionPenalty != null) AddAttribute(PropertyHelper.GetDescription(() => TruckRestrictionPenalty), EnumHelper.GetDescription(TruckRestrictionPenalty));

            if (ReturnElevation != null) AddAttribute(PropertyHelper.GetDescription(() => ReturnElevation), ReturnElevation.ToString().ToLower());
        }

        #region Requests

        public Task<CalculateRouteResponse> GetAsync()
        {
            return base.GetAsync<CalculateRouteResponse>();
        }

        public CalculateRouteResponse Get()
        {
            return base.Get<CalculateRouteResponse>();
        }

        #endregion
    }
}