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
    

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/collections")]

    public class SeqTest
    {


        [UT.TestMethod]
        public void Test01()
        {

            claim.equal(range(10, 15), from n in range(3, 15) where n >= 10 select n);


        }

        [UT.TestMethod]
        public void Test02()
        {
            var s = seq(seq(1, 3, 5), seq(6, 9));
            claim.equal(seq(1, 3, 5) + seq(6, 9), flatten(s));

        }

    }


}