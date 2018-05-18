using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// </summary>
    public enum EngineType
    {
        /// <summary>
        /// Diesel engine. Emits 2.64 kg of CO2 from each combusted liter of fuel.
        /// </summary>
        [Description("diesel")] Diesel,

        /// <summary>
        /// Gasoline engine. Emits 2.392 kg of CO2 from each combusted liter of fuel.
        /// </summary>
        [Description("gasoline")] Gasoline,

        /// <summary>
        /// Electric engine. Does not emit CO2.
        /// </summary>
        [Description("electric")] Electric
    }
}