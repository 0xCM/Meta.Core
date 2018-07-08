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


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("meta/etude/monoids")]
    public class MonoidTests
    {

        [UT.TestMethod]
        public void Test01()
        {

            var mInt = from m in Monoid.make<int>()
                       let combine =  Monoid.combine(seq(1, 2, 3, 4, 5), m)
                       select combine;
            claim.equal(15, mInt);

        }

        [UT.TestMethod]
        public void Test05()
        {
            var mString = from m in Monoid.make<string>()
                          let combine = Monoid.combine(seq("1", "2", "3", "4", "5"),m)
                          select combine;
            claim.equal("12345", mString);

        }

    }

}

