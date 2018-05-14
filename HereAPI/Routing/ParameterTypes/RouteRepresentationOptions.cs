using System.ComponentModel;

namespace HereAPI.Routing.ParameterTypes
{
    public class RouteRepresentationOptions
    {
        /// <summary>
        /// Representation formats for instruction texts.<para/>
        ///  text: returns the instruction as a plain text string;<para/>
        ///  html: instruction format is based on span tags with different CSS classes to assign semantics to the tagged part of the instruction.<para/>
        /// </summary>
        public enum InstructionFormatType
        {
            [Description("text")] Text,
            [Description("html")] HTML,
        }


        /// <summary>
        /// Sequence of attribute keys of the fields that are included in public transport line elements.<para/>
        ///
        /// foreground:
        ///     Indicates whether the foreground color shall be included in the line.
        /// background:
        ///     Indicates whether the background color of the line shall be provided.<para/>
        /// lineStyle:
        ///     Indicates whether the line style of the public transport line shall be provided.<para/>
        /// companyShortName:
        ///     Indicates whether the company short name should be included in the public transport line.<para/>
        /// companyLogo:
        ///     Indicates whether the company logo should be included in the public transport line.<para/>
        /// flags:
        ///     Indicates whether the flags should be included in the public transport line.<para/>
        /// typeName:
        ///     Indicates whether the type name should be included in the public transport line.<para/>
        /// lineId:
        ///     Indicates whether the line Id should be included in the public transport line.<para/>
        /// companyId:
        ///     Indicates whether the company Id should be included in the public transport line.<para/>
        /// systemId:
        ///     Indicates whether the system Id should be included in the public transport line.<para/>
        /// stops:
        ///     Indicates whether stops should be included in the public transport line.<para/>
        /// </summary>
        public enum PublicTransportLineAttribute
        {
            [Description("fg")] Foreground,
            [Description("bg")] Background,
            [Description("ls")] Linestyle,
            [Description("cs")] Companyshortname,
            [Description("cl")] Companylogo,
            [Description("fl")] Flags,
            [Description("tn")] Typename,
            [Description("li")] Lineid,
            [Description("ci")] Companyid,
            [Description("si")] Systemid,
            [Description("st")] Stops
        }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route links.<para/>
        /// 
        /// shape:
        ///     Indicates whether the link should include its geometry<para/>
        /// length:
        ///     Indicates whether the link should include its length<para/>
        /// speedLimit:
        ///     Indicates whether the link should include SpeedLimit<para/>
        /// dynamicSpeedInfo:
        ///     Indicates whether the link should include dynamic speed information<para/>
        /// truckRestrictions:
        ///     Indicates whether the link should include truck restrictions<para/>
        /// flags:
        ///     Indicates whether the link should include link flags<para/>
        /// roadNumber:
        ///     Indicates whether the link should include the link's road number<para/>
        /// roadName:
        ///     Indicates whether the link should include the link's road number<para/>
        /// timezone:
        ///     Indicates whether the link should include the timezone.
        ///     Note: Requesting timezone information is known to slow down responses.<para/>
        /// nextLink:
        ///     Indicates whether the link should include the link which will be next when following the route<para/>
        /// publicTransportLine:
        ///     Indicates whether the link should include information about the public transport line.<para/>
        /// remainTime:
        ///     Indicates whether the link should include information about the remaining time until the destination is
        ///     reached.<para/>
        /// remainDistance:
        ///     Indicates whether the link should include information about the remaining distance until the destination
        ///     is reached.<para/>
        /// maneuver:
        ///     Indicates whether the link should include information about the associated maneuver.<para/>
        /// functionalClass:
        ///     Indicates whether the link should include information about the functional class.<para/>
        /// nextStopName:
        ///     Indicates whether the link should include information about the next stop.<para/>
        /// indices:
        ///     Indicates whether shape index information(FirstPoint, LastPoint) should be included in links instead of
        ///    copying shape points.<para/>
        /// consumption:
        ///     Indicates whether the link should include information on energy consumption. If a consumption model is not
        ///    provided, the consumption value in the response is set to 0.<para/>
        /// </summary>
        public enum RouteLinkAttribute
        {
            [Description("sh")] Shape,
            [Description("le")] Length,
            [Description("sl")] Speedlimit,
            [Description("ds")] Dynamicspeedinfo,
            [Description("tr")] Truckrestrictions,
            [Description("fl")] Flags,
            [Description("rn")] Roadnumber,
            [Description("ro")] Roadname,
            [Description("tz")] Timezone,
            [Description("nl")] Nextlink,
            [Description("pt")] Publictransportline,
            [Description("rt")] Remaintime,
            [Description("rd")] Remaindistance,
            [Description("ma")] Maneuver,
            [Description("fc")] Functionalclass,
            [Description("ns")] Nextstopname,
            [Description("ix")] Indices,
            [Description("cn")] Consumption
        }


        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route maneuvers.<para/>
        /// 
        /// position:
        ///     Indicates whether the position should be included in the maneuvers.<para/>
        /// shape:
        ///     Indicates whether the shape of the segment to the next maneuver should be included in the maneuvers.<para/>
        /// travelTime:
        ///     Indicates whether the time needed to the next maneuver should be included in the maneuvers.<para/>
        /// length:
        ///     Indicates whether the distance to the next maneuver should be included in the maneuvers.<para/>
        /// time:
        ///     Indicates whether the point in time when the maneuver will take place should be included in the maneuvers.<para/>
        /// link:
        ///     Indicates whether the link where the maneuver takes place shall be included in the maneuver.<para/>
        /// publicTransportLine:
        ///     Indicates whether the information about the public transport line should be included in the maneuvers.<para/>
        /// publicTransportTickets:
        ///     Indicates whether the information about the public transport tickets should be included in the maneuvers.<para/>
        /// platform:
        ///     Indicates whether the platform information for a public transport line should be included in the maneuvers.<para/>
        /// roadName:
        ///     Indicates whether the road name should be included in the maneuvers.<para/>
        /// nextRoadName:
        ///     Indicates whether the name of the next road shall be included in the maneuvers.<para/>
        /// roadNumber:
        ///     Indicates whether the road number should be included in the maneuvers.<para/>
        /// nextRoadNumber:
        ///     Indicates whether the number of the next road should be included in the maneuvers.<para/>
        /// signPost:
        ///     Indicates whether the sign post information should be included in the maneuvers.<para/>
        /// notes:
        ///     Indicates whether additional notes should be included in the maneuvers.<para/>
        /// action:
        ///     Indicates whether actions should be included in the maneuvers.<para/>
        /// direction:
        ///     Indicates whether directions should be included in the maneuvers.<para/>
        /// nextManeuver:
        ///     Indicates whether a reference to the next maneuver should be included in the maneuvers.<para/>
        /// freewayExit:
        ///     Indicates whether the freeway exit should be included in the maneuvers.<para/>
        /// freewayJunction:
        ///     Indicates whether the freeway junction should be included in the maneuvers.<para/>
        /// baseTime:
        ///     Indicates whether the BaseTime information should be included in the maneuvers. By default, BaseTime
        ///     information is not included in the maneuvers.<para/>
        /// trafficTime:
        ///     Indicates whether the TrafficTime information should be included in the maneuvers. By default, TrafficTime
        ///     information is not included in the maneuvers.<para/>
        /// indices:
        ///     Indicates whether shape index information (FirstPoint, LastPoint) should be included in the maneuvers
        ///     instead of copying shape points to the maneuver.<para/>
        /// boundingBox:
        ///     Indicates whether the bounding box of the route shall be provided for the route.<para/>
        /// roadShield:
        ///     Indicates whether road shield information should be included in the maneuvers.<para/>
        /// startAngle:
        ///     Indicates whether start angle information should be included in the maneuvers.<para/>
        /// waitTime:
        ///     Indicates whether wait time information should be included in public transport maneuvers.<para/>
        /// shapeQuality:
        ///     Indicates whether information about shape quality should be included in maneuvers.<para/>
        /// publicTransportDelays:
        ///    Indicates whether the delay information should be included in the public transport maneuvers.<para/>
        /// </summary>
        public enum ManeuverAttribute
        {
            [Description("po")] Position,
            [Description("sh")] Shape,
            [Description("tt")] Traveltime,
            [Description("le")] Length,
            [Description("ti")] Time,
            [Description("li")] Link,
            [Description("pt")] Publictransportline,
            [Description("tx")] Publictransporttickets,
            [Description("pl")] Platform,
            [Description("rn")] Roadname,
            [Description("nr")] Nextroadname,
            [Description("ru")] Roadnumber,
            [Description("nu")] Nextroadnumber,
            [Description("sp")] Signpost,
            [Description("no")] Notes,
            [Description("ac")] Action,
            [Description("di")] Direction,
            [Description("nm")] Nextmaneuver,
            [Description("fe")] Freewayexit,
            [Description("fj")] Freewayjunction,
            [Description("bt")] Basetime,
            [Description("tm")] Traffictime,
            [Description("ix")] Indices,
            [Description("bb")] Boundingbox,
            [Description("rs")] Roadshield,
            [Description("sa")] Startangle,
            [Description("wt")] Waittime,
            [Description("sq")] Shapequality,
            [Description("td")] Publictransportdelays
        }

