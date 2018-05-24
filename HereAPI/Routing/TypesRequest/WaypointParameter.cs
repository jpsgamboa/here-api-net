using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using HereAPI.Shared.TypeObjects;

namespace HereAPI.Routing.TypesRequest
{
    public abstract class WaypointParameter : IRequestAttribute
    {
        public uint Index { get; set; }
        public uint? StopOverDuration { get; set; }
        public WaypointType? Type { get; set; }
        public string UserLabel { get; set; }

        public WaypointParameter(uint index, WaypointType? waypointType, uint? stopOverDuration, string userLabel)
        {
            Index = index;
            Type = waypointType;
            StopOverDuration = stopOverDuration;
            UserLabel = userLabel;
        }

        public string GetAttributeName()
        {
            return $"waypoint{Index}";
        }

        public abstract string GetAttributeValue();

        public virtual string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }

        public class GeoWaypointParameter : WaypointParameter
        {
            public GeoCoordinate GeoPoint { get; set; }
            public uint? TransitRadius { get; set; }
            public uint? Heading { get; set; }

            /// <summary>
            /// The GeoWaypointParameterType defines a waypoint by latitude and longitude
            /// coordinates, and an optional radius.
            /// <para/>
            /// Parameter structure:
            /// <para/>
            /// waypoint=[geo!] [Type[, StopOverDuration]!]Position[;TransitRadius[;UserLabel[;Heading]]]
            /// <para/>
            /// https://developer.here.com/documentation/routing/topics/resource-param-type-waypoint.html
            /// </summary>
            /// <param name="geoPoint">        </param>
            /// <param name="waypointType">    </param>
            /// <param name="stopOverDuration">
            /// Stopover delay in seconds. Impacts time-aware calculations. Ignored for passThrough.
            /// </param>
            /// <param name="transitRadius">   
            /// Matching Links are selected within the specified TransitRadius, in meters. For
            /// example to drive past a city without necessarily going into the city center you can
            /// specify the coordinates of the center and a TransitRadius of 5000m.
            /// </param>
            /// <param name="userLabel">       Custom label identifying this waypoint.</param>
            /// <param name="heading">         
            /// Heading in degrees starting at true north and continuing clockwise around the
            /// compass. North is 0 degrees, East is 90 degrees, South is 180 degrees, and West is
            /// 270 degrees.
            /// </param>
            public GeoWaypointParameter(uint waypointIndex, GeoCoordinate geoPoint, WaypointType? waypointType = null, uint? stopOverDuration = null, uint? transitRadius = null, string userLabel = null, uint? heading = null)
                : base(waypointIndex, waypointType, stopOverDuration, userLabel)
            {
                GeoPoint = geoPoint;
                TransitRadius = transitRadius;
                Heading = heading;
            }

            public override string GetAttributeValue()
            {
                return $"geo!" +
                    $"{(Type != null ? EnumHelper.GetDescription(Type) : "")}" +
                    $"{(Type == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(Type != null ? "!" : "")}" +
                    $"{GeoPoint.GetAttributeValue()};" +
                    $"{(TransitRadius != null ? $"{TransitRadius}" : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{(Heading != null ? $"{Heading}" : "")}";
            }

            public override string[] Validate()
            {
                return AttributeValidator.Validate(this);
            }
        }

        public class NavigationWaypointParameterWithStreetPositions : WaypointParameter
        {
            public GeoCoordinate StreetPosition { get; set; }
            public GeoCoordinate DisplayPosition { get; set; }
            public string StreetName { get; set; }

            /// <summary>
            /// The NavigationWaypointParameter defines a waypoint by street position and name. The
            /// street name helps select the right road in complex intersection scenarios such as a
            /// bridge crossing another road or in case of off-road locations near highways. A common
            /// use case for this scenario is when the user specifies a waypoint by selecting a place
            /// or a location after a search. Note that to avoid the waypoint being matched to a
            /// highway in an off-road scenario it is sufficient to specify an off-road location as a
            /// street position without an optional street name (see the structure of StreetPosition) .
            /// <para/>
            /// The optional display position of the waypoint defines where the location is displayed
            /// on a map. It denotes the center of the location and is not navigable, i.e.it is not
            /// located on a link in the routing network in contrast to the navigation positions of a
            /// location. The display position allows the routing engine to decide whether the
            /// waypoint is located on the left or on the right-hand side of the route.
            /// <para/>
            /// Parameter structure:
            /// <para/>
            /// waypoint0= street![Type[, StopOverDuration]!][DisplayPosition[;UserLabel]]!StreetPosition
            /// </summary>
            /// <param name="streetPosition">  WGS-84 degrees between -90 and 90. Altitude in meters.</param>
            /// <param name="streetName">      </param>
            /// <param name="waypointType">    
            /// 180 degree turns are allowed for stopOver but not for passThrough. Waypoints defined
            /// through a drag-n-drop action should be marked as pass-through. PassThrough waypoints
            /// will not appear in the list of maneuvers.
            /// </param>
            /// <param name="stopOverDuration">
            /// Stopover delay in seconds. Impacts time-aware calculations. Ignored for passThrough.
            /// </param>
            /// <param name="displayPosition"> 
            /// Latitude WGS-84 degrees between -90 and 90. Longitude WGS-84 degrees between -180 and
            /// 180. Altitude in meters.
            /// </param>
            /// <param name="userLabel">       Custom label identifying this waypoint.</param>
            public NavigationWaypointParameterWithStreetPositions(uint waypointIndex, GeoCoordinate streetPosition, string streetName = null, WaypointType? waypointType = null, uint? stopOverDuration = null, GeoCoordinate displayPosition = null, string userLabel = null)
                : base(waypointIndex, waypointType, stopOverDuration, userLabel)
            {
                StreetPosition = streetPosition;
                DisplayPosition = displayPosition;
                StreetName = streetName;
            }

