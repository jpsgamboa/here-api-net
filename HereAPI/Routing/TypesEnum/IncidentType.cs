using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Defines identifiers for different incidents.
    /// </summary>
    public enum IncidentType
    {
        [Description("accident")] Accident,
        [Description("congestion")] Congestion,
        [Description("roadworks")] Roadworks,
        [Description("closure")] Closure,
        [Description("flow")] Flow,
        [Description("other")] Other
    }
}