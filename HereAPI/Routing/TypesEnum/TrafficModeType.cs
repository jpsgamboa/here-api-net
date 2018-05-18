using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    
    public enum TrafficModeType
    {
        /// <summary>
        /// No departure time provided: <para/>
        ///  -     This behavior is deprecated and will return error in the future.
        ///  -     Static time based restrictions: Ignored
        ///  -     Real-time traffic closures: Valid for entire length of route.
        ///  -     Real-time traffic flow events: Speed at calculation time used for entire length of route.
        ///  -     Historical and predictive traffic speed: Ignored<para/>
        ///
        /// Departure time provided:<para/>
        ///  -     Static time based restrictions: Avoided if road would be traversed within validity period of the
        ///  -     restriction.
        ///  -     Real-time traffic closures: Avoided if road would be traversed within validity period of the
        ///  -     incident.
        ///  -     Real-time traffic flow events: Speed used if road would be traversed within validity period of the
        ///  -     flow event.
        ///  -     Historical and predictive traffic: Used.<para/>
        /// </summary>
        [Description("enabled")] Enabled,


        /// <summary>
        /// No departure time provided:<para/>
        ///  -     Static time based restrictions: Ignored
        ///  -     Real-time traffic closures: Ignored.
        ///  -     Real-time traffic flow speed: Ignored.
        ///  -     Historical and predictive traffic: Ignored<para/>
        ///
        /// Departure time provided:<para/>
        ///  -     Static time based restrictions: Avoided if road would be traversed within validity period of the
        ///  -     restriction.
        ///  -     Real-time traffic closures: Valid for entire length of route.
        ///  -     Real-time traffic flow speed: Ignored.
        ///  -     Historical and predictive traffic: Ignored<para/>
        ///
        ///    Note: Difference between traffic disabled and enabled affects only the calculation of the route.
        ///    Traffic time of the route will still be calculated for all routes using the same rules as for
        ///    traffic:enabled.<para/>
        /// </summary>
        [Description("disabled")] Disabled,

        /// <summary>
        ///    Let the service automatically apply traffic related constraints that are suitable
        ///    for the selected routing type, transport mode, and departure time.
        ///    Also user entitlements will be taken into consideration.<para/>
        /// </summary>
        [Description("default")] Default
    }
}