            public override string GetAttributeValue()
            {
                return $"street!" +
                    $"{(Type != null ? EnumHelper.GetDescription(Type) : "")}" +
                    $"{(Type == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(Type != null ? "!" : "")}" +
                    $"{(DisplayPosition != null ? DisplayPosition.GetAttributeValue() : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{StreetPosition.GetAttributeValue()};" +
                    $"{(StreetName != null ? $"{StreetName}" : "")}";
            }

            public override string[] Validate()
            {
                return AttributeValidator.Validate(this);
            }
        }

        public class NavigationWaypointParameterWithLinkPositions : WaypointParameter
        {
            public LinkId LinkId { get; set; }
            public float? Spot { get; set; }
            public GeoCoordinate DisplayPosition { get; set; }

            /// <summary>
            /// The NavigationWaypointParameter defines a waypoint by LinkId and optional Spot value.
            /// Spot is defined as the fractional distance from the link's reference-node to the
            /// non-reference node, with a value between 0 and 1. When no Spot value nor
            /// DisplayPosition is given in request then default value 0.5 is assumed
            /// <para/>
            /// The optional display position of the waypoint defines where the location is displayed
            /// on a map. It denotes the center of the location and is not navigable, i.e.it is not
            /// located on a link in the routing network in contrast to the navigation positions of a
            /// location. The display position allows the routing engine to decide whether the
            /// waypoint is located on the left or on the right-hand side of the route.
            /// <para/>
            /// Parameter structure:
            /// <para/>
            /// waypoint0= link[!Type[, StopOverDuration]][![DisplayPosition][; UserLabel]]!LinkPosition
            /// </summary>
            /// <param name="linkId">          </param>
            /// <param name="linkDirection">   
            /// Id of the link position with mandatory direction prefix (+,-,*) and optional relative
            /// position of the location along the link with a value between 0 and 1. When no spot
            /// value nor display position is given in the request then default value 0.5 is assumed.
            /// </param>
            /// <param name="spot">            </param>
            /// <param name="waypointType">    
            /// 180 degree turns are allowed for stopOver but not for passThrough. Waypoints defined
            /// through a drag-n-drop action should be marked as pass-through. PassThrough waypoints
            /// will not appear in the list of maneuvers.
            /// </param>
            /// <param name="stopOverDuration">
            /// Stopover delay in seconds. Impacts time-aware calculations. Ignored for passThrough.
            /// </param>
            /// <param name="displayPosition"> 
            /// Latitude WGS-84 degrees between -90 and 90. Longitude WGS-84 degrees between -180 and
            /// 180. Altitude in meters.
            /// </param>
            /// <param name="userLabel">       Custom label identifying this waypoint.</param>
            public NavigationWaypointParameterWithLinkPositions(uint waypointIndex, LinkId linkId, float? spot = null, WaypointType? waypointType = null, uint? stopOverDuration = null, GeoCoordinate displayPosition = null, string userLabel = null)
                : base(waypointIndex, waypointType, stopOverDuration, userLabel)
            {
                LinkId = linkId;
                Spot = spot;
                DisplayPosition = displayPosition;
            }

            public override string GetAttributeValue()
            {
                return $"link!" +
                    $"{(Type != null ? EnumHelper.GetDescription(Type) : "")}" +
                    $"{(Type == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(Type != null ? "!" : "")}" +
                    $"{(DisplayPosition != null ? DisplayPosition.GetAttributeValue() : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{LinkId.GetAttributeValue()},{(Spot != float.NaN ? $"{Spot.Value.ToString(HereAPISession.Culture)}" : "0.5")}";
            }

            public override string[] Validate()
            {
                return AttributeValidator.Validate(this);
            }
        }
    }
}