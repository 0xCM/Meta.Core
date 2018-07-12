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
    using static operators;

    using static XUnion;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class UnionTest
    {


        static string f1(int i)
            => i.ToString();

        static string f2(decimal j)
            => (j * 2).ToString();

        static string f3(string j)
            => j + j;



        public sealed class SimpleU : XU<SimpleU,int, decimal, string>
        {
            
            

        }


        [UT.TestMethod]
        public void Test01()
        {

            var u = SimpleU.make(3m);
            var result = u.match(f1, f2, f3);

        }

    }


}