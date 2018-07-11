//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using Modules;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class FunctionTest
    {

        [UT.TestMethod]
        public void TheFunctor()
        {
            var input = list(1, 2, 3, 4, 5);
            var square = func((int x) => x*x);
            var output = square[input];
            var expect = list(1, 4, 9, 16, 25);
            claim.equal(expect, output);            
        }

        [UT.TestMethod]
        public void ThePipe()
        {
            var f = func((int x) => x * 2L);
            var g = func((long x) => x * 2.5m);
            var h = func((decimal x) => show(x));
            var result = 4 > f > g > h;
            var expect = (4 * 2L * 2.5m).ToString();
            claim.equal(expect, result);
        }

    }
}