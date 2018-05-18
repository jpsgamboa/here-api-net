using HereAPI.Shared.Structure;
using System.Linq;

namespace HereAPI.Routing.TypesRequest
{
    public class JsonRepresentation : IRequestAttribute
    {
        public int JsonAttributesSum { get; set; }

        /// <summary>
        /// Only use this parameter if you only intend to get the compiled URL and not make the
        /// request using this library. As this changes the JSON response, it's likely that the
        /// library will fail to deserialize it.
        /// </summary>
        /// <param name="jsonAttributes"></param>
        public JsonRepresentation(params JsonAttribute[] jsonAttributes)
        {
            jsonAttributes = jsonAttributes.Distinct().ToArray();

            foreach (JsonAttribute attr in jsonAttributes)
            {
                JsonAttributesSum += (int)attr;
            }
        }

        public string GetAttributeName()
        {
            return "jsonAttributes";
        }

        public string GetAttributeValue()
        {
            return $"{JsonAttributesSum}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }

        public enum JsonAttribute
        {
            /// <summary>
            /// Lower case first character of identifiers, this is default behaviour.
            /// </summary>
            LowerCaseFirstCharIdentifiers = 1,

            /// <summary>
            /// Include _type element in JSON output for classes with abstract parent classes, this
            /// is default behaviour.
            /// </summary>
            Include_TypeElement = 8,

            /// <summary>
            /// Use plural naming for collections. The default is to use singular naming.
            /// </summary>
            UsePluralNamingForCollections = 16,

            /// <summary>
            /// Flatten list of shape strings to double arrays containing lat/lon pairs. Potentially
            /// available altitude values are not returned. By default shapes are returned as lists
            /// of strings.
            /// </summary>
            FlattenListOfShapesToDoubleArraysLatLon = 32,

            /// <summary>
            /// Flatten list of shape strings to double arrays containing lat/lon/alt triplets.
            /// Altitude values are returned if available. By default shapes are returned as lists of strings.
            /// </summary>
            FlattenListOfShapesToDoubleArraysLatLonAlt = 64,

            /// <summary>
            /// Supress JSON response object wrapper.
            /// </summary>
            SupressJsonResponseObjectWrapper = 128
        }
    }
}