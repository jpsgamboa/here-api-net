using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{

    /// <summary>
    /// RoadShieldType contains information used to look up road shield imagery
    /// </summary>
    public class RoadShield
    {
        /// <summary>
        /// A string identifying the region where this road shield is used. This may be used to differentiate roadshield images by country. 
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// A string identifying the category of the road shield, such as highways. 
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// A Label identfying the inscription on the road shield, such as containing the road number. 
        /// </summary>
        public string Label { get; set; }


    }
}
