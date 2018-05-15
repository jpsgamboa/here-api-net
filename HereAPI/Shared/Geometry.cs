using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared
{
    public class Geometry
    {

        public class GeoPoint
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double Altitude { get; set; }

            public GeoPoint(double latitude, double longitude, double altitude = int.MinValue)
            {
                Latitude = latitude;
                Longitude = longitude;
                Altitude = altitude;
            }

            public string GetParameterValue()
            {
                return $"{Latitude.ToString(HereAPI.Culture)},{Longitude.ToString(HereAPI.Culture)}{(Altitude != int.MinValue ? $",{Altitude.ToString(HereAPI.Culture)}" : "")}";
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }

        public class BoundingBox
        {
            public GeoPoint TopLeft { get; set; }
            public GeoPoint BottomRight { get; set; }

            public BoundingBox(GeoPoint topLeft, GeoPoint bottomRight)
            {
                TopLeft = topLeft;
                BottomRight = bottomRight;
            }

            public string GetParameterValue()
            {
                return $"{TopLeft.GetParameterValue()},{BottomRight.GetParameterValue()}";
            }

        }

    }
}
