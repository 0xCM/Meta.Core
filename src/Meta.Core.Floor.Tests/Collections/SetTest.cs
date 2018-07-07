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