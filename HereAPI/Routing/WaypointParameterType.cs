using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HereAPI.Shared;
using static HereAPI.Shared.Geometry;

namespace HereAPI.Routing
{
    class WaypointParameterType
    {
        /// <summary>
        /// 180 degree turns are allowed for stopOver but not for passThrough. 
        /// Waypoints defined through a drag-n-drop action should be marked as pass-through. 
        /// PassThrough waypoints will not appear in the list of maneuvers. 
        /// </summary>
        public enum WaypointType
        {
            None,
            [Description("stopOver")] StopOver,
            [Description("passThrough")] PassThrough,
        }

        /// <summary>
        /// The GeoWaypointParameterType defines a waypoint by latitude and longitude coordinates, and an optional radius. Parameter structure:<para/>
        /// waypoint=[geo!] [Type[, StopOverDuration]!]Position[;TransitRadius[;UserLabel[;Heading]]]
        /// </summary>
        class GeoWaypointParameter : UrlParameter
        {

            public GeoPoint GeoPoint { get; set; }
            public WaypointType WaypointType { get; set; }
            public int StopOverDuration { get; set; }
            public int TransitRadius { get; set; }
            public string UserLabel { get; set; }
            public int Heading { get; set; }

            /// <summary>
            /// The GeoWaypointParameterType defines a waypoint by latitude and longitude coordinates, and an optional radius. <para/>
            /// Parameter structure:<para/>
            /// waypoint=[geo!] [Type[, StopOverDuration]!]Position[;TransitRadius[;UserLabel[;Heading]]]<para/>
            /// https://developer.here.com/documentation/routing/topics/resource-param-type-waypoint.html
            /// </summary>
            /// <param name="geoPoint"></param>
            /// <param name="waypointType"></param>
            /// <param name="stopOverDuration">Stopover delay in seconds. Impacts time-aware calculations. Ignored for passThrough.</param>
            /// <param name="transitRadius">Matching Links are selected within the specified TransitRadius, in meters. For example to drive past a city without necessarily going into the city center you can specify the coordinates of the center and a TransitRadius of 5000m.</param>
            /// <param name="userLabel">Custom label identifying this waypoint.</param>
            /// <param name="heading">Heading in degrees starting at true north and continuing clockwise around the compass. North is 0 degrees, East is 90 degrees, South is 180 degrees, and West is 270 degrees.</param>
            public GeoWaypointParameter(GeoPoint geoPoint, WaypointType waypointType = WaypointType.None, int stopOverDuration = 0, int transitRadius = int.MinValue, string userLabel = null, int heading = int.MinValue)
            {
                GeoPoint = geoPoint;
                WaypointType = waypointType;
                StopOverDuration = stopOverDuration;
                TransitRadius = transitRadius;
                UserLabel = userLabel;
                Heading = heading;
            }

            public string GetAsUrlParameter()
            {
                return $"geo!" +
                    $"{(WaypointType != WaypointType.None ? Enums.GetDescription(WaypointType) : "")}" +
                    $"{(WaypointType == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(WaypointType != WaypointType.None ? "!" : "")}" +
                    $"{GeoPoint.GetAsUrlParameter()};" +
                    $"{(TransitRadius != int.MinValue ? $"{TransitRadius}" : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{(Heading != int.MinValue ? $"{Heading}" : "")}";
            }
        }

        public class NavigationWaypointParameterWithStreetPositions : UrlParameter
        {
            public GeoPoint StreetPosition { get; set; }
            public GeoPoint DisplayPosition { get; set; }
            public string StreetName { get; set; }
            public string UserLabel { get; set; }
            public int StopOverDuration { get; set; }
            public WaypointType WaypointType { get; set; }


