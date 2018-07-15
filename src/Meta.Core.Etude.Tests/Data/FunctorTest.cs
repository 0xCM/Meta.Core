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

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class FunctorTest
    {

        [UT.TestMethod]
        public void Test01A()
        {
            var F = Lst.Functor<int, decimal>();
            var f = func<int, decimal>(x => x * 15.0m);
            var source = Synthetic.Create(150);
            var data = source.Next<int>(500);
            var result = F.fmap(f)(data);
            var expect = map(x => x * 15.0m, data);
            claim.equal(expect, result);
           
        }

        [UT.TestMethod]
        public void Test01B()
        {
            var source = Synthetic.Create(150);
            var data = source.Next<int>(500);
            var result = fmap(x => x * 15.0m, data);
            var expect = Lst.map(x => x * 15.0m, data);
            claim.equal(expect, result);

        }


    }
}
