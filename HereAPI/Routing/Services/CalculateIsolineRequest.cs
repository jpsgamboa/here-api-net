using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Routing.TypesRequest;
using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.TypeEnums;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static HereAPI.Routing.TypesEnum.EnumTypes;
using static HereAPI.Routing.TypesRequest.JsonRepresentation;

namespace HereAPI.Routing.Services
{
    public class CalculateIsolineRequest : RoutingRequest
    {


        #region Attributes

        // #### Required parameters

        /// <summary>
        /// The routing mode determines how the route is calculated.
        /// Types supported in isoline request: fastest, shortest. 
        /// TransportModes supported in isoline request: car, truck (only with type fastest), pedestrian. 
        /// </summary>
        [Required(ErrorMessage = "RoutingMode is mandatory")]
        public RequestRoutingMode RoutingMode { get; set; }

        /// <summary>
        /// Center of the isoline request. Isoline will cover all roads which can be reached from this point within given range. It cannot be used in combination with destination parameter.
        /// </summary>
        public WaypointParameter Start { get; set; }


        /// <summary>
        /// Center of the isoline request. Isoline will cover all roads from which this point can be reached within given range. It cannot be used in combination with start parameter.
        /// </summary>
        public WaypointParameter Destination { get; set; }

        /// <summary>
        /// Range of isoline. Several values can be specified.
        /// </summary>
        [Required(ErrorMessage = "At least one Range is mandatory")]
        [Description("range")]
        public int[] Ranges { get; set; }

        /// <summary>
        /// Specifies type of range. Possible values are distance, time, consumption. For distance the unit is meters. For time the unit is seconds. For consumption it is defined by consumption model
        /// </summary>
        [Required(ErrorMessage = "RangeType is mandatory")]
        [Description("rangeType")]
        public RangeType RangeType { get; set; }



        // #### Optional parameters


