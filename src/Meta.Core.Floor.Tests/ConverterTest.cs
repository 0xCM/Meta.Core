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


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/project")]
    public class ConverterTest
    {
        static string Format(string input)
            => input;

        static string Format(int input)
            => input.ToString();

        static string Format(long input)
            => input.ToString();

        static string Format(decimal input)
            => input.ToString();

        [UT.TestMethod]
        public void Test01()
        {
            var p = conversions<ConverterTest>();
            claim.equal("3", p.Convert<string>(3));
            claim.equal("3", p.Convert<string>(3L));
            claim.equal("3.14", p.Convert<string>(3.14m));

        }

        [UT.TestMethod]
        public void Test05()
        {
            var deferred = defer(seq(1, 2, 3, 4, 5));
            claim.@false(deferred.Evaluated);
            claim.equal(list(1, 2, 3, 4, 5), Lst.make(deferred.Evaluate()));
            claim.@true(deferred.Evaluated);
        }

        [UT.TestMethod]
        public void Test10()
        {
            var composition = Function.compose
                (
                    func((int x) => x * 2m),
                    func((decimal y) => y * 4),
                    func((decimal z) => (long)z + 4L)
                );


            var application = composition.Eval(1);
            claim.equal(12L, application);

        }

    }

}