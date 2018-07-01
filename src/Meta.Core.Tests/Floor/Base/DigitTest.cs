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
    public class DigitTest
    {
        [UT.TestMethod]
        public void Test01()
        {
            var d1 = Digit.Define(3);
            var wf = from eq in some(Eq.make<Digit>())
                     let result = eq.eq(d1, Digit.Define(3))
                     select result ? "good" : "bad";

            claim.satisfies(wf, result => result == "good");

        }

    }
}