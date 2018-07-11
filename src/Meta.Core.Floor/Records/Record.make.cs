//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static metacore;


    /// <summary>
    /// Defines operations on the Record type family
    /// </summary>
    partial class Record
    {
        /// <summary>
        /// Constructs a 1-attribute record from a value
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <param name="x1">The first attribute value</param>
        /// <returns></returns>
        public static Record<X1> make<X1>(X1 x1)
            => new Record<X1>(x1);

        /// <summary>
        /// Constructs a 2-attribute record from an explicit list of values
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <param name="x1">The first attribute value</param>
        /// <param name="x2">The second attibute value</param>
        /// <returns></returns>
        public static Record<X1, X2> make<X1, X2>(X1 x1, X2 x2)
            => new Record<X1, X2>(x1, x2);

        /// <summary>
        /// Constructs a 2-attribute record from a 2-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <param name="schema">The associated schema, if any</param>
        /// <returns></returns>
        public static Record<X1, X2> make<X1, X2>((X1 x1, X2 x2) x)
                => new Record<X1, X2>(x);

        /// <summary>
        /// Constructs a 3-attribute record from an explicit list of values
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <typeparam name="X3">The type of the third attribute</typeparam>
        /// <param name="x1">The first attribute value</param>
        /// <param name="x2">The second attibute value</param>
        /// <param name="x3">The third attribute value</param>
        /// <param name="Schema">The associated schema, if any</param>
        /// <returns></returns>
        public static Record<X1, X2, X3> make<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
                => new Record<X1, X2, X3>(x1, x2, x3);

        /// <summary>
        /// Constructs a 3-record from a 3-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <typeparam name="X3">The type of the third attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3> make<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x)
                => new Record<X1, X2, X3>(x);

        /// <summary>
        /// Constructs a 4-record from a 4 values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <param name="schema">The associated schema, if any</param>
        /// <param name="x1">The first attribute value</param>
        /// <param name="x2">The second attibute value</param>
        /// <param name="x3">The third attribute value</param>
        /// <param name="x4">The fourth attribute value</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> make<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
                => new Record<X1, X2, X3, X4>(x1, x2, x3, x4);

        /// <summary>
        /// Constructs a 4-record from a 4-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <param name="schema">The associated schema, if any</param>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> make<X1, X2, X3, X4>((X1 x1, X2 x2, X3 x3, X4 x4) x)
                => new Record<X1, X2, X3, X4>(x.x1, x.x2, x.x3, x.x4);

        /// <summary>
        /// Constructs a 5-record from 5 values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <param name="x1">The first attribute value</param>
        /// <param name="x2">The second attibute value</param>
        /// <param name="x3">The third attribute value</param>
        /// <param name="x4">The fourth attribute value</param>
        /// <param name="x5">The fifth attribute value</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
                => new Record<X1, X2, X3, X4, X5>(x1, x2, x3, x4, x5);

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
        public static Record<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
                => new Record<X1, X2, X3, X4, X5>(x.x1, x.x2, x.x3, x.x4, x.x5);

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
        public static Record<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>
            ((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
                    => new Record<X1, X2, X3, X4, X5, X6>(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);

        /// <summary>
        /// Constructs a 6-record from 6 values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <param name="x1">The value of the first attribute</param>
        /// <param name="x2">The value of the second attribute</param>
        /// <param name="x3">The value of the third attribute</param>
        /// <param name="x4">The value of the fourth attribute</param>
        /// <param name="x5">The value of the fifth attribute</param>
        /// <param name="x6">The value of the sixth attribute</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>
            (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
                    => new Record<X1, X2, X3, X4, X5, X6>(x1, x2, x3, x4, x5, x6);

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
        public static Record<X1, X2, X3, X4, X5, X6, X7> make<X1, X2, X3, X4, X5, X6, X7>
            ((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) x)
                    => new Record<X1, X2, X3, X4, X5, X6, X7>(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);

        /// <summary>
        /// Constructs a 7-record from 7 values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <typeparam name="X7">The data type of the seventh attribute</typeparam>
        /// <param name="schema">The associated schema</param>
        /// <param name="x1">The value of the first attribute</param>
        /// <param name="x2">The value of the second attribute</param>
        /// <param name="x3">The value of the third attribute</param>
        /// <param name="x4">The value of the fourth attribute</param>
        /// <param name="x5">The value of the fifth attribute</param>
        /// <param name="x6">The value of the sixth attribute</param>
        /// <param name="x7">The value of the seventh attribute</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6, X7> make<X1, X2, X3, X4, X5, X6, X7>
            (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)
                    => new Record<X1, X2, X3, X4, X5, X6, X7>(x1, x2, x3, x4, x5, x6, x7);



    }

}
