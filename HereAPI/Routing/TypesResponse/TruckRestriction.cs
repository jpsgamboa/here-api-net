using HereAPI.Routing.TypesEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    public class TruckRestriction
    {
        /// <summary>
        /// Marks element as forbidden for trucks with trailers. 
        /// </summary>
        public bool TrailerForbidden { get; set; }

        /// <summary>
        /// Indicates forbidden hazardous materials types. 
        /// </summary>
        public HazardousGoodType[] ForbiddenHazardousGoods { get; set; }

        /// <summary>
        /// Indicates maximum weight in tons. 
        /// </summary>
        public double LimitedWeight { get; set; }

        /// <summary>
        /// Indicates maximum weight per axle in tons. 
        /// </summary>
        public double WeightPerAxle { get; set; }

        /// <summary>
        /// Indicates maximum truck height in meters. 
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Indicates maximum truck width in meters. 
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Indicates maximum truck length in meters. 
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Indicates the category of the tunnel on the link (B|C|D|E). 
        /// </summary>
        public TunnelCategoryType? TunnelCategory { get; set; }

    }
}
