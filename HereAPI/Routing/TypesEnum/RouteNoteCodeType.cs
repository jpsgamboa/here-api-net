using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Defines identifiers for RoutingNote objects. 
    /// </summary>
    public enum RouteNoteCodeType
    {

        /// <summary>
        ///  Contains copyright notices that must be displayed to the end user when using data provided by Transit Agencies.
        /// </summary>
        [Description("copyright")] Copyright,

        /// <summary>
        ///  Indicates that routing options have been violated, in other words, the route contains route features that should have been avoided. The service provides the violated routing feature as text. 
        /// </summary>
        [Description("routingOptionViolated")] RoutingOptionViolated,

        /// <summary>
        /// #N/A
        /// </summary>
        [Description("passingPlace")] PassingPlace,

        /// <summary>
        /// #N/A
        /// </summary>
        [Description("roadNameChanged")] RoadNameChanged,

        /// <summary>
        /// #N/A
        /// </summary>
        [Description("sharpCurveAhead")] SharpCurveAhead,

        /// <summary>
        /// #N/A
        /// </summary>
        [Description("linkFeatureAhead")] LinkFeatureAhead,

        /// <summary>
        ///  Indicates time dependent restrictions for the segment following the maneuver, such as "road closed in winter". The service provides the validity period of this restriction in the corresponding note. 
        /// </summary>
        [Description("timeDependentRestriction")] TimeDependentRestriction,

        /// <summary>
        ///  Indicates the name of a previous intersection in a maneuver, such as for indicating the last intersection before arrival. The service provides the name of the intersection along with a descriptive text in the Text field of the corresponding note, such as "The last intersection is Markkulantie"
        /// </summary>
        [Description("previousIntersection")] PreviousIntersection,

        /// <summary>
        ///  Indicates the name of a next intersection in a maneuver, such as for indicating the first intersection after arrival. The service provides the name of the intersection along with a descriptive text in the Text field of the corresponding note, such as "If you reach Rantalantie, you've gone too far".
        /// </summary>
        [Description("nextIntersection")] NextIntersection,

        /// <summary>
        ///  Indicates that some part of route crosses administrative division border (state, province, etc.)
        /// </summary>
        [Description("adminDivisionChange")] AdminDivisionChange,

        /// <summary>
        ///  Indicates that some part of route crosses country border.
        /// </summary>
        [Description("countryChange")] CountryChange,

        /// <summary>
        ///  Indicates that some part of route enters or leaves a gated area.
        /// </summary>
        [Description("gateAccess")] GateAccess,

        /// <summary>
        ///  Indicates that some part of route runs through a privately owned road.
        /// </summary>
        [Description("privateRoad")] PrivateRoad,

        /// <summary>
        ///  Indicates that some part of route may require a stop at a toll booth.
        /// </summary>
        [Description("tollbooth")] Tollbooth,

        /// <summary>
        ///  Indicates that some parts of the route are toll roads.
        /// </summary>
        [Description("tollroad")] Tollroad,

        /// <summary>
        ///  Indicates that some part of route is unpaved.
        /// </summary>
        [Description("unpavedRoad")] UnpavedRoad,

        /// <summary>
        ///  Indicates that some parts of the route may be subject to turn restrictions.
        /// </summary>
        [Description("restrictedTurn")] RestrictedTurn,

        /// <summary>
        ///  Indicates that some parts of the route violates non-time dependent truck restriction.
        /// </summary>
        [Description("truckRestriction")] TruckRestriction,

        /// <summary>
        ///  Indicates that one should expect seasonal closures on some part of route.
        /// </summary>
        [Description("seasonalClosures")] SeasonalClosures,

        /// <summary>
        ///  Indicates that one should expect congestions on some part of route.
        /// </summary>
        [Description("congestion")] Congestion,

        /// <summary>
        ///  Indicates that there are roadworks expected on some part of route.
        /// </summary>
        [Description("roadworks")] Roadworks,

        /// <summary>
        ///  Indicates that there has been an accident reported on some part of route.
        /// </summary>
        [Description("accident")] Accident,

        /// <summary>
        ///  Indicates that there is a road closure affecting the route.
        /// </summary>
        [Description("closure")] Closure,

        /// <summary>
        ///  Indicates that there is traffic flow (such as sluggish traffic) affecting the route.
        /// </summary>
        [Description("trafficFlow")] TrafficFlow


    }
}
