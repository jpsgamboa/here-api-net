using HereAPI.Shared.Structure;

namespace HereAPI.Routing.TypesRequest
{
    public class GeneralizationTolerance : IRequestAttribute
    {
        public double LatitudeTolerance { get; set; }
        public double LongitudeTolerance { get; set; }

        public GeneralizationTolerance(double latitudeTolerance, double longitudeTolerance)
        {
            LatitudeTolerance = latitudeTolerance;
            LongitudeTolerance = longitudeTolerance;
        }

        public string GetAttributeName()
        {
            return "generalizationTolerances";
        }

        public string GetAttributeValue()
        {
            return $"{LatitudeTolerance.ToString(HereAPI.Culture)},{LongitudeTolerance.ToString(HereAPI.Culture)}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}