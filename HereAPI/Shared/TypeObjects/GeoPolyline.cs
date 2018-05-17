using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.TypeObjects
{
    public class GeoPolyline
    {

        public GeoCoordinate[] Coordinates { get; set; }

        public GeoPolyline(GeoCoordinate[] coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
