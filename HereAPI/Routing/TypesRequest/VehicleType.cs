using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;

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
        /// <param name="averageConsumption">
        /// The average fuel consumption, measured in liters per 100km. Affects CO2 emission only in
        /// case of combustion engines (diesel and gasoline).
        /// </param>
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
            return $"{EnumHelper.GetDescription(Engine)},{AverageConsumption.ToString(HereAPISession.Culture)}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}