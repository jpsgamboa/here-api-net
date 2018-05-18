using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HereAPI.Shared.Requests
{

    /// <summary>
    /// Requests class specific for Here API.
    /// </summary>
    public abstract class HereApiServiceRequest : Request
    {
        public HereApiRequestValidation Validation { get; set; }

        private string BaseUrl = "";
        private string UrlAttributes = "";

        /// <summary>
        /// Creates the base URL for the api service, appends the App ID and App Code defined in HereAPI.Register()
        /// and handles the option to run in the production server of the custumer integration test (cit) server.
        /// "route", "routing/7.2", "calculateroute"
        /// </summary>
        /// <param name="service">The service API. Example: route, places, geocoder </param>
        /// <param name="path">The path, including the API version. Example: routing/7.2, places/v1, 6.2 </param>
        /// <param name="resource">The </param>
        public HereApiServiceRequest(string service, string path, string resource)
        {
            Validation = new HereApiRequestValidation(this);

            BaseUrl = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppId), HereAPI.Instance.AppId);
            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppCode), HereAPI.Instance.AppCode);
        }

        protected void AddAttribute(string attribute, string value)
        {
            UrlAttributes += $"&{attribute}={value}";
        }

        protected void AddAttribute(IRequestAttribute attribute)
        {
            UrlAttributes += $"&{attribute.GetAttributeName()}={attribute.GetAttributeValue()}";
        }

        /// <summary>
        /// Each request should implement a validation of the value of it's attributes where necessary,
        /// and validate the compatibility of each attribute with the rest.
        /// </summary>
        public abstract string[] ValidateConditionalAttributes();

        /// <summary>
        /// Each request must implement this method where AddAttribute() or AddIRequestAttribute() are called 
        /// for each non null Property
        /// </summary>
        protected abstract void AddSpecifiedAttributes();

        /// <summary>
        /// Each service (Routing, Geocoding, etc) must provide their own type conversions.
        /// </summary>
        protected abstract JsonConverter SetJsonConverter();

        protected override List<JsonConverter> SetJsonConverters()
        {
            var converters = new List<JsonConverter>
            {
                new JsonTypesConverter(new SharedJsonTypeConversions().GetConversions()), //Shared type conversions
                SetJsonConverter() //Service specific conversions
            };
            return converters;
        }

        protected override string SetUrl()
        {
            //TODO should the validator be called here and throw an exception? Or leave it to the user to check for errors?
            if (!Validation.IsValid()) throw new ArgumentException("Attribute error:\n" + string.Join("\n", Validation.GetValidationErrors()));
            AddSpecifiedAttributes();
            return BaseUrl + UrlAttributes;
        }

    }
}