            /// <summary>
            /// The NavigationWaypointParameter defines a waypoint by street position and name. 
            /// The street name helps select the right road in complex intersection scenarios such as a bridge crossing another road 
            /// or in case of off-road locations near highways. A common use case for this scenario is when the user specifies a 
            /// waypoint by selecting a place or a location after a search. Note that to avoid the waypoint being matched to a 
            /// highway in an off-road scenario it is sufficient to specify an off-road location as a street position without an 
            /// optional street name (see the structure of StreetPosition) .<para/>
            /// The optional display position of the waypoint defines where the location is displayed on a map.
            /// It denotes the center of the location and is not navigable, i.e.it is not located on a link in the routing 
            /// network in contrast to the navigation positions of a location. The display position allows the routing engine 
            /// to decide whether the waypoint is located on the left or on the right-hand side of the route.<para/>
            /// Parameter structure:<para/>
            /// waypoint0= street![Type[, StopOverDuration]!][DisplayPosition[;UserLabel]]!StreetPosition
            /// </summary>
            /// <param name="streetPosition">WGS-84 degrees between -90 and 90. Altitude in meters.</param>
            /// <param name="streetName"></param>
            /// <param name="waypointType">180 degree turns are allowed for stopOver but not for passThrough. Waypoints defined through a drag-n-drop action should be marked as pass-through. PassThrough waypoints will not appear in the list of maneuvers. </param>
            /// <param name="stopOverDuration">Stopover delay in seconds. Impacts time-aware calculations. Ignored for passThrough. </param>
            /// <param name="displayPosition">Latitude WGS-84 degrees between -90 and 90. Longitude WGS-84 degrees between -180 and 180. Altitude in meters.</param>
            /// <param name="userLabel">Custom label identifying this waypoint.</param>
            public NavigationWaypointParameterWithStreetPositions(GeoPoint streetPosition, string streetName = null, WaypointType waypointType = WaypointType.None, int stopOverDuration = 0, GeoPoint displayPosition = null, string userLabel = null)
            {
                StreetPosition = streetPosition;
                DisplayPosition = displayPosition;
                StreetName = streetName;
                UserLabel = userLabel;
                StopOverDuration = stopOverDuration;
                WaypointType = waypointType;
            }

            public string GetAsUrlParameter()
            {
                return $"street!" +
                    $"{(WaypointType != WaypointType.None ? Enums.GetDescription(WaypointType) : "")}" +
                    $"{(WaypointType == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(WaypointType != WaypointType.None ? "!" : "")}" +
                    $"{(DisplayPosition != null ? DisplayPosition.GetAsUrlParameter() : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{StreetPosition.GetAsUrlParameter()};" +
                    $"{(StreetName != null ? $"{StreetName}" : "")}";
            }
        }

        public class NavigationWaypointParameterWithLinkPositions : UrlParameter
        {
            public enum LinkDirectionType
            {
                [Description("+")] To,
                [Description("-")] From,
                [Description("*")] Any
            }

            public int LinkId { get; set; }
            public LinkDirectionType LinkDirection { get; set; }
            public float Spot { get; set; }
            public GeoPoint DisplayPosition { get; set; }
            public string UserLabel { get; set; }
            public int StopOverDuration { get; set; }
            public WaypointType WaypointType { get; set; }

            public NavigationWaypointParameterWithLinkPositions(int linkId, LinkDirectionType linkDirection, float spot = float.NaN, WaypointType waypointType = WaypointType.None, int stopOverDuration = 0, GeoPoint displayPosition = null, string userLabel = null)
            {
                LinkId = linkId;
                LinkDirection = linkDirection;
                Spot = spot;
                DisplayPosition = displayPosition;
                UserLabel = userLabel;
                StopOverDuration = stopOverDuration;
                WaypointType = waypointType;
            }

            public string GetAsUrlParameter()
            {
                return $"link!" +
                    $"{(WaypointType != WaypointType.None ? Enums.GetDescription(WaypointType) : "")}" +
                    $"{(WaypointType == WaypointType.StopOver ? $",{StopOverDuration}" : "")}" +
                    $"{(WaypointType != WaypointType.None ? "!" : "")}" +
                    $"{(DisplayPosition != null ? DisplayPosition.GetAsUrlParameter() : "")};" +
                    $"{(UserLabel != null ? $"{UserLabel}" : "")};" +
                    $"{Enums.GetDescription(LinkDirection)}{LinkId},{(Spot != float.NaN ? $"{Spot}" : "0.5")}";
            }
        }

    }
}
