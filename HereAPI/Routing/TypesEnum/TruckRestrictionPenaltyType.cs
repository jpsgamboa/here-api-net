using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Defines penalty type on violated truck restrictions.<para/>
    /// </summary>
    public enum TruckRestrictionPenaltyType
    {
        /// <summary>
        /// Route will not use links with a violated truck restriction at any circumstances<para/>
        /// Note: Route computation will fail and return NoRouteFound if not able to avoid the links with a 
        /// violated truck restriction and the penalty type is strict.<para/>
        /// </summary>
        [Description("strict")] Strict,

        /// <summary>
        /// Route will use links with a violated truck restriction if there is no alternative to avoid them<para/>
        /// Note: The route violating truck restrictions is indicated in the response with dedicated route and maneuver notes.
        /// The route with the note of the type violation and the text truckRestriction may be travelled only at own responsibilty.
        /// While driving such route extra care has to be taken as it may result in a vehicle or a road infrastructure damage.
        /// </summary>
        [Description("soft")] Soft
    }

}
