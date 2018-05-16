using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using System.ComponentModel;

namespace HereAPI.Routing.TypesRequest
{
    public class VehicleType : IRequestAttribute
    {
        public EngineType Engine { get; set; }
        public float AverageConsumption { get; set; }

        /// <summary>
        /// Contains vehicle specific information, which can be used to estimate CO2 emission.
        /// </summary>
        /// <param name="engineType">Type of the engine.</param>
        /// <param name="averageConsumption">The average fuel consumption, measured in liters per 100km. Affects CO2 emission only in case of combustion engines (diesel and gasoline). </param>
        public VehicleType(EngineType engineType, float averageConsumption)
        {
            Engine = engineType;
            AverageConsumption = averageConsumption;
        }

        public string GetAttributeName()
        {
            return "vehicletype";
        }

        public string GetAttributeValue()
        {
            return $"{EnumHelper.GetDescription(Engine)},{AverageConsumption.ToString(HereAPI.Culture)}";
        }

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
}
