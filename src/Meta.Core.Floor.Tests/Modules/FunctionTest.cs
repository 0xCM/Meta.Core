//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules.Tests
{
    using System;
    using System.Linq;

    //using static corefunc;
    using static operators;
    using static Lst;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class FunctionTest
    {

        [UT.TestMethod]
        public void Test01()
        {
            var input = fuse(1, 2, 3, 4, 5);
            var square = Function.make((int x) => x*x);
            var output = square * input;
            var expect = fuse(1, 4, 9, 16, 25);
            claim.equal(expect, output);
            


        }

    }
}