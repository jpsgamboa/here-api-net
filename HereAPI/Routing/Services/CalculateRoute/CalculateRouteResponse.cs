using HereAPI.Routing.TypesResponse;
using HereAPI.Shared.TypeEnums;

namespace HereAPI.Routing.Services.CalculateRoute
{
    class CalculateRouteResponse
    {
        /// <summary>
        /// Provides details about the request itself, such as the time at which it was processed, 
        /// a request id, or the map version on which the calculation was based. 
        /// </summary>
        public RouteResponseMetaInfo MetaInfo { get; set; }

        /// <summary>
        /// Contains the calculated path across a navigable link network, as specified in the request. 
        /// Routes contain navigation instructions for a single trip as: waypoints (fixed locations) 
        /// and route legs (sections of the route between waypoints). Each response may also include 
        /// information about the route itself, such as its overall shape, map location, or a summary 
        /// description. 
        /// </summary>
        public Route[] Routes { get; set; }

        /// <summary>
        /// Indicates the language used for all textual information related to the route.<para/>
        /// If the requested language is unavailable, the service defaults to American English(en-us).<para/>
        /// If the locale of the requested language is unavailable, the service defaults to the generic version 
        /// of the requested language, if available.For example, if the request specifies British English(en-uk), 
        /// and this is unavailable, the service returns the response using American English instead(en-us). 
        /// </summary>
        /// <see cref="https://developer.here.com/documentation/routing/topics/resource-param-type-languages.html#languages"/>
        public LanguageCodeType Language { get; set; }

        /// <summary>
        /// Contains copyright information intended for the end user when route uses data provided by outside companies. 
        /// Source attribution must be displayed together with a route according to terms and conditions of the API. 
        /// </summary>
        public SourceAttribution SourceAttribution { get; set; }

    }
}
