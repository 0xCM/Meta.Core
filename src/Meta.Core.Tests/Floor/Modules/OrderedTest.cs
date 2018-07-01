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

    [UT.TestClass]
    public class OrderedTest
    {

        [UT.TestMethod]
        public void Test01()
            => claim.@true(ordered<byte>().between(15, 10, 20));

        [UT.TestMethod]
        public void Test05()
            => claim.@true(ordered<sbyte>().between(15, -20, 40));

        [UT.TestMethod]
        public void Test10()
            => claim.@true(ordered<ushort>().between(50, 5, 500));
    }
}