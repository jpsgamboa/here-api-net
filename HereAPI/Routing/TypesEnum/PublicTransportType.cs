using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
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
}
