using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// </summary>
    public enum RouteFeatureType
    {
        /// <summary>
        /// Identifier for toll roads
        /// <para/>
        /// </summary>
        [Description("tollroad")] Tollroad,

        /// <summary>
        /// Identifier for motorways
        /// <para/>
        /// </summary>
        [Description("motorway")] Motorway,

        /// <summary>
        /// Identifier for boat ferries
        /// <para/>
        /// </summary>
        [Description("boatFerry")] BoatFerry,

        /// <summary>
        /// Identifier for rail ferries
        /// <para/>
        /// </summary>
        [Description("railFerry")] RailFerry,

        /// <summary>
        /// Identifier for tunnels
        /// <para/>
        /// </summary>
        [Description("tunnel")] Tunnel,

        /// <summary>
        /// Identifier for dirt roads
        /// <para/>
        /// </summary>
        [Description("dirtRoad")] DirtRoad,

        /// <summary>
        /// Identifier for links through parks.This route feature is only applicable for pedestrian
        /// and bicycle routing.
        /// </summary>
        [Description("park")] Park
    }
}