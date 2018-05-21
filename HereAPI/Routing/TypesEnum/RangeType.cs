using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Specifies type of range. Possible values are distance, time, consumption. For distance the unit is meters. For time the unit is seconds. For consumption it is defined by consumption model
    /// </summary>
    public enum RangeType
    {
        [Description("distance")] Distance,
        [Description("time")] Time,
        [Description("consumption")] Consumption
    }
}
