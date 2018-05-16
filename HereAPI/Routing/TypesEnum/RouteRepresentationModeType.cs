using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// overview:
    ///     Overview mode only returns the Route and the RouteSummary object<para/>
    /// display:
    ///     Display mode that allows to show the route with all maneuvers.
    ///     Links won't be included in the response<para/>
    /// dragNDrop:
    ///     Drag and Drop mode to be used during drag and drop(re-routing) actions.
    ///     The response will only contain the shape of the route restricted to the
    ///     view bounds provided in the representation options.<para/>
    /// navigation:
    ///     Navigation mode to provide all information necessary to support a
    ///     navigation device.This mode activates the most extensive data
    ///     response as all link information will be included in the response
    ///     to allow a detailed display while navigating.
    ///     RouteId will not be calculated in this mode however, unless it
    ///     is additionally requested.<para/>
    /// linkPaging:
    ///     Paging mode that will be used when incrementally loading
    ///     links while navigating along the route. The response will
    ///     be limited to link information.<para/>
    /// turnByTurn:
    ///     Turn by turn mode to provide all information necessary to
    ///     support turn by turn. This mode activates all data needed
    ///     for navigation excluding any redundancies.
    ///     RouteId will not be calculated in this mode however, unless it is additionally requested.<para/>
    /// </summary>
    public enum RouteRepresentationModeType
    {
        [Description("overview")] Overview,
        [Description("display")] Display,
        [Description("dragNDrop")] Dragndrop,
        [Description("navigation")] Navigation,
        [Description("linkPaging")] Linkpaging,
        [Description("turnByTurn")] Turnbyturn
    }
}
