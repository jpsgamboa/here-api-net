using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.TypeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{

    /// <summary>
    ///  Route notes are used to store additional information about the route. 
    ///  These notes can either be related to the calculation itself (like violated routing options) 
    ///  or to the characteristics of the route (like entering a toll road, passing a border, etc.)
    /// </summary>
    public class RouteNote
    {

        /// <summary>
        /// Type of the note.
        /// </summary>
        public RouteNoteType Type { get; set; }

        /// <summary>
        /// A code that uniquely identifies the note. This code can be used to decide how to display
        /// the note (such as with a warning icon).
        /// </summary>
        public RouteNoteCodeType Code { get; set; }

        /// <summary>
        /// A short text describing the note. Please note that this attribute is not subject to internationalization and should therefore not be used in user displays. 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Container for additional data to be stored along with the note. 
        /// </summary>
        public KeyValuePair[] AdditionalData { get; set; }

        /// <summary>
        /// Details of the country change. Provided only in case of country change notes (notes with Code element value set to countryChange). 
        /// </summary>
        public CountryChangeDetails CountryChangeDetails { get; set; }

    }
}
