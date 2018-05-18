using HereAPI.Shared.Structure;

namespace HereAPI.Routing.TypesRequest
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

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}
