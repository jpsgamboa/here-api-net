using HereAPI.Routing.TypesCommon;
using NUnit.Framework;
using static HereAPI.Routing.TypesCommon.LinkId;

namespace HereAPI.Tests.Routing.TypesCommon
{
    [TestFixture]
    internal class LinkIdTests
    {
        [Test]
        [TestCase(123456, LinkDirection.Any, "*123456")]
        [TestCase(123456, LinkDirection.To, "+123456")]
        [TestCase(123456, LinkDirection.From, "-123456")]
        public void ParameterValueFormat(int id, LinkDirection dir, string expected)
        {
            LinkId l = new LinkId(id, dir);
            Assert.AreEqual(expected, l.GetAttributeValue());
        }
    }
}