        /// <summary>
        /// Define which attributes are included in the response as part of the data representation of the route legs.<para/>
        /// 
        /// waypoint:
        ///     Indicates whether the waypoint shall be included in the route leg.<para/>
        /// maneuvers:
        ///     Indicates whether the maneuvers of the route leg shall be provided.<para/>
        /// links:
        ///     Indicates whether the links along the route leg shall be provided.<para/>
        /// length:
        ///     Indicates whether the route leg should include its length<para/>
        /// travelTime:
        ///     Indicates whether the route leg should include its duration<para/>
        /// shape:
        ///     Indicates whether the shape of the segment to the next maneuver
        ///     should be included in the maneuvers.<para/>
        /// indices:
        ///     Indicates whether shape index information (FirstPoint, LastPoint)
        ///     should be included in the maneuvers instead of copying shape points to the maneuver.<para/>
        /// boundingBox:
        ///     Indicates whether the bounding box of the maneuver shall be provided.<para/>
        /// baseTime:
        ///     Indicates whether the BaseTime information should be provided in RouteLegs.<para/>
        /// trafficTime:
        ///     Indicates whether the TrafficTime information should be included in RouteLegs.<para/>
        /// summary:
        ///     Indicates whether distance and time summary information should be included in RouteLegs<para/>
        /// 
        /// </summary>
        public enum RouteLegAttribute
        {
            [Description("wp")] Waypoint,
            [Description("mn")] Maneuvers,
            [Description("li")] Links,
            [Description("le")] Length,
            [Description("tt")] Traveltime,
            [Description("sh")] Shape,
            [Description("ix")] Indices,
            [Description("bb")] Boundingbox,
            [Description("bt")] Basetime,
            [Description("tm")] Traffictime,
            [Description("sm")] Summary
        }


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
        public enum RouteAttribute
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
        public enum RouteRepresentationMode
        {
            [Description("overview")] Overview,
            [Description("display")] Display,
            [Description("dragNDrop")] Dragndrop,
            [Description("navigation")] Navigation,
            [Description("linkPaging")] Linkpaging,
            [Description("turnByTurn")] Turnbyturn
        }
    }
}
