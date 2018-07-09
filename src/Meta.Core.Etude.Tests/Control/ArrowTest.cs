//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;



    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/control")]
    public class ArrowTest
    {
        [UT.TestMethod]
        public void Test01()
        {
            var a1 = Arrow.make((int x) => 2 * x);
            var a2 = Arrow.make((int x) => 3.0m * x);
            var a3 = a1.compose(a2);
            var f = a3.first<Date>();
            var input = (4, Date.Today);
            var output = f.Apply(input);
            claim.equal(4 * 2 * 3.0m, output.Item1);
            claim.equal(output.Item2, input.Today);
           
        }

    }
}