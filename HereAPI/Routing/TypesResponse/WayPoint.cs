using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    public class WayPoint
    {
        /// <summary>
        /// ID of the link on the navigable network associated with the waypoint. 
        /// <see cref="https://developer.here.com/documentation/routing/topics/resource-type-link-id.html#resource-type-link-id"/>
        /// </summary>
        public LinkId LinkId { get; set; }

        /// <summary>
        /// If this waypoint is a start point, this will be mapped to the beginning of the link. 
        /// If used as destination point or via point, it will be mapped to the end of the link. 
        /// <see cref="https://developer.here.com/documentation/routing/topics/resource-type-coordinate.html#resource-type-coordinate"/>
        /// </summary>
        public GeoCoordinate MappedPosition { get; set; }

        /// <summary>
        /// Original position as it was specified in the corresponding request. 
        /// The value will depend on request construction:<para/>
        /// If using a NavigationWaypointParameterType, the service will set OriginalPosition 
        /// as the display position(if specified) or as the navigation position selected by the 
        /// routing engine(if not specified in the request).<para/>
        /// If using a GeoWaypointParameterType, the service will set the OriginalPosition as the 
        /// position specified in the request.<para/>
        /// <see cref="https://developer.here.com/documentation/routing/topics/resource-type-coordinate.html#resource-type-coordinate"/>
        /// </summary>
        public GeoCoordinate OriginalPosition { get; set; }

        /// <summary>
        /// Defines the type of the waypoint, either stopOver or passThrough. 
        /// <see cref="https://developer.here.com/documentation/routing/topics/resource-type-enumerations.html#resource-type-enumerations__enum-waypoint-parameter-type"/>
        /// </summary>
        public WaypointType? Type { get; set; }

        /// <summary>
        /// Contains the relative position of the mapped location along the link, 
        /// as the fractional distance between the link's reference node and the 
        /// non-reference node. Ranges in value from 0 to 1. When no spot value 
        /// nor display position is given in the request then default value 0.5 is assumed.
        /// </summary>
        public double Stop { get; set; }



    }
}
