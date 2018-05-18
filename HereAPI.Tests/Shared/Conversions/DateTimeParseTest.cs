using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace HereAPI.Tests.Shared.Conversions
{
    [TestFixture]
    internal class DateTimeParseTest
    {
        private class TestC
        {
            public DateTime Time { get; set; }
        }

        [Test]
        [TestCase("2018-05-15T19:00:00", "{\"Time\":\"2018-05-15T19:00:00+01:00\"}")]
        public void ParseDateTimeFormat(string expected, string json)
        {
            var tc = JsonConvert.DeserializeObject<TestC>(json);
            Assert.AreEqual(expected, tc.Time.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
    }
}