using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// This type complements maneuver notes with extra information on country change when applicable.
    /// </summary>
    public class CountryChangeDetails
    {
        /// <summary>
        /// Country code of country being entered.
        /// </summary>
        public string ToCountry { get; set; }
    }
}
