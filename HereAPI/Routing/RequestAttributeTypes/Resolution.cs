using HereAPI.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.RequestAttributeTypes
{
    public class Resolution: IRequestAttribute
    {
        public uint ViewResolution { get; set; }
        public uint? SnapResolution { get; set; }

        public Resolution(uint viewResolution, uint? snapResolution = null)
        {
            ViewResolution = viewResolution;
            SnapResolution = snapResolution;
        }

        public string GetAttributeName()
        {
            return "resolution";
        }

        public string GetAttributeValue()
        {
            return $"{ViewResolution}{(SnapResolution != null ? $",{SnapResolution}" : "")}";
        }
    }
}
