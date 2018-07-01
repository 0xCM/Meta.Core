// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

using static metacore;

public partial class DataFrameRow
{

    /// <summary>
    /// Constructs a 5-column row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x1">The value in cell 01</param>
    /// <param name="x2">The value in cell 02</param>
    /// <param name="x3">The value in cell 03</param>
    /// <param name="x4">The value in cell 04</param>
    /// <param name="x5">The value in cell 05</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5>
        Define<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, DataFrameSchema Schema = null)
            => new DataFrameRow<X1, X2, X3, X4, X5>(x1, x2, x3, x4, x5, Schema);

    /// <summary>
    /// Constructs a 5-column row from a tuple
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x">The tuple value</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5>
        Define<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x, DataFrameSchema Schema = null)
            => new DataFrameRow<X1, X2, X3, X4, X5>(x.x1, x.x2, x.x3, x.x4, x.x5, Schema);
}


/// <summary>
/// Realizes a five-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
/// <typeparam name="X5">The data type of the fifth column</typeparam>
public class DataFrameRow<X1, X2, X3, X4, X5> : DataFrameRow<X1, X2, X3, X4>
{

    public static implicit operator DataFrameRow<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
         => new DataFrameRow<X1, X2, X3, X4, X5>(x);

    public DataFrameRow((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x, DataFrameSchema schema = null)
        : base(x.x1, x.x2, x.x3, x.x4, schema)
            => this.x5 = x5;

    public DataFrameRow(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, DataFrameSchema Schema = null)
        : base(x1, x2, x3, x4, Schema)
        => this.x5 = x5;

    /// <summary>
    /// The value of the fifth cell in the row
    /// </summary>
    public X5 x5 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1, x2, x3, x4, x5);
}

