using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Defines identifiers for different types of shape quality. It is not always possible to
    /// provide exact geometry of the route which matches map data. This type allows to identify such
    /// cases and process them on client side.
    /// </summary>
    public enum ShapeQualityType
    {
        /// <summary>
        /// Shape mostly matches map data with possible rare deviations.
        /// </summary>
        [Description("exact")] Exact,

        /// <summary>
        /// Shape is inaccurate. Typical example can be a route using public transportation where
        /// shape only connects subsequent stops.
        /// </summary>
        [Description("coarse")] Coarse
    }
}