using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    public class RouteResponseMetaInfo
    {
        /// <summary>
        /// Mirrored RequestId value from the request structure. Used to trace requests.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Time at which the search was performed.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gives the version of the underlying map, upon which the route calculations are based.
        /// </summary>
        public string MapVersion { get; set; }

        /// <summary>
        /// Gives a list of map versions, upon which the route calculations are based.
        /// </summary>
        public string[] AvailableMapVersions { get; set; }

        /// <summary>
        /// Gives the version of the module that performed the route calculations.
        /// </summary>
        public string ModuleVersion { get; set; }

        /// <summary>
        /// Required. Gives the version of the schema definition to enable formats 
        /// other than XML to identify elements without using namespaces.
        /// </summary>
        public string InterfaceVersion { get; set; }
        
    }
}
