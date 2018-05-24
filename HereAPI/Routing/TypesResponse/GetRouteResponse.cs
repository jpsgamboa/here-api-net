using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.TypeEnums;

namespace HereAPI.Routing.Services.TypeResponse
{
    /// <summary>
    /// CalculateRouteResponseType contains response data, structured to match a particular request
    /// for the CalculateRoute operation. The Route element may appear more than once in the response
    /// if multiple routes are available between the start and end points. <see href="https://developer.here.com/documentation/routing/topics/resource-type-calculate-route.html"/>
    /// </summary>
    public class GetRouteResponse
    {
        /// <summary>
        /// Provides details about the request itself, such as the time at which it was processed, a
        /// request id, or the map version on which the calculation was based. <see href="https://developer.here.com/documentation/routing/topics/resource-type-route-response-meta-info.html#resource-type-route-response-meta-info"/>
        /// </summary>
        public RouteResponseMetaInfo MetaInfo { get; set; }

        /// <summary>
        /// Contains the calculated path across a navigable link network, as specified in the
        /// request. Routes contain navigation instructions for a single trip as: waypoints (fixed
        /// locations) and route legs (sections of the route between waypoints). Each response may
        /// also include information about the route itself, such as its overall shape, map location,
        /// or a summary description. <see href="https://developer.here.com/documentation/routing/topics/resource-type-route.html"/>
        /// </summary>
        public Route[] Routes { get; set; }

        /// <summary> Indicates the language used for all textual information related to the
        /// route.<para/> If the requested language is unavailable, the service defaults to American
        /// English(en-us).<para/> If the locale of the requested language is unavailable, the
        /// service defaults to the generic version of the requested language, if available.For
        /// example, if the request specifies British English(en-uk), and this is unavailable, the
        /// service returns the response using American English instead(en-us). </summary> <see href'="https://developer.here.com/documentation/routing/topics/resource-param-type-languages.html#languages"/>
        public LanguageCodeType? Language { get; set; }
    }
}