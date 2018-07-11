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
    /// Constructs a record with 1 field
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <returns></returns>
    public static Record<X1> record<X1>(X1 x1)
        => new Record<X1>(x1);

    /// <summary>
    /// Constructs a record with 2 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <returns></returns>
    public static Record<X1, X2> record<X1, X2>(X1 x1, X2 x2)
        => Record.make(x1, x2);

    /// <summary>
    /// Constructs a record with 3 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third attribute</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <returns></returns>
    public static Record<X1, X2, X3> record<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => Record.make(x1, x2, x3);

    /// <summary>
    /// Constructs a record with 4 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> record<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => Record.make(x1, x2, x3, x4);

    /// <summary>
    /// Constructs a record with 5 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> record<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
        => Record.make(x1, x2, x3, x4, x5);

    /// <summary>
    /// Constructs a record with 6 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <typeparam name="X6">The data type of the sixth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <param name="x6">The value of field 6</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> record<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
        => Record.make(x1, x2, x3, x4, x5, x6);

    /// <summary>
    /// Consructs record with 7 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <typeparam name="X6">The data type of the sixth field</typeparam>
    /// <typeparam name="X7">The data type of the sixth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <param name="x6">The value of field 6</param>
    /// <param name="x7">The value of field 7</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> record<X1, X2, X3, X4, X5, X6, X7>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)
        => Record.make(x1, x2, x3, x4, x5, x6, x7);

}