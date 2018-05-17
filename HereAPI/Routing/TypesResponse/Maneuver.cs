using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{

    /// <summary>
    /// A maneuver describes the action needed to leave one street segment and 
    /// enter the following street segment to progress along the route. 
    /// This type is an abstract base class for PrivateTransportManeuverType and PublicTransportManeuverType . 
    /// It includes only attributes that are common for any given maneuver type
    /// <see href="https://developer.here.com/documentation/routing/topics/resource-type-maneuver.html"/>
    /// <seealso href="https://developer.here.com/documentation/routing/topics/resource-type-private-transport-maneuver.html"/>
    /// <seealso href="https://developer.here.com/documentation/routing/topics/resource-type-public-transport-maneuver.html"/>
    /// </summary>
    public abstract class Maneuver
    {
        /// <summary>
        /// Key that identifies this element uniquely within the response.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Position where the maneuver starts.
        /// </summary>
        public GeoCoordinate Position { get; set; }

        /// <summary>
        /// Description of the required maneuver, for example, "Turn left onto Minna St." 
        /// Response format for this description can be either text or HTML as selected in  
        /// InstructionFormatType , and using the measurement system specified in the request, 
        /// either metric or imperial. The units for imperial system are based on language 
        /// specified in request. It will be feet for en-US and yards for en-UK.<para/>
        /// For an automated unit conversion, we recommend using MetricSystem=metric, 
        /// which returns values in kilometers and meters instead of yards and miles.
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// Describes the amount of time in seconds for a single maneuver, traffic considered if this has been enabled. 
        /// </summary>
        public double TravelTime { get; set; }

        /// <summary>
        /// Length (in meters) for the leg between this maneuver and the next. 
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Shape of the leg between this maneuver and the next.
        /// </summary>
        public GeoPolyline Shape { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the first point of the shape subsegment associated with this Maneuver. 
        /// Must be followed by LastPoint. 
        /// </summary>
        public int FirstPoint { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the last point of the shape subsegment associated with this Maneuver. 
        /// Must be preceded by FirstPoint. 
        /// </summary>
        public int LastPoint { get; set; }

        /// <summary>
        /// Estimated point in time when the maneuver should occur, based on the selected transport mode. Options include:<para/>
        /// Public transport: time at which the user is expected to begin this maneuver, see Public Transport Routing for information
        /// on how to compute the departure time of the line.<para/>
        /// Private transport: calculated departure time for the maneuver.<para/>
        /// In both cases the time is given in the timezone of the maneuver's starting position. See also Public Transport Routing for
        /// information on differences between time handling in each routing mode. <para/>
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Additional information about the route segment following the maneuver, such as "sharp curve ahead", "accessing toll road", etc. 
        /// </summary>
        public RouteNote Note { get; set; }

        /// <summary>
        /// Reference to the next maneuver on the recommended route. 
        /// </summary>
        public string NextManeuver { get; set; }

        /// <summary>
        /// The key of the next outgoing link. 
        /// </summary>
        public LinkId ToLink { get; set; }

        /// <summary>
        /// Coordinates defining the bounding box of the entire maneuver. 
        /// </summary>
        public GeoBoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Shape quality between current maneuver and the next one. Shape quality may vary depending on the transport mode chosen.
        /// </summary>
        public ShapeQualityType? ShapeQuality { get; set; }
    }

    /// <summary>
    /// This type represents a maneuver relevant for public transport such as bus, train. 
    /// This type is derived from the abstract type ManueverType.<para/>
    /// Three different types of public transport maneuvers are supported: "Enter", "Change" and "Leave" 
    /// (see enumeration type  PublicTransportActionType ). A direct change between two transport lines 
    /// is represented with two maneuvers: one for the action "Leave" and a subsequent one to "Enter" 
    /// the next transport line.
    /// </summary>
    public class PublicTransportManeuver : Maneuver
    {
        /// <summary>
        /// Identifier for the action to be performed at this maneuver.
        /// </summary>
        public PublicTransportAcionType? Action { get; set; }

        /// <summary>
        /// Name of the stop where the user has to leave (action == "Leave"), 
        /// change (action == "Change") or enter (action == "Enter") the transport line. 
        /// </summary>
        public string StopName { get; set; }


        /// <summary>
        /// Platform name where the transport line arrives at a station. 
        /// Applicable for "Leave" and "Change" maneuvers. 
        /// </summary>
        public string ArrivalPlatform { get; set; }

        /// <summary>
        /// Platform name where the transport line departs from a station. 
        /// Applicable for "Enter" and "Change" maneuvers. 
        /// </summary>
        public string DeparturePlatform { get; set; }

        /// <summary>
        /// Reference key to the PublicTransportLine object. To reduce data volume, 
        /// the PublicTransport element is not directly embedded in the ManeuverType object, but is swapped out into the Route element. 
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Reference key to the PublicTransportLine object for the target line. 
        /// This element is only provided in case of a "change" Maneuver 
        /// (action == "Change" and if returning of "change" maneuvers has been 
        /// requested using the "CombineChange" flag in PublicTransportProfile . 
        /// To reduce data volume, the PublicTransport element is not directly
        /// embedded in the ManeuverType object, but is swapped out into the Route element. 
        /// </summary>
        public string ToLine { get; set; }

        /// <summary>
        /// Name of the access point where the user has to enter or leave the public transport station. 
        /// Presence of this attribute depends on data availability.
        /// </summary>
        public string AccessPointName { get; set; }

        /// <summary>
        /// Name of the road towards which the exit should be taken for action="Leave". 
        /// </summary>
        public string NextRoadName { get; set; }

        /// <summary>
        /// Waiting time in seconds applicable to the current maneuver. 
        /// Represents time between start time of maneuver (attribute time) and actual transit departure time.
        /// </summary>
        public double WaitTime { get; set; }

        /// <summary>
        /// When a public transport leg contains estimated times, this value contains the maximum deviation possible. 
        /// If any maneuver contains a value for this field, then the flag containsTimeEstimate will be listed in 
        /// the publicTransportFlags list of the route summary.
        /// </summary>
        public double TimeEstimatePrecision { get; set; }

        /// <summary>
        /// A list of reference keys to all PublicTransportTicket objects that correspond to the public transport 
        /// journey starting at this maneuver, i.e. "Enter" and "Change" maneuvers when some ticket covers this maneuver. 
        /// References are in the format Tx.y where Tx is a set of tickets from the PublicTransportTickets section 
        /// and Tx.y is one PublicTransportTicket within that set. If PublicTransportTickets are provided for a route 
        /// and an Enter / Change maneuver does not have a "Ticket" element, then ticket information for this part of 
        /// the journey is not available. 
        /// </summary>
        public string[] Ticket { get; set; }

        /// <summary>
        /// Departure delay in seconds applicable to the current maneuver. Represents the difference between the actual 
        /// transit departure time taken from the real time information and the scheduled departure time. 
        /// The delay can have negative value, meaning that the public transport departed earlier than scheduled. 
        /// If the real time information is not available or the delay is zero, the DepartureDelay element is missing.
        /// </summary>
        public double DepartureDelay { get; set; }

        /// <summary>
        /// Arrival delay in seconds applicable to the current maneuver. 
        /// Represents the difference between the actual transit arrival 
        /// time taken from the real time information and the scheduled arrival time. 
        /// The delay can have negative value, meaning that the public transport arrived earlier than scheduled. 
        /// If the real time information is not available or the delay is zero, the ArrivalDelay element is missing.
        /// </summary>
        public double ArrivalDelay { get; set; }

    }

    /// <summary>
    /// A private transport could be a car, truck, or pedestrian. 
    /// This type represents a maneuver relevant in those scenarios, and is derived from the abstract type ManueverType.
    /// </summary>
    public class PrivateTransportManeuver : Maneuver
    {
        /// <summary>
        /// Maneuver direction hint. Can be used to display the appropriate arrow icon for the maneuver. 
        /// </summary>
        public DirectionType? Direction { get; set; }

        /// <summary>
        /// Code that identifies the action for this maneuver. Does not always indicate a direction. 
        /// </summary>
        public PrivateTransportActionType? Action { get; set; }

        /// <summary>
        /// Name of the road on which the maneuver begins. 
        /// </summary>
        public string RoadName { get; set; }

        /// <summary>
        /// Sign text indicating the direction a driver should follow, for example, 
        /// "Flughafen Berlin-Tegel, Berlin-Zentrum, Berlin-Zehlendorf, Potsdam-Zentrum, A115" 
        /// </summary>
        public string SignPost { get; set; }

        /// <summary>
        /// Name of the next road in the route that the maneuver is heading toward. 
        /// </summary>
        public string NextRoadName { get; set; }

        /// <summary>
        /// Number of the road where the maneuver starts (for example, A5, B49). 
        /// </summary>
        public string RoadNumber { get; set; }

        /// <summary>
        /// Number of the road (such as A5, B49, etc.) towards which the maneuver is heading. 
        /// </summary>
        public string NextRoadNumber { get; set; }

        /// <summary>
        /// Name of the freeway exit to be taken at the maneuver. 
        /// </summary>
        public string FreewayExit { get; set; }

        /// <summary>
        /// Name of the freeway junction for the current maneuver. 
        /// </summary>
        public string FreewayJunction { get; set; }

        /// <summary>
        /// Traffic-enabled time. Estimated time in seconds spent on the segment following this maneuver, based on the TrafficSpeed. The service may also account for additional time penalties, therefore this may be greater than the link length divided by the traffic speed. 
        /// </summary>
        public double TrafficTime { get; set; }

        /// <summary>
        /// Estimated time in seconds spent on the segment following this maneuver, without considering traffic conditions, as it is based on the BaseSpeed. The service may also account for additional time penalties, therefore this may be greater than the link length divided by the base speed. 
        /// </summary>
        public double BaseTime { get; set; }

        /// <summary>
        /// Information that can be used to look up a visual representation of the road shield associated with this maneuver. 
        /// </summary>
        public RoadShield RoadShield { get; set; }

        /// <summary>
        /// Start angle information for the given maneuver, measured in degrees from 0 to 359. A value of 0 represents north, while a value of 90 represents east. Angles increase clockwise. 
        /// </summary>
        public int StartAngle { get; set; }

    }


}
