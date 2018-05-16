using HereAPI.Routing.Conversions;
using HereAPI.Routing.TypesCommon;
using HereAPI.Routing.TypesEnum;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Structure;
using HereAPI.Shared.TypeObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HereAPI.Tests.Shared.Conversions
{
    [TestFixture]
    class RoutingJsonTypeConversionsTests
    {

        [Test]
        [TestCase("+123456", "{LinkId: \"+123456\"}", "LinkId")]
        [TestCase("-123456", "{LinkId: \"-123456\"}", "LinkId")]
        [TestCase("*123456", "{LinkId: \"*123456\"}", "LinkId")]
        [TestCase("*123456", "{LinkId: \"123456\"}", "LinkId")]
        [TestCase("38.7114429,-9.2402852", "{\"MappedPosition\": {\"Latitude\": 38.7114429, \"Longitude\": -9.2402852}}", "MappedPosition")]
        public void ConvertIAttribute(string expected, string json, string propertyName)
        {
            var testClassResult = DeserializeJson(json);
            Assert.AreEqual(expected, ((IAttribute)GetProperty(testClassResult, propertyName)).GetAttributeValue());
        }

        [Test]
        [TestCase("StopOver", "{WaypointType: \"stopOver\", RoutingType: \"fastest\"}", "WaypointType")]
        [TestCase("Fastest", "{WaypointType: \"stopOver\", RoutingType: \"fastest\"}", "RoutingType")]
        public void ConvertEnumType(string expected, string json, string propertyName)
        {
            var testClassResult = DeserializeJson(json);           
            Assert.AreEqual(expected, ((Enum) GetProperty(testClassResult, propertyName)).ToString());
        }

        [Test]
        public void NotPresentEnumTypeIsNull()
        {
            string json = "{LinkId: \"123456\", RoutingType: \"fastest\"}";
            var testClassResult = DeserializeJson(json);
            Assert.IsNull(testClassResult.WaypointType);
        }
        
        public TestClass DeserializeJson(string json)
        {
            var settings = GetSettingsFor(new RoutingJsonTypeConversions().GetConversions());
            return JsonConvert.DeserializeObject<TestClass>(json, settings);
        }

        public JsonSerializerSettings GetSettingsFor(Dictionary<Type, Func<string, object>> conversions)
        {
            return new JsonSerializerSettings { Converters = new List<JsonConverter> { new JsonTypesConverter(conversions) } };            
        }

        private static object GetProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        internal class TestClass
        {
            public LinkId LinkId { get; set; }
            public WaypointType? WaypointType { get; set; }
            public RoutingType RoutingType { get; set; }
            public GeoCoordinate MappedPosition { get; set; }
        }
    }
}
