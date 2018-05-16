using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{

    /// <summary>
    /// Define which attributes are included in the response as part of the 
    /// data representation of the route.<para/>
    /// 
    /// waypoints:	
    ///     Indicates whether via points shall be included in the route.<para/>
    /// summary:
    ///     Indicates whether a route summary shall be provided for the route.<para/>
    /// summaryByCountry:
    ///     Indicates whether a country-based route summary shall be provided for the route.<para/>
    /// shape:
    ///     Indicates whether the shape of the route shall be provided for the route.<para/>
    /// boundingBox:
    ///     Indicates whether the bounding box of the route shall be provided for the route.<para/>
    /// legs:
    ///     Indicates whether the legs of the route shall be provided for the route.<para/>
    /// notes:
    ///     Indicates whether additional notes shall be provided for the route.<para/>
    /// lines:
    ///     Indicates whether PublicTransportLines shall be provided for the route.<para/>
    /// tickets:
    ///     Indicates whether PublicTransportTickets shall be provided for the route.<para/>
    /// labels:
    ///     Indicates whether Labels shall be provided for the route. Labels are useful to distinguish between
    ///     alternative routes.<para/>
    /// routeId:
    ///     Indicates whether RouteId shall be calculated and provided for the route. There are cases when RouteId
    ///     calculation is not possible (e.g.PublicTransport) or fails even though the rest of the route is properly
    ///     calculated.<para/>
    /// groups:
    ///     Indicates whether Maneuver Groups should be included in the route. Maneuver Groups are useful for multi
    ///     modal routes.<para/>
    /// incidents:
    ///     Indicates whether Incidents on the route shall be provided for the route.<para/>
    /// zones:
    ///     Indicates whether crossed zones shall be provided for the route<para/>
    /// </summary>
    public enum RouteAttributeType
    {
        [Description("wp")] Waypoints,
        [Description("sm")] Summary,
        [Description("sc")] Summarybycountry,
        [Description("sh")] Shape,
        [Description("bb")] Boundingbox,
        [Description("lg")] Legs,
        [Description("no")] Notes,
        [Description("li")] Lines,
        [Description("tx")] Tickets,
        [Description("la")] Labels,
        [Description("ri")] Routeid,
        [Description("gr")] Groups,
        [Description("ic")] Incidents,
        [Description("zo")] Zones
    }
}
