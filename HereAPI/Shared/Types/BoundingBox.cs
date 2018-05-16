using HereAPI.Shared.Structure;

namespace HereAPI.Shared.Types
{
    public class BoundingBox : IAttribute
    {
        public GeoPoint TopLeft { get; set; }
        public GeoPoint BottomRight { get; set; }

        public BoundingBox(GeoPoint topLeft, GeoPoint bottomRight)
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
