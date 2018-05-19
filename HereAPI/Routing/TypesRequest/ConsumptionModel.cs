using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HereAPI.Routing.TypesRequest
{
    public class ConsumptionModel : IRequestAttribute
    {
        public ConsumptionModelType Model { get; set; }

        /// <summary>
        /// The Routing API allows you to specify vehicle specific parameters, which are then used to
        /// calculate fuel or energy consumption for a car on a given route. The interface is generic
        /// to allow support for multiple different models. The Routing API currently supports the
        /// standard model.
        /// <para/>
        /// To specify the standard model, add consumptionmodel=standard to a request. You must
        /// provide additional information in the query parameter customConsumptionDetails. The unit
        /// of energy for this model is not defined and can be determined by the user. This
        /// documentation uses reference meter as a unit of energy. The term reference meter refers
        /// to the amount of energy needed to traverse 1 meter on a straight road at optimal speed.
        /// The following table shows all the possible parameters that can be sent to the standard
        /// consumption model.
        /// </summary>
        public ConsumptionModel(ConsumptionModelType consumptionModelType = ConsumptionModelType.Standard)
        {
            Model = consumptionModelType;
        }

        public string GetAttributeName()
        {
            return "consumptionmodel";
        }

        public string GetAttributeValue()
        {
            return EnumHelper.GetDescription(Model);
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }

        public enum ConsumptionModelType
        {
            [Description("default")] Default,
            [Description("standard")] Standard
        }

        public class CustomConsumptionDetails : IRequestAttribute
        {
            public List<SpeedConsumptionPair> SpeedConsumptionPairs { get; set; }
            public float Ascent { get; set; }
            public float Descent { get; set; }
            public float? TimePenalty { get; set; }
            public float? AuxiliaryConsumption { get; set; }
            public float? Acceleration { get; set; }
            public float? Deceleration { get; set; }

            /// <summary>
            /// </summary>
            /// <param name="speedConsumptionPairs">
            /// Speed dependent consumption multiplier. This parameter indicates how many units of
            /// energy are consumed by travelling 1 meter at a given speed. The value is a comma
            /// separated sequence of pairs in the form speed,consumption. A consumption function is
            /// linearly interpolated from this table. Speed is in kilometers per hour.The speed must
            /// be an integer in the following interval: [0,255]. Consumption is a positive double value.
            /// </param>
            /// <param name="ascent">
            /// Height dependent multiplier. This parameter indicates how many units of energy are
            /// consumed by increasing the altitude by 1 meter. Value must be non negative.
            /// </param>
            /// <param name="descent">
            /// Height dependent multiplier. This parameter indicates how many units of energy are
            /// gained by decreasing the altitude by 1 meter. Value must be non negative.
            /// </param>
            /// <param name="timePenalty">
            /// Energy is consumed also when turning and/or waiting at junctions. This parameter
            /// indicates how many units of energy are consumed by waiting 1 second. Value must be
            /// non negative.
            /// </param>
            /// <param name="auxiliaryConsumption">
            /// Additional energy such as for air conditioning, a radio, or other features can also
            /// be consumed when driving. This parameter indicates the units of additional energy
            /// consumed per second. Value must be non-negative.
            /// </param>
            /// <param name="acceleration">
            /// Additional energy consumed for acceleration. This parameter indicates the units of
            /// additional energy consumed per 1 (km/h)^2 of speed change. Value must be non-negative.
            /// </param>
            /// <param name="deceleration">
            /// Additional energy gained from deceleration. This parameter indicates the units of
            /// additional energy gained per 1 (km/h)^2 of speed change. Value must be non-negative.
            /// </param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public CustomConsumptionDetails(List<SpeedConsumptionPair> speedConsumptionPairs, float ascent, float descent, float? timePenalty = null, float? auxiliaryConsumption = null, float? acceleration = null, float? deceleration = null)
            {
                if (ascent < 0) throw new ArgumentOutOfRangeException("Ascent value must be non negative.");
                if (descent < 0) throw new ArgumentOutOfRangeException("Descent value must be non negative.");
                if (timePenalty != null && timePenalty < 0) throw new ArgumentOutOfRangeException("TimePenalty value must be non negative.");
                if (auxiliaryConsumption != null && auxiliaryConsumption < 0) throw new ArgumentOutOfRangeException("AuxiliaryConsumption value must be non negative.");
                if (acceleration != null && acceleration < 0) throw new ArgumentOutOfRangeException("Acceleration value must be non negative.");
                if (deceleration != null && deceleration < 0) throw new ArgumentOutOfRangeException("Deceleration value must be non negative.");

                SpeedConsumptionPairs = speedConsumptionPairs;
                Ascent = ascent;
                Descent = descent;
                TimePenalty = timePenalty;
                AuxiliaryConsumption = auxiliaryConsumption;
                Acceleration = acceleration;
                Deceleration = deceleration;
            }

            public string GetAttributeName()
            {
                return "customConsumptionDetails";
            }

            public string GetAttributeValue()
            {
                return $"speed,{String.Join(",", SpeedConsumptionPairs.Select(s => s.GetAttributeValue()).ToArray())}" +
                    $";ascent,{Ascent.ToString(HereAPISession.Culture)}" +
                    $";descent,{Descent.ToString(HereAPISession.Culture)}" +
                    $"{(TimePenalty != null ? "" : $";timePenalty,{TimePenalty.Value.ToString(HereAPISession.Culture)}")}" +
                    $"{(AuxiliaryConsumption != null ? "" : $";auxiliaryConsumption,{AuxiliaryConsumption.Value.ToString(HereAPISession.Culture)}")}" +
                    $"{(Acceleration != null ? "" : $";acceleration,{Acceleration.Value.ToString(HereAPISession.Culture)}")}" +
                    $"{(Deceleration != null ? "" : $";deceleration,{Deceleration.Value.ToString(HereAPISession.Culture)}")}";
            }

            public string[] Validate()
            {
                return AttributeValidator.Validate(this);
            }

            public class SpeedConsumptionPair : IAttribute
            {
                [Range(0, 255, ErrorMessage = "The speed must be an integer in the following interval: [0,255].")]
                public int Speed { get; }

                [Range(0, float.MaxValue, ErrorMessage = "Consumption is a positive float value.")]
                public float Consumption { get; }

                public SpeedConsumptionPair(int speed, float consumption)
                {
                    Speed = speed;
                    Consumption = consumption;
                }

                public string GetAttributeValue()
                {
                    return $"{Speed},{Consumption.ToString(HereAPISession.Culture)}";
                }

                public string[] Validate()
                {
                    return AttributeValidator.Validate(this);
                }
            }
        }
    }
}