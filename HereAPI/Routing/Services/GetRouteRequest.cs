using HereAPI.Routing.Services.TypeResponse;
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
using static HereAPI.Routing.TypesRequest.JsonRepresentation;

namespace HereAPI.Routing.Services
{
    public class GetRouteRequest : RoutingRequest
    {
        #region Attributes

        // #### Implementing IRequestAttribute

        /// <summary>
        /// List of waypoints that define a route. The first element marks the start, the last the
        /// end point. Waypoints in between are interpreted as via points.
        /// </summary>
        public WaypointParameter[] Waypoints { get; set; }

        /// <summary>
        /// The routing mode determines how the route is calculated. When used in a getroute request,
        /// the type and mode of transport must be the same as in the original request(feature is
        /// ignored), whilst traffic mode can be changed.
        /// </summary>
        public RequestRoutingMode RoutingMode { get; set; }

        /// <summary>
        /// Specifies the desired tolerances for generalizations of the base route geometry.
        /// Tolerances are given in degrees of longitude or latitude on a spherical approximation of
        /// the Earth. One meter is approximately equal to 0:00001 degrees at typical latitudes.
        /// </summary>
        public GeneralizationTolerance GeneralizationTolerances { get; set; }

        /// <summary>
        /// Flag to control JSON output.
        /// </summary>
        public JsonRepresentation JsonAttributes { get; set; }

        //// #### Not Implementing IRequestAttribute

        /// <summary>
        /// Clients may pass in an arbitrary string to trace request processing through the system.
        /// The RequestId is mirrored in the MetaInfo element of the response structure.
        /// </summary>
        [Description("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Route identifier for which the detailed route information is being requested.
        /// </summary>
        [Required(ErrorMessage = "RouteId is mandatory")]
        [Description("routeId")]
        public string RouteId { get; set; }

        /// <summary>
        /// Time when travel is expected to start. Traffic speed and incidents are taken into account
        /// when calculating the route. Specify either departure or arrival, not both.
        /// </summary>
        [Description("departure")]
        public DateTime? Departure { get; set; }

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
        /// Define which attributes are included in the response as part of the data representation
        /// of the route legs. Defaults to maneuvers, waypoint, length, travelTime.
        /// </summary>
        [Description("legAttributes")]
        public RouteLegAttributeType[] LegAttributes { get; set; }

        /// <summary>
        /// If set to true, all shapes inside routing response will consist of 3 values instead of 2.
        /// Third value will be elevation. If there are no elevation data available for given shape
        /// point, elevation will be interpolated from surrounding points. In case there is no
        /// elevation data available for any of the shape points, elevation will be 0.0. If
        /// jsonattributes=32, elevation cannot be returned.
        /// </summary>
        [Description("returnElevation")]
        public bool? ReturnElevation { get; set; }

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Use the getroute resource to request a previously calculated route by providing the
        /// RouteId. As currently calculation of RouteId for Public Transport is not possible,
        /// getroute cannot be used for Public Transport.
        /// </summary>
        /// <param name="service"> </param>
        /// <param name="path">    </param>
        /// <param name="resource"></param>
        public GetRouteRequest() : base("route", "routing/7.2", "getroute") { }

        #endregion Constructor

        public override string[] ValidateConditionalAttributes()
        {
            var errors = new List<string>();

            if (RoutingMode.Mode == TransportModeType.PublicTransport && RoutingMode.Mode == TransportModeType.PublicTransportTimeTable)
                errors.Add("Get Route Request is not available for Public Transport modes.");

            return errors.ToArray();
        }

        protected override void AddSpecifiedAttributes()
        {
            AddAttribute(PropertyHelper.GetDescription(() => RouteId), RouteId);

            if (RoutingMode != null) AddAttribute(RoutingMode);
            if (Waypoints != null) foreach (var wp in Waypoints) { AddAttribute(wp); }
            if (JsonAttributes != null) AddAttribute(JsonAttributes);
            if (GeneralizationTolerances != null) AddAttribute(GeneralizationTolerances);

            AddAttribute(new JsonRepresentation(JsonAttribute.Include_TypeElement, JsonAttribute.UsePluralNamingForCollections, JsonAttribute.SupressJsonResponseObjectWrapper));

            if (RequestId != null) AddAttribute(PropertyHelper.GetDescription(() => RequestId), RequestId);
            if (Departure != null) AddAttribute(PropertyHelper.GetDescription(() => Departure), ((DateTime)Departure).ToString("s"));
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
            if (ReturnElevation != null) AddAttribute(PropertyHelper.GetDescription(() => ReturnElevation), ReturnElevation.ToString().ToLower());
        }

        #region Requests

        public Task<GetRouteResponse> GetAsync()
        {
            return base.GetAsync<GetRouteResponse>();
        }

        public GetRouteResponse Get()
        {
            return base.Get<GetRouteResponse>();
        }

        #endregion Requests
    }
}