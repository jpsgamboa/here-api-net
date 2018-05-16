using HereAPI.Routing.RequestAttributeTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HereAPI.Routing.RequestAttributeTypes.LinkId;

namespace HereAPI.Tests.Routing.ParameterTypes
{
    [TestFixture]
    class LinkIdTests
    {

        [Test]
        [TestCase(123456, LinkDirection.Any, "*123456")]
        [TestCase(123456, LinkDirection.To, "+123456")]
        [TestCase(123456, LinkDirection.From, "-123456")]
        public void ParameterValueFormat(int id, LinkDirection dir, string expected)
        {
            LinkId l = new LinkId(id, dir);
            Assert.AreEqual(expected, l.GetParameterValue());
        }


    }
}
