using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HereAPI.Shared.Requests
{
    /// <summary>
    /// Requests class specific for Here API.
    /// <para/>
    /// Extends <see cref="Request"/> for the request functionality.
    /// <para/>
    /// <para/>
    /// Each service must extend this class and add a property for each attribute of the request URL.
    /// <para/>
    /// <para/>
    /// The basic type properties of classes that extend this class should have <see
    /// cref="System.ComponentModel.DataAnnotations"/> for validation (such as Required, Range..)
    /// <para/>
    /// <para/>
    /// User defined objects should implement <see cref="IAttribute"/> to have their own <see
    /// cref="IAttribute.Validate"/> method.
    /// <para/>
    /// Before the request is made, all attributes should be validated and an error thrown if any
    /// attribute is invalid.
    /// <para/>
    /// See the <see cref="HereApiRequestValidation"/> class for move info.
    /// </summary>
    public abstract class HereApiServiceRequest : Request
    {
        public HereApiRequestValidation Validation { get; set; }

        [Required]
        private string BaseUrl = "";

        private string UrlAttributes = "";

        /// <summary>
        /// Creates the base URL for the api service, appends the App ID and App Code defined in
        /// HereAPI.Register() and handles the option to run in the production server of the custumer
        /// integration test (cit) server. "route", "routing/7.2", "calculateroute" See each
        /// service's Guide page on the API website to get the parameters.
        /// </summary>
        /// <param name="service"> The service API. Example: route, places, geocoder</param>
        /// <param name="path">    
        /// The path, including the API version. Example: routing/7.2, places/v1, 6.2
        /// </param>
        /// <param name="resource">The</param>
        public HereApiServiceRequest(string service, string path, string resource)
        {
            Validation = new HereApiRequestValidation(this);

            BaseUrl = $"https://{service}{(HereAPISession.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddAttribute(PropertyHelper.GetDescription(() => HereAPISession.Instance.AppId), HereAPISession.Instance.AppId);
            AddAttribute(PropertyHelper.GetDescription(() => HereAPISession.Instance.AppCode), HereAPISession.Instance.AppCode);
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
        /// Each request should implement a validation of the value of it's attributes where
        /// necessary, and validate the compatibility of each attribute with the rest.
        /// </summary>
        public abstract string[] ValidateConditionalAttributes();

        /// <summary>
        /// Each request must implement this method where <see
        /// cref="AddAttribute(IRequestAttribute)"/> or <see cref="AddAttribute(string, string)"/>
        /// are called for each non-null Property
        /// </summary>
        protected abstract void AddSpecifiedAttributes();

        /// <summary>
        /// Each service (Routing, Geocoding, etc) must provide their own type conversions.
        /// </summary>
        protected abstract JsonConverter SetJsonConverter();

        /// <summary>
        /// Adds the <see cref="SharedJsonTypeConversions"/> and the service specific <see
        /// cref="ITypeConversions"/> to the <see cref="JsonConverter"/> object of the <see
        /// cref="Request"/> base class. See <see cref="JsonTypesConverter"/> class for more info.
        /// </summary>
        /// <returns></returns>
        protected override List<JsonConverter> SetJsonConverters()
        {
            var converters = new List<JsonConverter>
            {
                new JsonTypesConverter(new SharedJsonTypeConversions().GetConversions()), //Shared type conversions
                SetJsonConverter() //Service specific conversions
            };
            return converters;
        }

        /// <summary>
        /// Triggers the derived service class to convert it's non-null properties into the their
        /// request URL format. Compiles the final request URL joining the base URL with all the attributes.
        /// </summary>
        /// <returns>The final request URL</returns>
        protected override string SetUrl()
        {
            //TODO should the validator be called here and throw an exception? Or leave it to the user to check for errors?
            if (!Validation.IsValid())
                throw new ArgumentException("Attribute error:\n" + string.Join("\n", Validation.GetValidationErrors()));
            AddSpecifiedAttributes();
            return BaseUrl + UrlAttributes;
        }
    }
}