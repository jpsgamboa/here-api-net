using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// RoutingType provides identifiers for different optimizations which can be applied during the route calculation. 
    /// Selecting the routing type affects which constraints, speed attributes and weights are taken into account during route calculation.<para/>
    /// When calculating Public Transport and truck routes, always use fastest mode.<para/>
    /// fastest: <para/>
    ///         Route calculation from start to destination optimized by travel time.
    ///         Depending on the traffic mode provided by the request, travel time is determined with or
    ///         without traffic information. In some cases, the route returned by the fastest mode may not
    ///         be the route with the shortest possible travel time. 
    ///         For example, the routing service may favor a route that remains on a highway, even if a shorter travel
    ///         time can be achieved by taking a detour or shortcut through a side road.<para/>
    /// shortest: <para/>
    ///         Route calculation from start to destination disregarding any speed information. 
    ///         In this mode, the distance of the route is minimized, while keeping the route sensible. 
    ///         This includes, for example, penalizing turns. Because of that, the resulting route will
    ///         not necessarily be the one with minimal distance.
    /// </summary>
    public enum RoutingType
    {
        [Description("fastest")] Fastest,
        [Description("shortest")] Shortest
    }
}
