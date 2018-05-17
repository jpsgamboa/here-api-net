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
        [TestCase("38.7114429,-9.2402852", "{\"Shape\":[\"38.7114429,-9.2402852\",\"38.7114751,-9.2405963\",\"38.7116575,-9.2408967\",\"38.7116683,-9.2409396\"]}")]
        [TestCase("38.7114429,-9.2402852,0", "{\"Shape\":[\"38.7114429,-9.2402852,0\",\"38.7114751,-9.2405963,55.5\",\"38.7116575,-9.2408967,0.7\",\"38.7116683,-9.2409396,0\"]}")]
        public void ConvertShape(string expected, string json)
        {
            var testClassResult = DeserializeJson(json);
            Assert.AreEqual(expected, testClassResult.Shape.Coordinates[0].GetAttributeValue());
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

        public JsonSerializerSettings GetSettingsFor(Dictionary<Type, Func<object, object>> conversions)
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
            public GeoPolyline Shape { get; set; }
        }
    }
}
