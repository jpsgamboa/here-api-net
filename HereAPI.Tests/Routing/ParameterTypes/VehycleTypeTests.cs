using HereAPI.Routing.RequestAttributeTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HereAPI.Routing.RequestAttributeTypes.VehicleType;

namespace HereAPI.Tests.Routing.ParameterTypes
{
    [TestFixture]
    class VehycleTypeTests
    {

        [Test]
        [TestCase("diesel,5.28", EngineType.Diesel, 5.28f)]
        [TestCase("gasoline,5", EngineType.Gasoline, 5f)]
        public void ParameterValue(string expected, EngineType type, float avgConsump)
        {
            VehicleType vt = new VehicleType(type, avgConsump);
            Assert.AreEqual(expected, vt.GetAttributeValue());
        }
    }
}
