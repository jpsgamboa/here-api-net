using Newtonsoft.Json;

namespace HereAPI.Routing.TypesResponse
{
    public class PublicTransportTickets
    {
        /// <summary>
        /// Sequential ID of the ticket set -- T1, T2, etc.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Information about a single ticket in this set of tickets
        /// </summary>
        [JsonProperty("PublicTransportTickets")]
        public PublicTransportTicket[] Tickets { get; set; }
    }

    public class PublicTransportTicket
    {
        /// <summary>
        /// Sequential ID of the ticket based on the parent ticket set. Set T1 contains T1.1, T1.2,
        /// ...; T2 contains T2.1, T2.2, ..., etc.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the ticket in the local transport system.
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// The ISO-4217 code of the currency the ticket price is listed in.
        /// </summary>
        /// Name
        public string Currency { get; set; }

        /// <summary>
        /// The price of the ticket as a floating point number.
        /// </summary>
        public double Price { get; set; }
    }
}