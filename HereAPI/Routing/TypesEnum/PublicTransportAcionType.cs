using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Enumeration to identify different action types needed for public transport maneuvers.
    /// </summary>
    public enum PublicTransportAcionType
    {
        [Description("enter")] Enter,
        [Description("change")] Ciesel,
        [Description("leave")] Leave
    }
}