//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class BoundedTests
    {

        [UT.TestMethod]
        public void Test01()
        {

            var b1 = Bounded.make<int>();
            claim.satisfies(b1, b => b.minval == Int32.MinValue && b.maxval == Int32.MaxValue);
        }

        [UT.TestMethod]
        public void Test02()
        {
            var either = from e1 in new Either<int, decimal>(3.0m)
                         from e2 in new Either<int, decimal>(6.0m)
                         select e1 + e2;

            claim.equal(9.0m, either.Right);
        }


    }
}
