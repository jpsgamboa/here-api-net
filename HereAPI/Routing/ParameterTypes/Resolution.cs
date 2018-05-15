using HereAPI.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.ParameterTypes
{
    public class Resolution: IUrlParameter
    {
        public uint ViewResolution { get; set; }
        public uint? SnapResolution { get; set; }

        public Resolution(uint viewResolution, uint? snapResolution = null)
        {
            ViewResolution = viewResolution;
            SnapResolution = snapResolution;
        }

        public string GetParameterName()
        {
            return "resolution";
        }

        public string GetParameterValue()
        {
            return $"{ViewResolution}{(SnapResolution != null ? $",{SnapResolution}" : "")}";
        }
    }
}
