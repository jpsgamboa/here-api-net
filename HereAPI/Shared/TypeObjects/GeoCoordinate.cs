using HereAPI.Shared.Structure;
using System;

namespace HereAPI.Shared.TypeObjects
{
    public class GeoCoordinate : IAttribute
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }

        public GeoCoordinate(double latitude, double longitude, double? altitude = null)
        {
            if (latitude < -90 || latitude > 90) throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90");
            if (longitude < -180 || longitude > 180) throw new ArgumentOutOfRangeException("Longitude must be between -90 and 90");

            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public string GetAttributeValue()
        {
            return $"{Latitude.ToString(HereAPI.Culture)},{Longitude.ToString(HereAPI.Culture)}{(Altitude != null ? $",{Altitude.Value.ToString(HereAPI.Culture)}" : "")}";
        }

    }
}
