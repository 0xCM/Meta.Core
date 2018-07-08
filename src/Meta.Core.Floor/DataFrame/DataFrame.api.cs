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
    /// constructs a 1-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <returns></returns>
    public static Record<X1> row<X1>(X1 x1)
        => new Record<X1>(x1);

    /// <summary>
    /// Defines a 2-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <returns></returns>
    public static Record<X1, X2> row<X1, X2>(X1 x1, X2 x2)
        => (x1, x2);

    /// <summary>
    /// Consructs a 2-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(params (X1 x1, X2 x2)[] rows)
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2)));

    /// <summary>
    /// Consructs a 2-column data frame from two input sequences
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(Seq<X1> s1, Seq<X2> s2)
        => DataFrame.make(from x in zip(s1, s2) select row(x.x1, x.x2));

    /// <summary>
    /// Consructs a 3-column data frame from a stream of 2-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2> frame<X1, X2>(IEnumerable<(X1 x1, X2 x2)> rows)
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2)));

    /// <summary>
    /// Constructs a 3-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <param name="x3">The value in column 03</param>
    /// <returns></returns>
    public static Record<X1, X2, X3> row<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => (x1, x2, x3);
    
    /// <summary>
    /// Consructs a 3-column data frame from an aray of tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(params (X1 x1, X2 x2, X3 x3)[] rows)
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3)));


    /// <summary>
    /// Consructs a 3-column data frame from a stream of 3-tuples
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="rows">The included rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3> frame<X1, X2, X3>(IEnumerable<(X1 x1, X2 x2, X3 x3)> rows)
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3)));

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
        => DataFrame.make(from x in zip(s1,s2,s3) select row(x.x1, x.x2, x.x3));


    /// <summary>
    /// Constructs a 4-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <param name="x3">The value in column 03</param>
    /// <param name="x4">The value in column 04</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> row<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => (x1, x2, x3, x4);

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4)));

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4)));

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
        => DataFrame.make(from x in zip(s1, s2, s3, s4) select row(x.x1, x.x2, x.x3, x.x4));

    /// <summary>
    /// Constructs a 5-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <param name="x3">The value in column 03</param>
    /// <param name="x4">The value in column 04</param>
    /// <param name="x5">The value in column 05</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> row<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
        => (x1, x2, x3, x4, x5);

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4, x.x5)));

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4, x.x5)));

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
        => DataFrame.make(from x in zip(s1, s2, s3, s4, s5) select row(x.x1, x.x2, x.x3, x.x4, x.x5));

    /// <summary>
    /// Consructs a 5-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <param name="x3">The value in column 03</param>
    /// <param name="x4">The value in column 04</param>
    /// <param name="x5">The value in column 05</param>
    /// <param name="x6">The value in column 05</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> row<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
        => (x1, x2, x3, x4, x5, x6);

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6)));

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
        => DataFrame.make(seq(from x in rows select row(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6)));

}