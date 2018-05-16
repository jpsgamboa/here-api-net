using HereAPI.Shared.TypeObjects;
using NUnit.Framework;
using System;

namespace HereAPI.Tests
{
    [TestFixture]
    class GeoPointTests
    {

        [Test]
        [TestCase(-90.00001, 0.0)]
        [TestCase(90.00001, 0.0)]
        [TestCase(0.0, -180.00001)]
        [TestCase(0.0, 180.00001)]
        public void ValuesOutOfRange(double lat, double lon)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GeoCoordinate gp = new GeoCoordinate(lat, lon);
            });
        }

        [Test]
        [TestCase(-90.0000, 0.0)]
        [TestCase(90.0000, 0.0)]
        [TestCase(0.0, -180.0000)]
        [TestCase(0.0, 180.0000)]
        public void ValuesInRange(double lat, double lon)
        {
            Assert.DoesNotThrow(() =>
            {
                GeoCoordinate gp = new GeoCoordinate(lat, lon);
            });
        }


        [Test]
        [TestCase("38.12345,-8.12345", 38.12345, -8.12345)]
        [TestCase("38.12345,-8.12345,50", 38.12345, -8.12345, 50)]
        public void ParameterValueFormat(string expected, double lat, double lon, double? alt = null)
        {
            GeoCoordinate gp = new GeoCoordinate(lat, lon, alt);
            Assert.AreEqual(expected, gp.GetAttributeValue());
        }


    }
}
