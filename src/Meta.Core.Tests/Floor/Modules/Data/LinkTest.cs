//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/link")]
    public class LinkTest
    {

        [UT.TestMethod]
        public void Test01()
        {
            var l1 = link(3, "4");
            var l2 = link("5", 6);
            
            var chained = chain(l1, l2);
            var expect = (LinkIdentifier)("3=>4=>5=>6");
            claim.equal(expect, chained.Name);

        }

    }

}