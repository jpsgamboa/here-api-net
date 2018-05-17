using HereAPI.Routing.TypesEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Reference to an external resource (for example, a bitmap). The client is responsible for retrieving the referenced resource.
    /// </summary>
    public class ExternalResource
    {
        /// <summary>
        /// The semantics of the resource.
        /// </summary>
        public ResourceType? ResourceType { get; set; }

        /// <summary>
        /// Filename of the resource
        /// </summary>
        public string Filename { get; set; }

    }
}
