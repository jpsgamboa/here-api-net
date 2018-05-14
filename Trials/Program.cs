using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trials
{
    class Program
    {

        class TestClass
        {
            public string A { get; set; }
            public string B { get; set; }

            public TestClass()
            {
                testParams();
            }


            public void testParams()
            {
                if (A == null) Console.WriteLine("A is null");
                if (B == null) Console.WriteLine("B is null");
            }
        }

        static void Main(string[] args)
        {

            var tc = new TestClass()
            {
                B = "Meow"
            };

            tc.testParams();

            Console.ReadKey();
        }
    }
}
