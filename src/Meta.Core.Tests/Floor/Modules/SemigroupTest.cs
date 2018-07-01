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
    using static operators;
       

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class SemigroupTest
    {


        [UT.TestMethod]
        public void Test01()
        {
            var semigroup = Semigroup.make<int>().Require();
            var values = seq(0, 1, 2, 3, 4, 5);

            var sumA = Seq.combine(semigroup.combine, values);
            var sumB = add(add(add(add(1, 2), 3), 4), 5);
            claim.equal(sumB, sumA);           
            
        }

    }


}