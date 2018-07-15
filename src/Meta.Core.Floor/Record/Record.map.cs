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
        /// Projects an evaluation of a value onto a 1-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <returns></returns>
        public static Record<X1> map<X, X1>(X source, Func<X, X1> f1)
           => make(f1(source));

        /// <summary>
        /// Projects 2 evaluations of a uniform value onto a 2-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <returns></returns>
        public static Record<X1, X2> map<X, X1, X2>(X source, Func<X, X1> f1, Func<X, X2> f2)
           => make(f1(source), f2(source));

        /// <summary>
        /// Projects 3 evaluations of a uniform value onto a 3-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <returns></returns>
        public static Record<X1, X2, X3> map<X, X1, X2, X3>(X source, Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3)
           => make(f1(source), f2(source), f3(source));

        /// <summary>
        /// Projects 4 evaluations of a uniform value onto a 4-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> map<X, X1, X2, X3, X4>(X source, Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4)
           => make(f1(source), f2(source), f3(source), f4(source));

        /// <summary>
        /// Projects 5 evaluations of a uniform value onto a 5-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> map<X, X1, X2, X3, X4, X5>(X source, Func<X, X1> f1, Func<X, X2> f2,
            Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5)
                => make(f1(source), f2(source), f3(source), f4(source), f5(source));

        /// <summary>
        /// Projects 6 evaluations of a uniform value onto a 6-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <param name="f6">The function that determines the value of the sixth field</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> map<X, X1, X2, X3, X4, X5, X6>(X source, Func<X, X1> f1, Func<X, X2> f2,
            Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6)
                => make(f1(source), f2(source), f3(source), f4(source), f5(source), f6(source));

        /// <summary>
        /// Projects 7 evaluations of a uniform value onto a 7-record
        /// </summary>
        /// <typeparam name="X">The source value</typeparam>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <typeparam name="X7">The data type of the seventh field</typeparam>
        /// <param name="source">The value to transform</param>
        /// <param name="f1">The function that determines the value of the first field</param>
        /// <param name="f2">The function that determines the value of the second field</param>
        /// <param name="f3">The function that determines the value of the third field</param>
        /// <param name="f4">The function that determines the value of the fourth field</param>
        /// <param name="f5">The function that determines the value of the fifth field</param>
        /// <param name="f6">The function that determines the value of the sixth field</param>
        /// <param name="f7">The function that determines the value of the seventh field</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6, X7> map<X, X1, X2, X3, X4, X5, X6, X7>(X source, Func<X, X1> f1, Func<X, X2> f2, 
            Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6, Func<X, X7> f7)
                => make(f1(source), f2(source), f3(source), f4(source), f5(source), f6(source), f7(source));
    }
}