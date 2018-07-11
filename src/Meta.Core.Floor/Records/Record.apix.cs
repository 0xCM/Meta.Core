//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    public static class RecordX
    {

        internal static bool RecordEquals<R>(this R r1, R r2)
            where R : IRecord<R>, new()
            => r1.Equals(r2);

        internal static bool RecordEquals<R>(this R r1, object r2)
            where R : IRecord<R>, new()
            => (r2 is R rr2)
                ? RecordEquals(r1, rr2) : false;

        /// <summary>
        /// Retrieves the fields defined by the record
        /// </summary>
        /// <typeparam name="R">The record type</typeparam>
        /// <param name="r">The record value</param>
        /// <returns></returns>
        public static Lst<RecordField> Fields<R>(this R r)
            where R : IRecord<R>, new()
                => Record.fields<R>();



        public static Record<X1, X2> AsRecord<X1, X2>(this (X1 x1, X2 x2) x)
                => Record.make(x);

        public static Record<X1, X2, X3> AsRecord<X1, X2, X3>(this (X1 x1, X2 x2, X3 x3) x)
                => Record.make(x);

        /// <summary>
        /// Constructs a 3-record from a 3-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <typeparam name="X3">The type of the third attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> AsRecord<X1, X2, X3, X4>(this (X1 x1, X2 x2, X3 x3, X4 x4) x)
                => Record.make(x);

        /// <summary>
        /// Constructs a 5-record from a 5-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> AsRecord<X1, X2, X3, X4, X5>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
                => Record.make(x);

        /// <summary>
        /// Constructs a 6-record from a 6-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> AsRecord<X1, X2, X3, X4, X5, X6>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
                => Record.make(x);

        /// <summary>
        /// Constructs a 7-record from a 7-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <typeparam name="X7">The data type of the seventh attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6, X7> AsRecord<X1, X2, X3, X4, X5, X6, X7>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) x)
                => Record.make(x);

    }

}