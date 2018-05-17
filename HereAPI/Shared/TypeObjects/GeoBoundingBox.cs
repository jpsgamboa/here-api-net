using HereAPI.Shared.Structure;

namespace HereAPI.Shared.TypeObjects
{
    public class GeoBoundingBox : IAttribute
    {
        public GeoCoordinate TopLeft { get; set; }
        public GeoCoordinate BottomRight { get; set; }

        public GeoBoundingBox(GeoCoordinate topLeft, GeoCoordinate bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public string GetAttributeValue()
        {
            return $"{TopLeft.GetAttributeValue()},{BottomRight.GetAttributeValue()}";
        }

    }
}
