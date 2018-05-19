using HereAPI.Shared.Structure;
using System.ComponentModel.DataAnnotations;

namespace HereAPI.Shared.TypeObjects
{
    public class GeoCoordinate : IAttribute
    {
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double Latitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Longitude must be between -180 and 180")]
        public double Longitude { get; set; }

        public double? Altitude { get; set; }

        public GeoCoordinate(double latitude, double longitude, double? altitude = null)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public string GetAttributeValue()
        {
            return $"{Latitude.ToString(HereAPISession.Culture)},{Longitude.ToString(HereAPISession.Culture)}{(Altitude != null ? $",{Altitude.Value.ToString(HereAPISession.Culture)}" : "")}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}