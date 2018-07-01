//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class SemigroupoidTests
    {
    

        

        [UT.TestMethod]
        public void Test01()
        {
            var subject = Semigroupoid.make<string>();

            var f = function<string, string, string>((x, y) => (x + y).ToUpper());
            var g = function<string, string, string>((x, y) => (x + y).ToLower());
            var h = subject.compose(f.F, g.F);            
            var output = h("one", "two");
            claim.equal("ONEONETWO", output);

        }

    }


}
