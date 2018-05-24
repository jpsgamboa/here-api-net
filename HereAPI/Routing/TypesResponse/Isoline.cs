using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json;

namespace HereAPI.Routing.TypesResponse
{
    public class Isoline
    {
        /// <summary>
        /// Range used to calculate this isoline.
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// List of components. Component describes one reached area in the isoline.
        /// </summary>
        public IsolineComponent[] Components { get; set; }

        /// <summary>
        /// List of connections. Connection may be a ferry which connects 2 islands.
        /// </summary>
        public IsolineConnection[] Connections { get; set; }

        /// <summary>
        /// Component represents independent part of the isoline separated by connection
        /// </summary>
        public class IsolineComponent
        {
            /// <summary>
            /// Key that identifies this element uniquely within the response.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            /// Polygon which covers the reached area.
            /// </summary>
            public GeoPolyline Shape { get; set; }
        }

        /// <summary>
        /// Connection represents the geometry of special links, which were reached, but not included
        /// in the components. (IsolineComponentType). These links are connections like ferries
        /// </summary>
        public class IsolineConnection
        {
            /// <summary>
            /// The index of the start component
            /// </summary>
            public string FromId { get; set; }

            /// <summary>
            /// The index of the end component
            /// </summary>
            public string ToId { get; set; }

            /// <summary>
            /// Shape of the connection
            /// </summary>
            public GeoPolyline Shape { get; set; }
        }
    }
}