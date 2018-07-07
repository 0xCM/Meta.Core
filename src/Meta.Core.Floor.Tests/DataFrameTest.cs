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

    [UT.TestClass, UT.TestCategory("etude/monoids")]
    public class DataFrameTest
    {

        [UT.TestMethod]
        public void Test01()
        {

            var frame = DataFrame.make(list(typeof(int), typeof(string), typeof(Date)),
                seq(array<object>(1, "One", date("2015-01-01")),
                    array<object>(2, "Two", date("2015-02-02")),
                    array<object>(3, "Three", date("2015-03-03"))));

            claim.exists(frame);
            var rows = frame.MapRequired(f => f.ItemArrays.AsList());
            



        }

    }

}
