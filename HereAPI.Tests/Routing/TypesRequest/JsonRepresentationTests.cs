using HereAPI.Routing.TypesRequest;
using NUnit.Framework;
using static HereAPI.Routing.TypesRequest.JsonRepresentation;

namespace HereAPI.Tests.Routing.TypesRequest
{
    [TestFixture]
    internal class JsonRepresentationTests
    {
        [Test]
        [TestCase("249", JsonAttribute.FlattenListOfShapesToDoubleArraysLatLon, JsonAttribute.FlattenListOfShapesToDoubleArraysLatLonAlt, JsonAttribute.Include_TypeElement, JsonAttribute.LowerCaseFirstCharIdentifiers, JsonAttribute.SupressJsonResponseObjectWrapper, JsonAttribute.UsePluralNamingForCollections)]
        [TestCase("24", JsonAttribute.Include_TypeElement, JsonAttribute.UsePluralNamingForCollections)]
        [TestCase("24", JsonAttribute.Include_TypeElement, JsonAttribute.UsePluralNamingForCollections, JsonAttribute.UsePluralNamingForCollections)]
        public void ParameterValueFormat(string expected, params JsonAttribute[] jsonAttributes)
        {
            JsonRepresentation jr = new JsonRepresentation(jsonAttributes);
            Assert.AreEqual(expected, jr.GetAttributeValue());
        }
    }
}