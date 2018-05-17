using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Defines a list of special characteristics that may apply to a link. 
    /// </summary>
    public enum RouteLinkFlagType
    {

        /// <summary>
        /// Link Can Only Be Traversed By Using A Boat Ferry
        /// </summary>
        [Description("boatFerry")] BoatFerry,

        /// <summary>
        /// Link Is Part Of A Dirt Road
        /// </summary>
        [Description("dirtRoad")] DirtRoad,

        /// <summary>
        /// Link Can Only Be Traversed By Using High-Occupancy Vehicle (Hov) Lanes
        /// </summary>
        [Description("HOVLane")] HOVLane,

        /// <summary>
        /// Link Is Part Of A Motorway
        /// </summary>
        [Description("motorway")] Motorway,

        /// <summary>
        /// Link Is Part Of A Road That You Can Enter But You Have To Exit The Same Way
        /// </summary>
        [Description("noThroughRoad")] NoThroughRoad,

        /// <summary>
        /// Link Is Part Of A Park
        /// </summary>
        [Description("park")] Park,

        /// <summary>
        /// Link Is Part Of A Private Road
        /// </summary>
        [Description("privateRoad")] PrivateRoad,

        /// <summary>
        /// Link Can Only Be Traversed By Using A Rail Ferry
        /// </summary>
        [Description("railFerry")] RailFerry,

        /// <summary>
        /// Link Is Part Of A Toll Road
        /// </summary>
        [Description("tollroad")] Tollroad,

        /// <summary>
        /// Link Passes Through A Tunnel
        /// </summary>
        [Description("tunnel")] Tunnel,

        /// <summary>
        /// Link Is Part Of A Built-Up Area
        /// </summary>
        [Description("builtUpArea")] BuiltUpArea


    }
}
