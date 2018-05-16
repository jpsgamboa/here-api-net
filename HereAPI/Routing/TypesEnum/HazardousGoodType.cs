using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
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

}
