using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// The service returns GeneralizationType in route responses for requests carrying the generalizationTolerances parameter. The default is to not return any GeneralizationType
    /// </summary>
    public class Generalization
    {
        /// <summary>
        /// Contains the tolerance level used in the request. 
        /// </summary>
        public double Tolerance { get; set; }

        /// <summary>
        /// Specifies the offset into the global shape array to be used for a given generalization tolerance. 
        /// </summary>
        public int Index { get; set; }

    }
}
