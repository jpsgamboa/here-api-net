using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;

namespace HereAPI.Routing.TypesCommon
{
    public class RouteFeature : IAttribute
    {

        public RouteFeatureType FeatureType { get; set; }
        public RouteFeatureWeightType FeatureWeight { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="routeFeatureType">Type of the route feature.</param>
        /// <param name="routeFeatureWeight">The route feature weight.</param>
        public RouteFeature(RouteFeatureType routeFeatureType, RouteFeatureWeightType routeFeatureWeight)
        {
            FeatureType = routeFeatureType;
            FeatureWeight = routeFeatureWeight;
        }

        public string GetAttributeValue()
        {
            return $"{EnumHelper.GetDescription(FeatureType)}:{EnumHelper.GetDescription(FeatureWeight)}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}
