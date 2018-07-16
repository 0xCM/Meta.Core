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

    public static class DataFrameX
    {
        /// <summary>
        /// Constructs a 2-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <returns></returns>
        public static DataFrame<X1> AsDataFrame<X, X1>(this IEnumerable<X> stream, Func<X, X1> f1) 
            => new DataFrame<X1>(seq(from item in stream select record(f1(item))));

        /// <summary>
        /// Constructs a 2-column data frame from a 5-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2> AsDataFrame<X1, X2>(this IEnumerable<(X1 x1, X2 x2)> source)
            => frame(source);

        /// <summary>
        /// Constructs a 2-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <returns></returns>
        public static DataFrame<X1, X2> AsDataFrame<X, X1, X2>(this IEnumerable<X> stream,
            Func<X, X1> f1, Func<X, X2> f2) => frame(stream.Select(item => (f1(item), f2(item))));

        /// <summary>
        /// Constructs a 3-column data frame from a 3-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3> AsDataFrame<X1, X2, X3>(this IEnumerable<(X1 x1, X2 x2, X3 x3)> source)
            => frame(source);

        /// <summary>
        /// Constructs a 3-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <param name="f3">The selector for the third column</param>
        /// <returns></returns>
        public static DataFrame<X1,X2,X3> AsDataFrame<X, X1, X2, X3>(this IEnumerable<X> stream,            
                Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3)
                    => frame(stream.Select(item => (f1(item), f2(item), f3(item))));

        /// <summary>
        /// Constructs a 4-column data frame from a 4-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4> AsDataFrame<X1, X2, X3, X4>(this IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4)> source)
            => frame(source);

        /// <summary>
        /// Constructs a 4-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <param name="f3">The selector for the third column</param>
        /// <param name="f4">The selector for the fourth column</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4> AsDataFrame<X, X1, X2, X3, X4>(this IEnumerable<X> stream,
            Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4)
                => frame(stream.Select(item => (f1(item), f2(item), f3(item), f4(item))));

        /// <summary>
        /// Constructs a 5-column data frame from a 5-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5> AsDataFrame<X1, X2, X3, X4, X5>(this IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5)> source)
            => frame(source);

        /// <summary>
        /// Constructs a 5-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <param name="f3">The selector for the third column</param>
        /// <param name="f4">The selector for the fourth column</param>
        /// <param name="f5">The selector for the fifth column</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5> AsDataFrame<X, X1, X2, X3, X4, X5>(this IEnumerable<X> stream,
            Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5)
                => frame(stream.Select(item => (f1(item), f2(item), f3(item), f4(item), f5(item))));

        /// <summary>
        /// Constructs a 6-column data frame from a 6-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6> AsDataFrame<X1, X2, X3, X4, X5, X6>(this IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)> source)
            => frame(source);

        /// <summary>
        /// Constructs a 6-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <param name="f3">The selector for the third column</param>
        /// <param name="f4">The selector for the fourth column</param>
        /// <param name="f5">The selector for the fifth column</param>
        /// <param name="f6">The selector for the sixth column</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6> AsDataFrame<X, X1, X2, X3, X4, X5, X6>(this IEnumerable<X> stream,
            Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6)
                => frame(stream.Select(item => (f1(item), f2(item), f3(item), f4(item), f5(item), f6(item))));

        /// <summary>
        /// Constructs a 7-column data frame from a stream selection
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <typeparam name="X7">The data type of the seventh column</typeparam>
        /// <param name="stream">The source stream</param>
        /// <param name="f1">The selector for the first column</param>
        /// <param name="f2">The selector for the second column</param>
        /// <param name="f3">The selector for the third column</param>
        /// <param name="f4">The selector for the fourth column</param>
        /// <param name="f5">The selector for the fifth column</param>
        /// <param name="f6">The selector for the sixth column</param>
        /// <param name="f7">The selector for the seventh column</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6, X7> AsDataFrame<X, X1, X2, X3, X4, X5, X6, X7>(this IEnumerable<X> stream,
            Func<X, X1> f1, Func<X, X2> f2, Func<X, X3> f3, Func<X, X4> f4, Func<X, X5> f5, Func<X, X6> f6, Func<X,X7> f7)
                => frame(stream.Select(item => (f1(item), f2(item), f3(item), f4(item), f5(item), f6(item), f7(item))));


        /// <summary>
        /// Constructs a 7-column data frame from a 7-tuple stream
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <typeparam name="X7">The data type of the seventh column</typeparam>
        /// <param name="source">The tuple source</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6, X7> AsDataFrame<X1, X2, X3, X4, X5, X6, X7>(this IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)> source)
            => frame(source);

    }


}