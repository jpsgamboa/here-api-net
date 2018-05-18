using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary> Relevant for restrictions that apply exclusively to tractors with semi-trailers
    /// (observed in North America). Such restrictions are taken into account only in case of the
    /// truckType set to tractorTruck and the trailers count greater than 0 (for example
    /// &truckType=tractorTruck&trailersCount=1). The truck type is irrelevant in case of
    /// restrictions common for all types of trucks. </summary>
    public enum TruckType
    {
        [Description("truck")] Truck,
        [Description("tractorTruck")] TractorTruck
    }
}