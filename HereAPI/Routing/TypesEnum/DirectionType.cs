using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Enumeration type to identify directions at a maneuver. 
    /// </summary>
    public enum DirectionType
    {
        [Description("forward")] Forward,
        [Description("bearRight")] BearRight,
        [Description("lightRight")] LightRight,
        [Description("right")] Right,
        [Description("hardRight")] HardRight,
        [Description("uTurnRight")] UTurnRight,
        [Description("uTurnLeft")] UTurnLeft,
        [Description("hardLeft")] HardLeft,
        [Description("left")] Left,
        [Description("lightLeft")] LightLeft,
        [Description("bearLeft")] BearLeft

    }
}
