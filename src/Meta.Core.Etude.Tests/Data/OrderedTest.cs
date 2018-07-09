//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class OrderedTest
    {

        [UT.TestMethod]
        public void Test01()
            => claim.satisfies(order<byte>(), o => o.compare(10, 20) == Ordering.LT);

        [UT.TestMethod]
        public void Test05()
            => claim.satisfies(order<sbyte>(), o => o.compare(-5, 20) == Ordering.LT);

        [UT.TestMethod]
        public void Test10()
            => claim.satisfies(order<ushort>(), o => o.compare(35, 15) == Ordering.GT);

        [UT.TestMethod]
        public void Test15()
            => claim.satisfies(order<int>(), o => o.compare(35, 35) == Ordering.EQ);

    }
}