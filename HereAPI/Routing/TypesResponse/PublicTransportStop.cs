using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Instances of PublicTransportStopType Represent stops on a public transport line. Stops are
    /// different from stations as they are bound to a specific public transport line and a direction
    /// of travel, indicated by the line's destination.
    /// </summary>
    public class PublicTransportStop
    {
        /// <summary>
        /// Key that identifies this element uniquely within the response
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The position of this stop.
        /// </summary>
        public GeoCoordinate Position { get; set; }

        /// <summary>
        /// Reference key to the PublicTransportLine object
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// The name of this stop.
        /// </summary>
        public string StopName { get; set; }

        /// <summary>
        /// The time in seconds required to travel from this stop to the next one using the public
        /// transport line specified in the 'Line' element. Note that this value can be 0.
        /// </summary>
        public double TravelTime { get; set; }
    }
}