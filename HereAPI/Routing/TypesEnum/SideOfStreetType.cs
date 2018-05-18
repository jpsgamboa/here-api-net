using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Enumeration type to identify on which side of a link an object is placed.
    /// </summary>
    public enum SideOfStreetType
    {
        [Description("left")] Left,
        [Description("right")] Right,
        [Description("neither")] Neither
    }
}