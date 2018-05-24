using HereAPI.Routing.Conversions;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests;
using Newtonsoft.Json;

namespace HereAPI.Routing.Services
{
    public abstract class RoutingRequest : HereApiServiceRequest
    {
        /// <summary>
        /// Since Routing Requests have common types, makes sense to have a base class to handle the
        /// json conversions and avoid repetition on each request (calculateRoute, getRoute, etc)
        /// </summary>
        /// <param name="service"> </param>
        /// <param name="path">    </param>
        /// <param name="resource"></param>
        public RoutingRequest(string service, string path, string resource) : base(service, path, resource)
        {
        }

        protected override JsonConverter SetJsonConverter()
        {
            return new JsonTypesConverter(new RoutingJsonTypeConversions().GetConversions());
        }
    }
}