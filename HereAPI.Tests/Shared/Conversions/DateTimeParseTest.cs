using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HereAPI.Tests.Shared.Conversions
{
    [TestFixture]
    class DateTimeParseTest
    {

        class TestC
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
