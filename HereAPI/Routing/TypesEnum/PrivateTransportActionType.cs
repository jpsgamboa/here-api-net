using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    public enum PrivateTransportActionType
    {
        /// <summary>
        /// Departure Maneuver, Such As "Start At"
        /// </summary>
        [Description("depart")] Depart,

        /// <summary>
        /// Departure At An Airport Maneuver, Such As "Start Toward The Airport Exit"
        /// </summary>
        [Description("departAirport")] DepartAirport,

        /// <summary>
        /// Identifer For An Arrival Maneuver., Such As "Arrive At"
        /// </summary>
        [Description("arrive")] Arrive,

        /// <summary>
        /// Identifer For An Arrival At The Airport Maneuver, Such As "Follow The Signs To Your Terminal"
        /// </summary>
        [Description("arriveAirport")] ArriveAirport,

        /// <summary>
        /// Identifer For An Arrival Maneuver With The Destination On The Left-Hand Side, Such As
        /// "Arrive At"
        /// </summary>
        [Description("arriveLeft")] ArriveLeft,

        /// <summary>
        /// Identifer For An Arrival Maneuver With The Destination On The Right-Hand Side, Such As
        /// "Arrive At"
        /// </summary>
        [Description("arriveRight")] ArriveRight,

        /// <summary>
        /// Left-Hand Loop Maneuver., Such As "Make A Left-Hand Loop Onto"
        /// </summary>
        [Description("leftLoop")] LeftLoop,

        /// <summary>
        /// Left-Hand U-Turn Maneuver., Such As "Make A U-Turn At"
        /// </summary>
        [Description("leftUTurn")] LeftUTurn,

        /// <summary>
        /// Sharp Left Turn Maneuver., Such As "Make A Hard Left Turn Onto"
        /// </summary>
        [Description("sharpLeftTurn")] SharpLeftTurn,

        /// <summary>
        /// Left Turn Maneuver, Such As "Turn Left On"
        /// </summary>
        [Description("leftTurn")] LeftTurn,

        /// <summary>
        /// Slight Left Turn Maneuver., Such As "Bear Left Onto"
        /// </summary>
        [Description("slightLeftTurn")] SlightLeftTurn,

        /// <summary>
        /// Continue Maneuver, Such As "Continue On"
        /// </summary>
        [Description("continue")] Continue,

        /// <summary>
        /// Slight Right Turn Maneuver., Such As "Bear Right Onto"
        /// </summary>
        [Description("slightRightTurn")] SlightRightTurn,

        /// <summary>
        /// Right Turn Maneuver, Such As "Turn Right On"
        /// </summary>
        [Description("rightTurn")] RightTurn,

        /// <summary>
        /// Sharp Right Turn Maneuver., Such As "Make A Hard Right Turn Onto"
        /// </summary>
        [Description("sharpRightTurn")] SharpRightTurn,

        /// <summary>
        /// Right U-Turn Maneuver., Such As "Make A Right U-Turn At"
        /// </summary>
        [Description("rightUTurn")] RightUTurn,

        /// <summary>
        /// Right Loop Maneuver, Such As "Make A Right-Hand Loop Onto"
        /// </summary>
        [Description("rightLoop")] RightLoop,

        /// <summary>
        /// Left Exit Maneuver, Such As "Take The Left Exit To"
        /// </summary>
        [Description("leftExit")] LeftExit,

        /// <summary>
        /// Right Exit Maneuver, Such As "Take The Right Exit To"
        /// </summary>
        [Description("rightExit")] RightExit,

        /// <summary>
        /// Left Ramp Maneuver, Such As "Take The Left Ramp Onto"
        /// </summary>
        [Description("leftRamp")] LeftRamp,

        /// <summary>
        /// Right Ramp Maneuver, Such As "Take The Right Ramp Onto"
        /// </summary>
        [Description("rightRamp")] RightRamp,

        /// <summary>
        /// Left Fork Maneuver, Such As "Take The Left Fork Onto"
        /// </summary>
        [Description("leftFork")] LeftFork,

        /// <summary>
        /// Middle Fork Maneuver, Such As "Take The Middle Fork Onto"
        /// </summary>
        [Description("middleFork")] MiddleFork,

        /// <summary>
        /// Right Fork Maneuver, Such As "Take The Right Fork Onto"
        /// </summary>
        [Description("rightFork")] RightFork,

        /// <summary>
        /// Left Merge Maneuver, Such As "Merge Left Onto"
        /// </summary>
        [Description("leftMerge")] LeftMerge,

        /// <summary>
        /// Right Merge Maneuver, Such As "Merge Right Onto"
        /// </summary>
        [Description("rightMerge")] RightMerge,

        /// <summary>
        /// Name Change Maneuver (No Maneuver Action Needed), Such As "Road Becomes"
        /// </summary>
        [Description("nameChange")] NameChange,

        /// <summary>
        /// Traffic Circle Maneuver, Such As "At The Traffic Circle Take The Exit To"
        /// </summary>
        [Description("trafficCircle")] TrafficCircle,

        /// <summary>
        /// Ferry Maneuver, Such As "Take The Ferry To"
        /// </summary>
        [Description("ferry")] Ferry,

        /// <summary>
        /// #N/A
        /// </summary>
        [Description("ferryleftExit")] FerryleftExit,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The First Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit1")] LeftRoundaboutExit1,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The Second Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit2")] LeftRoundaboutExit2,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The Third Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit3")] LeftRoundaboutExit3,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The Fourth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit4")] LeftRoundaboutExit4,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The Fifth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit5")] LeftRoundaboutExit5,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The Sixth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit6")] LeftRoundaboutExit6,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 7Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit7")] LeftRoundaboutExit7,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 8Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit8")] LeftRoundaboutExit8,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 9Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit9")] LeftRoundaboutExit9,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 10Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit10")] LeftRoundaboutExit10,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 11Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit11")] LeftRoundaboutExit11,

        /// <summary>
        /// Roundabout Maneuver (Left-Hand Traffic), Such As "Take The 12Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("leftRoundaboutExit12")] LeftRoundaboutExit12,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The First Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit1")] RightRoundaboutExit1,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The Second Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit2")] RightRoundaboutExit2,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The Third Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit3")] RightRoundaboutExit3,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The Fourth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit4")] RightRoundaboutExit4,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The Fifth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit5")] RightRoundaboutExit5,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The Sixth Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit6")] RightRoundaboutExit6,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 7Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit7")] RightRoundaboutExit7,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 8Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit8")] RightRoundaboutExit8,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 9Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit9")] RightRoundaboutExit9,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 10Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit10")] RightRoundaboutExit10,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 11Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit11")] RightRoundaboutExit11,

        /// <summary>
        /// Roundabout Maneuver (Right-Hand Traffic), Such As "Take The 12Th Exit Of The Roundabout Onto"
        /// </summary>
        [Description("rightRoundaboutExit12")] RightRoundaboutExit12
    }
}