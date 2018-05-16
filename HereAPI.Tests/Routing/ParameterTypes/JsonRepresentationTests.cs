using HereAPI.Routing.RequestAttributeTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HereAPI.Routing.RequestAttributeTypes.JsonRepresentation;

namespace HereAPI.Tests.Routing.ParameterTypes
{
    [TestFixture]
    class JsonRepresentationTests
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
