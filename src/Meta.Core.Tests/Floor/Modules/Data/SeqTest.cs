//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules.Tests
{
    using System;
    using System.Linq;

    using static metacore;
    

    using static Seq;


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class SeqTest
    {


        [UT.TestMethod]
        public void Test01()
        {

            claim.equal(range(10, 15), from n in range(3, 15) where n >= 10 select n);


        }

        [UT.TestMethod]
        public void Test02()
        {
            var s = seq(seq(1, 3, 5), seq(6, 9));
            claim.equal(seq(1, 3, 5) + seq(6, 9), Seq.flatten(s));

        }

    }


}