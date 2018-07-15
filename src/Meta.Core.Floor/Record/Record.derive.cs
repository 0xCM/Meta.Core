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

    partial class Record
    {
        /// <summary>
        /// Constructs a 1-record derivation
        /// </summary>
        /// <typeparam name="X">Tye input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1> derive<X, X1>(X zero,
           Func<X, X1> f1)
               => src => make(f1(src));


        /// <summary>
        /// Constructs a 2-record derivation
        /// </summary>
        /// <typeparam name="X">Tye input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2> derive<X, X1, X2>(X zero,
           Func<X, X1> f1, Func<X, X2> f2)
               => src => make(f1(src), f2(src));

        /// <summary>
        /// Constructs a 3-record derivation
        /// </summary>
        /// <typeparam name="X">Tye input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2, X3> derive<X, X1, X2, X3>(X zero,
           Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3)
               => src => make(f1(src), f2(src), f3(src));

        /// <summary>
        /// Constructs a 4-record derivation
        /// </summary>
        /// <typeparam name="X">Tye input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2, X3, X4> derive<X, X1, X2, X3, X4>(X zero,
           Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4)
               => src => make(f1(src), f2(src), f3(src), f4(src));

        /// <summary>
        /// Constructs a 5-record derivation
        /// </summary>
        /// <typeparam name="X">Tye input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2, X3, X4, X5> derive<X, X1, X2, X3, X4, X5>(X zero,
           Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5)
               => src => make(f1(src), f2(src), f3(src), f4(src), f5(src));

        /// <summary>
        /// Constructs a 6-record derivation
        /// </summary>
        /// <typeparam name="X">The input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <param name="f6">The function that determines the value of the sixth field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2, X3, X4, X5, X6> derive<X, X1, X2, X3, X4, X5, X6>(X zero,
           Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6)
               => src => make(f1(src), f2(src), f3(src), f4(src), f5(src), f6(src));

        /// <summary>
        /// Constructs a 7-record derivation
        /// </summary>
        /// <typeparam name="X">The input value type</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <typeparam name="X7">The data type of the seventh field</typeparam>
        /// <param name="zero">A marker value so intellisense will work; oterwise ignored</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <param name="f6">The function that determines the value of the sixth field</param>
        /// <param name="f7">The function that determines the value of the seventh field</param>
        /// <returns></returns>
        public static RecordDerivation<X, X1, X2, X3, X4, X5, X6, X7> derive<X, X1, X2, X3, X4, X5, X6, X7>(X zero,
           Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6, Func<X, X7> f7)
               => src => make(f1(src), f2(src), f3(src), f4(src), f5(src), f6(src), f7(src));


    }
}