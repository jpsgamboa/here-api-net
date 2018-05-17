using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// To provide an estimate of time that is as close to the current reality as possible, 
    /// the DynamicSpeedInfoType contains dynamic speed information on the link.<para/>
    /// The service provides this data if the departure time and date is part of the route calculation request. If traffic is enabled for the request, the route calculation accounts for:<para/>
    /// -   time-dependent road closures and maneuvers (such as seasonal closures or reversible lanes)<para/>
    /// -   real-time traffic information and incidents<para/>
    /// -   pattern-based traffic prediction, if the calculation is for a future time<para/>
    /// </summary>
   public class DynamicSpeedInfo
    {
        /// <summary>
        /// Traffic-enabled speed in m/s, which is the estimated speed considering traffic-relevant constraints. 
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Contains the travel time estimate in seconds for this element, considering traffic and transport mode. Based on the TrafficSpeed. The service may also account for additional time penalties, so this may be greater than the element length divided by the TrafficSpeed. 
        /// </summary>
        public double TrafficTime { get; set; }

        /// <summary>
        /// Estimated speed in m/s without considering any traffic-related constraints. 
        /// </summary>
        public double BaseSpeed { get; set; }

        /// <summary>
        /// The number between 0.0 and 10.0 indicating the expected quality of travel, where 0 is high quality and 10.0 is poor quality or high level of traffic jam. -1.0 indicates that the service could not calculate Jam Factor. 
        /// </summary>
        public double JamFactor { get; set; }
    }
}
