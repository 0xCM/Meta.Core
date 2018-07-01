//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Tests
{
    using System;
    using System.Linq;

    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class ConversionTests
    {

        static int ParseInt(string input)
            => int.Parse(input);

        [UT.TestMethod]
        public void Test01()
        {

            var f = converter<int>(require(method<ConversionTests>(nameof(ParseInt))));
            var input = list("15", "25", "30");
            var output = map(x => f(x), input);
            var expect = list(15, 25, 30);
            claim.equal(expect, output);                    
        }

        //[UT.TestMethod]
        //public void Test05()
        //{
        //    var convert = converter<int>(require(method<ConversionTests>(nameof(ParseInt))));
        //    var seed = 50;
        //    var count = 5000;
        //    var synth = Synthetic.Create(seed);
        //    var input = !map(format,synth.Next<int>(count));
        //    var output = map(x => convert(x), input);
        //    var expect = map(ParseInt, input);
        //    claim.equal(expect, output);
            
            
            
        //}
    }

}
