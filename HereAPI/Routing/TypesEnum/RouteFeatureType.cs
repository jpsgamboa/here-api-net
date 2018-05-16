using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
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
}
