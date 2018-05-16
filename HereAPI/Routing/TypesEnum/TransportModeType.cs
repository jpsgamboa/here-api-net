using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

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
    public enum TransportModeType
    {
        [Description("car")] Car,
        [Description("carHOV")] CarHOV,
        [Description("pedestrian")] Pedestrian,
        [Description("publicTransport")] PublicTransport,
        [Description("publicTransportTimeTable")] PublicTransportTimeTable,
        [Description("truck")] Truck,
        [Description("bicycle")] Bicycle
    }
}
