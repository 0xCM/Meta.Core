﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;
    
    using static metacore;
    using static operators;
    using static Union;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("floor/adt")]
    public class AdtTest
    {
        static T times1<T>(T value)
            => mul(value, one<T>());

        static T times2<T>(T value)
            => mul(value, add(one<T>(), one<T>()));

        static T times3<T>(T value)
            => mul(value, addAll(one<T>(), one<T>(), one<T>()));

        public enum Digit
        {
            Zero,
            One,
            Two
        }

        public enum Letter
        {
            A,
            B,
            C
        }


        public enum Symbol
        {
            Plus,
            Minus,
            Times
        }

        static string formatDigit(Digit d)
            => d.ToString();

        static string formatLetter(Letter l)
            => l.ToString();

        static string formatSymbol(Symbol s)
            => s.ToString();

        [UT.TestMethod]
        public void Test01()
        {

            var input = du<Digit, Letter, Symbol>(Symbol.Minus);
            var output = match(input,
                digit => digit.ToString(),
                letter => letter.ToString(),
                symbol => symbol.ToString()
                );

            var expect = du<string, string, string>(x3: "Minus");
            claim.@true(expect == output);


        }


        [UT.TestMethod]
        public void Test05()
        {
            var x = du<int, decimal, byte>(3.0m);
            var xFormat = x.ToString();

            var y = du<int, decimal, byte>(4);
            var yFormat = y.ToString();
            var z = du<int, decimal, byte>((byte)15);


            U<int,decimal,byte> Multiply(U<int, decimal, byte> u)
                => u.Match(times1, times2, times3);

            var x1 = Multiply(du<int, decimal, byte>(3.0m));
            var expect = x1.Revalue(6m);
            claim.@true(x1 == x1.Revalue(6m));
                           
        }

    }

}