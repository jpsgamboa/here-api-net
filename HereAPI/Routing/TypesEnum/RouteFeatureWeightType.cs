using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// strictExclude: The routing engine guarantees that the route does not contain strictly excluded features. If the condition cannot be fulfilled no route is returned.<para/>
    /// softExclude: The routing engine does not consider links containing the corresponding feature.If no route can be found because of these limitations the condition is weakened.<para/>
    /// avoid: The routing engine assigns penalties for links containing the corresponding feature.<para/>
    /// normal: The routing engine does not alter the ranking of links containing the corresponding feature.<para/>
    /// </summary>
    public enum RouteFeatureWeightType
    {
        [Description("-3")] StrictExclude,
        [Description("-2")] SoftExclude,
        [Description("-1")] Avoid,
        [Description("0")] Normal,
    }
}
