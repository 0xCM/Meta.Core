//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;



    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class FunctionTest
    {

        [UT.TestMethod]
        public void ApplyFunctionN()
        {
            //> f x = x*3
            //> applyN f, 10, 2
            //< 118098
            var f = func((int x) => x * 3);
            var result = Function.applyN(f, 10, 2);
            claim.equal(118098, result);
        }



    }


}