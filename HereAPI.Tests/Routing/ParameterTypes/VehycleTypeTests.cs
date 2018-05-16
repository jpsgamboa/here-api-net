using HereAPI.Routing.TypesRequest;
using NUnit.Framework;
using static HereAPI.Routing.TypesRequest.VehicleType;

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
