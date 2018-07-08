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
    public class SetTest
    {


        [UT.TestMethod]
        public void Test01()
        {
            claim.equal(set(1, 2, 3, 4, 5, 5), set(1, 2, 3, 4, 5));
            


        }
    }

}