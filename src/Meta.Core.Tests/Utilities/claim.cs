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

    using static metacore;
    

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    public static class claim
    {
        public static void equal<T>(T expect, T actual)
            => UT.Assert.AreEqual(expect, actual);

        public static void equal<T>(T expect, Option<T> actual)
            => UT.Assert.AreEqual(expect, actual.ValueOrDefault());

        public static void count<T>(int expect, IEnumerable<T> actual)
            => equal(expect, actual.Count());

        public static void sequal<T>(IEnumerable<T> expect, IEnumerable<T> actual)
            => UT.Assert.AreEqual(rolist(expect), rolist(actual));

        public static void @true(bool value)
            => UT.Assert.IsTrue(value);

        public static void @false(bool value)
            => UT.Assert.IsFalse(value);

        /// <summary>
        /// Fail a test, with our without explanation
        /// </summary>
        /// <param name="reason"></param>
        public static void fail(IApplicationMessage reason = null)
            => UT.Assert.Fail(reason?.Format(false));

        /// <summary>
        /// Requires the option to have a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="maybe"></param>
        public static void exists<T>(Option<T> maybe)
            => UT.Assert.IsTrue(maybe.IsSome());

        public static void satisfies<T>(Option<T> maybe, Func<T, bool> predicate)
            => UT.Assert.IsTrue(maybe.Map(t => predicate(t)).ValueOrDefault());
            

    }


}