using HereAPI.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing
{
    /// <summary>
    /// Use the calculateroute resource to return a route between two waypoints. 
    /// The required parameters for this resource are app_id and app_code, two or more waypoints
    /// (waypoint0 and waypoint1, to waypointN) and mode (specifying how to calculate the route, 
    /// and for what mode of transport). For some modes departure or arrival (if applicable) is required. 
    /// This includes publicTransportTimeTable, publicTransport and all modes with enabled traffic. 
    /// Other parameters can be left unspecified.
    /// 
    /// <see href="https://developer.here.com/documentation/routing/topics/resource-calculate-route.html">API</see>
    /// </summary>
    class CalculateRoute : Request
    {

        public CalculateRoute(): base("route", "routing/7.2", "calculateroute")
        {

        }

    }
}
