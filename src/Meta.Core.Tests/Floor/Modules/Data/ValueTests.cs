//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules.Test
{
    using System;
    using System.Linq;

    //using static corefunc;
    using static operators;
    using static List;

    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("api/value")]
    public class ValueApiTest
    {
        [UT.TestMethod]
        public void ValueTupleTest01()
        {
            var output = from x in value(3, 4)
                         from y in value(4, 5)
                         select add(x, y);
                                               

            claim.equal((7, 9), ~output);
            claim.equal(value(7, 9), output);

        }

        [UT.TestMethod]
        public void ValueTupleTest02()
        {
            var output = from x in value(3, 4)
                         from y in value(4, 5)
                         select add(add(x, y));

            claim.equal(16, ~output);            

        }

        [UT.TestMethod]
        public void ValueTupleTest03()
        {
            var output = from x in value(3, 4m)
                         from y in value(4, 5m)
                         select add(add(x, y));

            claim.equal(16, ~output);

        }

        [UT.TestMethod]
        public void ValueTupleTest04()
        {
            var output = from x in value(3, "4")
                         from y in value(4, "5")
                         select (x.x1 + y.x1, x.x2 + y.x2);

            claim.equal(value(7,"45"), output);

        }


        [UT.TestMethod]
        public void SumTest01()
        {
            var summation = from s1 in sum(10)
                            from s2 in sum(20)
                            select combine(seq(s1, s2));
            claim.equal(sum(30), summation);
        }

    }

}