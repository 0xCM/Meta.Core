//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Constructs a frame with dynamic typing
    /// </summary>
    /// <param name="coltypes"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Option<IDataFrame> frame(Lst<Type> coltypes, Lst<object[]> data)
        => DataFrame.make(coltypes, data);

    /// <summary>
    /// Consructs a 2-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(params (X1 x1, X2 x2)[] rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2)));

    /// <summary>
    /// Consructs a 2-column data frame from two input sequences
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(Seq<X1> s1, Seq<X2> s2)
        => DataFrame.make(from x in zip(s1, s2) select record(x.x1, x.x2));    

    /// <summary>
    /// Consructs a 3-column data frame from a stream of 2-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(IEnumerable<(X1 x1, X2 x2)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2)));
    
    /// <summary>
    /// Consructs a 3-column data frame from an aray of tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(params (X1 x1, X2 x2, X3 x3)[] rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3)));

    /// <summary>
    /// Consructs a 3-column data frame from a stream of 3-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(IEnumerable<(X1 x1, X2 x2, X3 x3)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3)));

    /// <summary>
    /// Consructs a 3-column data frame from three input sequences
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3)
        => DataFrame.make(from x in zip(s1,s2,s3) select record(x.x1, x.x2, x.x3));

    /// <summary>
    /// Constructs a 3-column frame from a container of 3-records
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="rows">The data source</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(IContainer<Record<X1, X2, X3>> rows)
        => new DataFrame<X1, X2, X3>(rows);


    /// <summary>
    /// Consructs a 4-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4> frame<X1, X2, X3, X4>(params (X1 x1, X2 x2, X3 x3, X4 x4)[] rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4)));

    /// <summary>
    /// Consructs a 4-column data frame from a stream of 4-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4> frame<X1, X2, X3, X4>(IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4)));

    /// <summary>
    /// Consructs a 4-column data frame from four input sequences
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <param name="s4">The fourth input sequence</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4> frame<X1, X2, X3, X4>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4)
        => DataFrame.make(from x in zip(s1, s2, s3, s4) select record(x.x1, x.x2, x.x3, x.x4));


    /// <summary>
    /// Consructs a 5-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5> frame<X1, X2, X3, X4, X5>(params (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)[] rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4, x.x5)));

    /// <summary>
    /// Consructs a 5-column data frame from a stream of 5-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fourth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5> frame<X1, X2, X3, X4, X5>(IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4, x.x5)));

    /// <summary>
    /// Consructs a 5-column data frame from five input sequences
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <param name="s4">The fourth input sequence</param>
    /// <param name="s5">The fifth input sequence</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5> frame<X1, X2, X3, X4, X5>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4, Seq<X5> s5)
        => DataFrame.make(from x in zip(s1, s2, s3, s4, s5) select record(x.x1, x.x2, x.x3, x.x4, x.x5));

    /// <summary>
    /// Consructs a 6-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5, X6> frame<X1, X2, X3, X4, X5, X6>(params (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)[] rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6)));

    /// <summary>
    /// Consructs a 6-column data frame from a stream of 6-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fourth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5, X6> frame<X1, X2, X3, X4, X5, X6>(IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6)));

    /// <summary>
    /// Consructs a 6-column data frame from a stream of 6-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fourth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5, X6, X7> frame<X1, X2, X3, X4, X5, X6, X7>(IEnumerable<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)> rows)
        => DataFrame.make(seq(from x in rows select record(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7)));
}