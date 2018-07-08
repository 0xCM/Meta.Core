//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using static express;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/linqx")]
    public class ExpressionTest
    {

        static int Func0()
            => 32;

        static string Func1(int x1)
            => x1.ToString();

        [UT.TestMethod]
        public void Test03()
        {
            var func0 = ClrType.Get(GetType()).DeclaredMethods.Single(m => m.Name == nameof(Func0));
            var f = func<int>(func0);
            claim.satisfies(f, g => g() == 32);

        }

        [UT.TestMethod]
        public void Test04()
        {
            var func = ClrType.Get(GetType()).DeclaredMethods.Single(m => m.Name == nameof(Func1));
            var call = func<int, string>(func).Require();
            claim.equal("32", call(32));
        }


        class ConversionOperatorImplementor
        {
            public static implicit operator ConversionOperatorImplementor(int X)
                => new ConversionOperatorImplementor();

            public static implicit operator int(ConversionOperatorImplementor X)
                => new ConversionOperatorImplementor();

            public static explicit operator ConversionOperatorImplementor(string X)
                => new ConversionOperatorImplementor();

        }


        static void IAmAGenericMethod<X, Y>()
        {

        }


        [UT.TestMethod]
        public void Test05()
        {
            var typeParams = ClrType.Get(GetType()).DeclaredMethods.Single(m => m.Name.StartsWith("IAmA")).TypeParameters.ToList();
            claim.count(2, typeParams);
        }

        [UT.TestMethod]
        public void Test06()
        {
            var converters = ClrType.Get<ConversionOperatorImplementor>().DeclaredConversionOperators.ToList();
            claim.equal(converters.Count, 3);
            var targets = converters.Targets<ConversionOperatorImplementor>().ToList();
            claim.equal(targets.Count, 2);
        }

        [UT.TestMethod]
        public void Test10()
        {
            var construction = from c in factory<List<int>>()
                          let L = c()
                          let tail = list(5,6,7)
                          let x = stream(L, stream(5,6,7))
                          select x.ToReadOnlyList();
            claim.satisfies(construction, value => value.Count == 3);   
            
        }

        [UT.TestMethod]
        public void Test15()
        {
            var construction = from c in factory<IEnumerable<int>, List<int>>()
                               select c(stream(5, 6, 7));
                               
            claim.satisfies(construction, value => value.Count == 3);

        }

        [UT.TestMethod]
        public void Test16()
        {
            var construction = from c in factory(typeof(List<int>), typeof(IEnumerable<int>))
                               let weak = c(stream(5, 6, 7))
                               from strong in tryCast<List<int>>(weak)
                               select strong;

            claim.satisfies(construction, value => value.Count == 3);

        }


        [UT.TestMethod]
        public void Test20()
        {
            var construction = from c in factory(typeof(DateTime), typeof(long), typeof(DateTimeKind))
                                let weak = c(25000L, DateTimeKind.Local)
                                from strong in tryCast<DateTime>(weak)
                                select strong;
            claim.satisfies(construction, value => value == new DateTime(25000, DateTimeKind.Local));                       
        }


        [UT.TestMethod]
        public void Test25()
        {
            bool divisibleBy5(int n)
               => n % 5 == 0;

           bool divisibleBy3(int n)
              => n % 3 == 0;

            var case1 = from p in linqx.and<int, int>(divisibleBy5, divisibleBy3)
                               let eval1 = p(15, 15)
                               let eval2 = p(20, 11)
                               let eval3 = p(22, 22)
                               select (eval1, eval2, eval3);
            claim.satisfies(case1, c => c.eval1 && not(c.eval2) && not(c.eval3));


        }

        public void Test30()
        {
            var invoke = invocation<int, decimal>(x => x * 2.0m, "x");
        }

        public void Test35()
        {
            
        }
    }
}