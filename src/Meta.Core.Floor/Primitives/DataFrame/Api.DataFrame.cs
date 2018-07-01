//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Defines a 1-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <returns></returns>
    public static DataFrameRow<X1> row<X1>(X1 x1)
        => new DataFrameRow<X1>(x1);

    /// <summary>
    /// Defines a 2-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2> row<X1, X2>(X1 x1, X2 x2)
        => (x1, x2);

    /// <summary>
    /// Defines a 3-column data frame row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <param name="x3">The value in column 03</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3> row<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => (x1, x2, x3);

    /// <summary>
    /// Defines a 4-column data frame row
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
    public static DataFrameRow<X1, X2, X3, X4> row<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => (x1, x2, x3, x4);

    /// <summary>
    /// Defines a 5-column data frame row
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
    public static DataFrameRow<X1, X2, X3, X4, X5> row<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
        => (x1, x2, x3, x4, x5);

    /// <summary>
    /// Defines a 5-column data frame row
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
    public static DataFrameRow<X1, X2, X3, X4, X5, X6> row<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
        => (x1, x2, x3, x4, x5, x6);

    public static DataFrame<X1, X2, X3, X4, X5, X6> frame<X1, X2, X3, X4, X5, X6>(params (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)[] rows)
        => DataFrame.Define(Seq.make(from x in rows select row(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6)));


}