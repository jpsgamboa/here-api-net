using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// </summary>
    public enum RouteFeatureWeightType
    {
        /// <summary>
        /// The routing engine guarantees that the route does not contain strictly excluded features.
        /// If the condition cannot be fulfilled no route is returned.
        /// <para/>
        /// </summary>
        [Description("-3")] StrictExclude,

        /// <summary>
        /// The routing engine does not consider links containing the corresponding feature.If no
        /// route can be found because of these limitations the condition is weakened.
        /// <para/>
        /// </summary>
        [Description("-2")] SoftExclude,

        /// <summary>
        /// The routing engine assigns penalties for links containing the corresponding feature.
        /// <para/>
        /// </summary>
        [Description("-1")] Avoid,

        /// <summary>
        /// The routing engine does not alter the ranking of links containing the corresponding feature.
        /// <para/>
        /// </summary>
        [Description("0")] Normal,
    }
}