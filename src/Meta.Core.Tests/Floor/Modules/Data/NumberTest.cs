//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Tests
{
    using System;
    using System.Linq;

       
    using static metacore;
    using static etude;


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/math" )]
    public class NumberTest
    {
        
        [UT.TestMethod]
        public void Test01()
        {
            claim.equal(uint16(32), max(uint16(3), uint16(32)));
            claim.equal(uint64(32), max(uint64(3), uint64(32)));
            claim.equal(uint32(32), max(uint32(3), uint32(32)));
            claim.equal(@decimal(32), max(@decimal(3), @decimal(32)));


            claim.equal(uint16(3), min(uint16(3), uint16(32)));
            claim.equal(uint64(3), min(uint64(3), uint64(32)));
            claim.equal(uint32(3), min(uint32(3), uint32(32)));
            claim.equal(@decimal(3), min(@decimal(3), @decimal(32)));

        }

        [UT.TestMethod]
        public void Test05()
            => claim.equal(int16(30), int16(-5) + int16(35));

        [UT.TestMethod]
        public void Test10()
            => claim.equal(int32(30), int32(-5) + int32(35));

        [UT.TestMethod]
        public void Test15()
            => claim.equal(int64(30), int64(-5) + int64(35));

        [UT.TestMethod]
        public void Test20()
            => claim.equal(uint32(30), uint32(15) + uint32(15));

        [UT.TestMethod]
        public void Test30()
        {
            var sum = from x in number(10)
                      from y in number(20L)
                      select y + x;

            claim.equal(30L, sum.Value);
        }

    }

}
