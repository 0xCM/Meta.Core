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

    [UT.TestClass, UT.TestCategory("meta/floor/frame")]
    public class DataFrameTest
    {

        [UT.TestMethod]
        public void Test01()
        {

            //Create frame using dynamic api
            var frame1 = DataFrame.make(list(typeof(int), typeof(string), typeof(Date)),
                list(array<object>(1, "One", date("2015-01-01")),
                    array<object>(2, "Two", date("2015-02-02")),
                    array<object>(3, "Three", date("2015-03-03")))).Require();

            //Create frame using typed api
            var frame2 = frame(
                (1, "One", date("2015-01-01")),
                (2, "Two", date("2015-02-02")),
                (3, "Three", date("2015-03-03"))
                );

            //Verify equality
            claim.equal(frame2, frame1);                      

        }

        [UT.TestMethod]
        public void Test02()
        {
            var rowcount = 500;
            var s0 = nameof(Test02).GetHashCode();
            var src1 = Synthetics.source<int>(s0 + 1).Values(rowcount);
            var src2 = Synthetics.source<decimal>(s0 + 2).Values(rowcount);
            var src3 = Synthetics.source<byte>(s0 + 3).Values(rowcount);
            var frame1 = frame(src1.AsSeq(), src2.AsSeq(), src3.AsSeq());

            var src1Total = sum(frame1.Col01);
            var src1TotalExpect = sum(src1);
            claim.equal(src1Total, src1TotalExpect);

            var src2Total = sum(frame1.Col02);
            var src2TotalExpect = sum(src2);
            claim.equal(src2Total, src2TotalExpect);

            var src3Total = sum(frame1.Col03);
            var src3TotalExpect = sum(src3);
            claim.equal(src3Total, src3TotalExpect);

                      
        }

        [UT.TestMethod]
        public void Test10()
        {
            var frame = assembly().Types.ToDataFrame(x => x.ContainsGenericParameters, x => x.BaseType, x => x.AccessLevel);
            var accessA = seqi(frame.Col03);
            var accessB = seqi(assembly().Types.Select(a => a.AccessLevel));
            claim.equal(accessA, accessB);
        }
    }

}
