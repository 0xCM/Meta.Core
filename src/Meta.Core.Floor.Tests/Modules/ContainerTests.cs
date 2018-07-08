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

    [UT.TestClass]
    public class ContainerTests
    {

        [UT.TestMethod]
        public void Test01()
        {
            var x0 = value(3);
            var y0 = map(x0, x => x * 3);
            claim.equal(value(9), y0);
        }
    }

}
