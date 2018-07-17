//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
       

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    public static class claim
    {
        /// <summary>
        /// Asserts that two values are equal and if so, returns the value
        /// </summary>
        /// <typeparam name="T">The type of value to test</typeparam>
        /// <param name="expect">The expected value</param>
        /// <param name="actual">The computed value</param>
        /// <returns></returns>
        public static T equal<T>(T expect, T actual)
        {
            UT.Assert.AreEqual(expect, actual);
            return actual;
        }

        /// <summary>
        /// Asserts that all supplied values are equal to one another and, if so, returns the values
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="values">The values to test for equality</param>
        public static T[] allEqual<T>(params T[] values)
        {
            for (var i = 0; i < values.Length - 1; i++)
                equal(values[i], values[i + 1]);
            return values;
        }

        public static void allTrue(params bool[] values)
            => UT.Assert.IsTrue(values.All(v => v == true));

        /// <summary>
        /// Asserts that an option has no value
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="o">The option to test</param>
        public static void none<T>(Option<T> o)
            => UT.Assert.IsTrue(o.IsNone());

        /// <summary>
        /// Asserts that a value of a nullable type is null
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="o">The option to test</param>
        public static void none<T>(T? x)
            where T : struct
            => UT.Assert.IsTrue(x == null);

        /// <summary>
        /// Asserts that a direct value is equal to an unwrapped option value
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="expect">The expected value</param>
        /// <param name="actual">The value to test</param>
        public static void equal<T>(T expect, Option<T> actual)
            => UT.Assert.AreEqual(expect, actual.ValueOrDefault());

        /// <summary>
        /// Asserts that a stream yields a specific number of elements
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="expect">The expected count</param>
        /// <param name="actual">The actual count</param>
        public static void count<T>(int expect, IEnumerable<T> actual)
            => equal(expect, actual.Count());

        /// <summary>
        /// Asserts that a boolean value is true
        /// </summary>
        /// <param name="value">The value to test</param>
        public static void @true(bool value)
            => UT.Assert.IsTrue(value);

        /// <summary>
        /// Asserts that a boolean value is false
        /// </summary>
        /// <param name="value">The value to test</param>
        public static void @false(bool value)
            => UT.Assert.IsFalse(value);

        /// <summary>
        /// Fail a test, with our without explanation
        /// </summary>
        /// <param name="reason"></param>
        public static void fail(IAppMessage reason = null)
            => UT.Assert.Fail(reason?.Format(false));

        /// <summary>
        /// Asserts that an option has a value and, if so, returns the value
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="maybe">The value to test</param>
        public static T exists<T>(Option<T> maybe)
        {
            UT.Assert.IsTrue(maybe.IsSome());
            return maybe.ValueOrDefault();
        }

        /// <summary>
        /// Asserts that an option has a value and that the value satisfies a specified predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="maybe">The value to test</param>
        /// <param name="predicate">The predicate to evaluate</param>
        public static void satisfies<T>(Option<T> maybe, Func<T, bool> predicate)
            => UT.Assert.IsTrue(maybe.Map(t => predicate(t)).ValueOrDefault());            
    }

}