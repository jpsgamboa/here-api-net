using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Depending on the transport mode special constraints, speed attributes and weights are taken into account during route calculation. <para/>
    /// Note: When you specify a mode, you can choose from four speed profiles: car, light truck, medium truck, or heavy truck. Speeds used in route calculation depend on the chosen mode. The heavy truck profile is only used if you specify a value for the parameter limitedweight greater than 18 tons. The medium truck profile is only used if you specify a value for the parameter limitedweight greater than 7.5 tons and less than or equal to 18 tons. The light truck profile is only used if you specify a value for the parameter limitedweight less than or equal to 7.5 tons. The car speed profile is used if truck is not specified in the routing mode.
    /// </summary>
    public enum TransportModeType
    {
        /// <summary>
        /// Route calculation for cars.
        /// </summary>
        [Description("car")] Car,

        /// <summary>
        /// Route calculation for HOV(high-occupancy vehicle) cars.
        /// </summary>
        [Description("carHOV")] CarHOV,

        /// <summary>
        /// Route calculation for a pedestrian.As one effect, maneuvers will be optimized for walking, i.e.segments will consider actions relevant for pedestrians and maneuver instructions will contain texts suitable for a walking person. This mode disregards any traffic information.
        /// </summary>
        [Description("pedestrian")] Pedestrian,

        /// <summary>
        /// Route calculation using public transport lines and walking parts to get to stations.It is based on static map data, so the results are not aligned with officially published timetable.
        /// </summary>
        [Description("publicTransport")] PublicTransport,

        /// <summary>
        /// Route calculation using public transport lines and walking parts to get to stations.This mode uses additional officially published timetable information to provide most precise routes and times.In case the timetable data is unavailable, the service will use estimated results based on static map data(same as from publicTransport mode).
        /// </summary>
        [Description("publicTransportTimeTable")] PublicTransportTimeTable,

        /// <summary>
        /// Route calculation for trucks.This mode considers truck limitations on links and uses different speed assumptions when calculating the route.
        /// </summary>
        [Description("truck")] Truck,

        /// <summary>
        /// Route calculation for bicycles.This mode uses the pedestrian road network, but uses different speeds based on each road's suitability for cycling. Pedestrian roads that are also open for cars in the travel direction are considered open for cycling, as are pedestrian roads located in parks. These roads use full bicycle speed for routing. Other pedestrian roads, including travelling the wrong way down one-way streets, are considered at the pedestrian walking speed, as it is assumed the bicycle must be pushed.<para/>
        /// </summary>
        [Description("bicycle")] Bicycle
    }
}
