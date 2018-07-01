//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using Modules;

    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class FunctorTest
    {

        [UT.TestMethod]
        public void Test01A()
        {
            var F = O.fmap.list<int, decimal>();
            var f = function<int, decimal>(x => x * 15.0m);
            var source = Synthetic.Create(150);
            var data = source.Next<int>(500).AsList();
            var result = F.fmap(f)(data);
            var expect = List.map(x => x * 15.0m, data);
            claim.equal(expect, result);
           
        }

        [UT.TestMethod]
        public void Test01B()
        {
            var source = Synthetic.Create(150);
            var data = source.Next<int>(500).AsList();
            var result = fmap(x => x * 15.0m, data);
            var expect = List.map(x => x * 15.0m, data);
            claim.equal(expect, result);

        }


    }
}
