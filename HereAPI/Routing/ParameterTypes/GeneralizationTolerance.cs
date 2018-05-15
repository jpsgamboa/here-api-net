using HereAPI.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.ParameterTypes
{
    public class GeneralizationTolerance : IUrlParameter
    {

        public double LatitudeTolerance { get; set; }
        public double LongitudeTolerance { get; set; }

        public GeneralizationTolerance(double latitudeTolerance, double longitudeTolerance)
        {
            LatitudeTolerance = latitudeTolerance;
            LongitudeTolerance = longitudeTolerance;
        }

        public string GetParameterName()
        {
            return "generalizationTolerances";
        }

        public string GetParameterValue()
        {
            return $"{LatitudeTolerance.ToString(HereAPI.Culture)},{LongitudeTolerance.ToString(HereAPI.Culture)}";
        }
    }
}
