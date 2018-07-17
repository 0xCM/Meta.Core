//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class SumTest
    {
        
        [UT.TestMethod]
        public void SumText()
        {
            var expect = "123456789";
            var sum = claim.equal(Sum(expect), Sum("123") + Sum("456") + Sum("789"));
            claim.equal(expect, sum.unwrap());
        }

        [UT.TestMethod]
        public void SumDigits()
        {
            var expect = Digits.Parse("123456789").Require();
            var part1 = digits(1, 2, 3);
            var part2 = digits(4, 5, 6);
            var part3 = digits(7, 8, 9);
            var sum1 = part1 + part2 + part3;
            var sum2 = Sum(part1) + Sum(part2) + Sum(part3);
            claim.equal(sum1, sum2.unwrap());

            //var sum = claim.equal(Sum(expect), Sum(digits(1,2,3)) + Sum(digits(4,5,6)) + Sum(digits(7,8,9)));
            //claim.equal(expect, sum.unwrap());
        }

    }

}
