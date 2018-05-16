using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// diesel: Diesel engine. Emits 2.64 kg of CO2 from each combusted liter of fuel. <para/>
    /// gasoline: Gasoline engine. Emits 2.392 kg of CO2 from each combusted liter of fuel. <para/>
    /// electric: Electric engine. Does not emit CO2. 
    /// </summary>
    public enum EngineType
    {
        [Description("diesel")] Diesel,
        [Description("gasoline")] Gasoline,
        [Description("electric")] Electric
    }
}
