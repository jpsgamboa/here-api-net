using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.ParameterTypes
{
    public class EnumTypes
    {

        public enum TurnType
        {
            [Description("difficult")] Difficult,
        }

        public enum UnitSystem
        {
            [Description("metric")] Metric,
            [Description("imperial")] Imperial,
        }

        /// <summary>
        /// Enumeration to identify different action types needed for public transport maneuvers 
        /// </summary>
        public enum PublicTransportType
        {
            [Description("busPublic")] BusPublic,
            [Description("busTouristic")] BusTouristic,
            [Description("busIntercity")] BusIntercity,
            [Description("busExpress")] BusExpress,
            [Description("railMetro")] RailMetro,
            [Description("railMetroRegional")] RailMetroRegional,
            [Description("railLight")] RailLight,
            [Description("railRegional")] RailRegional,
            [Description("trainRegional")] TrainRegional,
            [Description("trainIntercity")] TrainIntercity,
            [Description("trainHighSpeed")] TrainHighspeed,
            [Description("monoRail")] MonoRail,
            [Description("aerial")] Aerial,
            [Description("inclined")] Inclined,
            [Description("water")] Water,
            [Description("privateService")] PrivateService
        }


        /// <summary>
        /// Relevant for restrictions that apply exclusively to tractors with semi-trailers 
        /// (observed in North America). Such restrictions are taken into account only in case 
        /// of the truckType set to tractorTruck and the trailers count greater than 0 
        /// (for example &truckType=tractorTruck&trailersCount=1). 
        /// The truck type is irrelevant in case of restrictions common for all types of trucks.
        /// </summary>
        public enum TruckType
        {
            [Description("truck")] Truck,
            [Description("tractorTruck")] TractorTruck
        }


        /// <summary>
        /// Defines names for different types of hazardous materials. 
        /// </summary>
        public enum HazardousGoodType
        {
            [Description("explosive")] Explosive,
            [Description("gas")] Gas,
            [Description("flammable")] Flammable,
            [Description("combustible")] Combustible,
            [Description("organic")] Organic,
            [Description("poison")] Poison,
            [Description("radioActive")] RadioActive,
            [Description("corrosive")] Corrosive,
            [Description("poisonousInhalation")] PoisonousInhalation,
            [Description("harmfulToWater")] HarmfulToWater,
            [Description("other")] Other,
            [Description("allHazardousGoods")] AllhazardousGoods
        }


        public enum TunnelCategory
        {
            [Description("B")] B,
            [Description("C")] C,
            [Description("D")] D,
            [Description("E")] E
        }

        /// <summary>
        /// Defines penalty type on violated truck restrictions.<para/>
        /// 
        /// strict: route will not use links with a violated truck restriction at any circumstances<para/>
        /// Note: Route computation will fail and return NoRouteFound if not able to avoid the links with a 
        /// violated truck restriction and the penalty type is strict.<para/>
        /// soft: route will use links with a violated truck restriction if there is no alternative to avoid them<para/>
        /// Note: The route violating truck restrictions is indicated in the response with dedicated route and maneuver notes.
        /// The route with the note of the type violation and the text truckRestriction may be travelled only at own responsibilty.
        /// While driving such route extra care has to be taken as it may result in a vehicle or a road infrastructure damage.
        /// 
        /// </summary>
        public enum TruckRestrictionPenalty
        {
            [Description("strict")] Strict,
            [Description("soft")] Soft
        }

    }
}