        /// <summary>
        /// Clients may pass in an arbitrary string to trace request processing through the system.
        /// The RequestId is mirrored in the MetaInfo element of the response structure.
        /// </summary>
        [Description("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Time when travel is expected to start. Traffic speed and incidents are taken into account
        /// when calculating the route. Can only be used along with attribute <see cref="Start"/>
        /// </summary>
        [Description("departure")]
        public DateTime? Departure { get; set; }

        /// <summary>
        /// Time when travel is expected to start. Traffic speed and incidents are taken into account
        /// when calculating the route. Can only be used along with attribute <see cref="Destination"/>
        /// </summary>
        [Description("arrival")]
        public DateTime? Arrival { get; set; }

        /// <summary>
        /// If set to true the isoline service will always return single polygon, instead of creating a separate polygon for each ferry separated island. Default value is false. 
        /// </summary>
        [Description("singleComponent")]
        public bool? SingleComponent { get; set; }

        /// <summary>
        /// Allows to specify level of detail needed for the isoline polygon. Unit is meters per pixel. Higher resolution may cause increased response time from the service. 
        /// </summary>
        [Description("resolution")]
        public int? Resolution { get; set; }


        /// <summary>
        /// Allows to limit amount of points in the returned isoline. If isoline consists of multiple components, sum of points from all components is considered. Each component will have at least 2 points, so it is possible that more points than maxpoints value will be returned. This is in case when 2 * number of components is higher than maxpoints. Enlarging number of maxpoints may cause increased response time from the service. 
        /// </summary>
        [Description("maxPoints")]
        public int? MaxPoints { get; set; }

        /// <summary>
        /// Allows to reduce the quality of the isoline in favor of the response time. Allowed values are 1, 2, 3. Default value is 1 and it is the best quality. 
        /// </summary>
        [Description("quality")]
        public int? Quality { get; set; }

        /// <summary>
        /// Flag to control JSON output.
        /// </summary>
        public JsonRepresentation JsonAttributes { get; set; }

        /// <summary>
        /// Name of a user-defined function used to wrap the JSON response.
        /// </summary>
        [Description("jsonCallback")]
        public string JsonCallback { get; set; }


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


        #endregion

        #region Constructor

        /// <summary>
        ///Use the calculateisoline resource to request a polyline that connects the end points of all routes leaving from one defined center with either a specified length or a specified travel time. The required parameters for this resource are app_id, app_code, start or destination, range, rangetype and mode (specifying how to calculate the route, and for what mode of transport). Other parameters can be left unspecified.
        /// <see href="https://developer.here.com/documentation/routing/topics/resource-calculate-route.html">API</see>
        /// </summary>
        public CalculateIsolineRequest() : base("route", "routing/7.2", "calculateisoline") { }

        #endregion

        public override string[] ValidateConditionalAttributes()
        {
            var errors = new List<string>();

            if (Start != null && Destination != null) errors.Add("Specify either Start or Destination, not both.");

            if (RoutingMode.Mode != TransportModeType.Car && RoutingMode.Mode != TransportModeType.Truck && RoutingMode.Mode != TransportModeType.Pedestrian)
                errors.Add("Only the modes Car, Truck and Pedestrian are available.");

            if (RoutingMode.Mode == TransportModeType.Truck && RoutingMode.Type != RoutingType.Fastest)
                errors.Add("For the mode Truck, only the type 'fastest' can be used.");

            if (RangeType == RangeType.Consumption && ConsumptionModel == null)
                errors.Add("ConsumptionModel can't be null for RangeType = Consumption.");

            if (Departure != null && Arrival != null) errors.Add("Specify either departure or arrival, not both.");

            if (Departure != null && Start == null) errors.Add("Departure needs to be specified along with Start mode.");
            if (Arrival != null && Destination == null) errors.Add("Arrival needs to be specified along with Destination mode.");
     
            if (ConsumptionModel != null && ConsumptionModel.Model == ConsumptionModel.ConsumptionModelType.Standard)
                if (CustomConsumptionDetails == null) errors.Add("When you specify the value standard, you must provide additional information with CustomConsumptionDetails");

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
            }
            return errors.ToArray();
        }

        protected override void AddSpecifiedAttributes()
        {
            AddAttribute(RoutingMode);

            if (Start != null) AddAttribute(Start);
            if (Destination != null) AddAttribute(Destination);

            AddAttribute(PropertyHelper.GetDescription(() => Ranges), string.Join(",", Ranges));
            AddAttribute(PropertyHelper.GetDescription(() => RangeType), EnumHelper.GetDescription(RangeType));

            if (JsonAttributes != null)
                AddAttribute(JsonAttributes);
            else
                AddAttribute(new JsonRepresentation(JsonAttribute.Include_TypeElement, JsonAttribute.UsePluralNamingForCollections, JsonAttribute.SupressJsonResponseObjectWrapper));


            if (ConsumptionModel != null) AddAttribute(ConsumptionModel);
            if (CustomConsumptionDetails != null) AddAttribute(CustomConsumptionDetails);

            if (RequestId != null) AddAttribute(PropertyHelper.GetDescription(() => RequestId), RequestId);

            if (SingleComponent != null) AddAttribute(PropertyHelper.GetDescription(() => SingleComponent), SingleComponent.ToString().ToLower());
            if (Resolution != null) AddAttribute(PropertyHelper.GetDescription(() => Resolution), Resolution.ToString());
            if (MaxPoints != null) AddAttribute(PropertyHelper.GetDescription(() => MaxPoints), MaxPoints.ToString());
            if (Quality != null) AddAttribute(PropertyHelper.GetDescription(() => Quality), Quality.ToString());


            if (Departure != null) AddAttribute(PropertyHelper.GetDescription(() => Departure), ((DateTime)Departure).ToString("s"));
            if (Arrival != null) AddAttribute(PropertyHelper.GetDescription(() => Arrival), ((DateTime)Arrival).ToString("s"));

            if (JsonCallback != null) AddAttribute(PropertyHelper.GetDescription(() => JsonCallback), JsonCallback);

            if (TruckType != null) AddAttribute(PropertyHelper.GetDescription(() => TruckType), EnumHelper.GetDescription(TruckType));
            if (TrailersCount != null) AddAttribute(PropertyHelper.GetDescription(() => TrailersCount), TrailersCount.ToString());

            if (ShippedHazardousGoods != null) AddAttribute(PropertyHelper.GetDescription(() => ShippedHazardousGoods), string.Join(",", ShippedHazardousGoods.Select(sg => EnumHelper.GetDescription(sg))));

            if (LimitedWeight != null) AddAttribute(PropertyHelper.GetDescription(() => LimitedWeight), LimitedWeight.Value.ToString(HereAPISession.Culture));
            if (WeightPerAxle != null) AddAttribute(PropertyHelper.GetDescription(() => WeightPerAxle), WeightPerAxle.Value.ToString(HereAPISession.Culture));
            if (Height != null) AddAttribute(PropertyHelper.GetDescription(() => Height), Height.Value.ToString(HereAPISession.Culture));
            if (Width != null) AddAttribute(PropertyHelper.GetDescription(() => Width), Width.Value.ToString(HereAPISession.Culture));
            if (Length != null) AddAttribute(PropertyHelper.GetDescription(() => Length), Length.Value.ToString(HereAPISession.Culture));

            if (TunnelCategory != null) AddAttribute(PropertyHelper.GetDescription(() => TunnelCategory), EnumHelper.GetDescription(TunnelCategory));
        }

        #region Requests

        public Task<CalculateIsolineResponse> GetAsync()
        {
            return base.GetAsync<CalculateIsolineResponse>();
        }

        public CalculateIsolineResponse Get()
        {
            return base.Get<CalculateIsolineResponse>();
        }

        #endregion

    }
}
