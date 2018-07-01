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
    /// Constructs a six-column row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="schema">The associated schema</param>
    /// <param name="x1">The value in cell 01</param>
    /// <param name="x2">The value in cell 02</param>
    /// <param name="x3">The value in cell 03</param>
    /// <param name="x4">The value in cell 04</param>
    /// <param name="x5">The value in cell 05</param>
    /// <param name="x6">The value in cell 06</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5, X6>
        Define<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2,X3 x3, X4 x4, X5 x5, X6 x6, DataFrameSchema schema = null)
                => new DataFrameRow<X1, X2, X3, X4, X5, X6>(x1, x2,
                        x3, x4, x5, x6, schema);
}


/// <summary>
/// Realizes a six-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
/// <typeparam name="X5">The data type of the fifth column</typeparam>
/// <typeparam name="X6">The data type of the sixth column</typeparam>
public class DataFrameRow<X1, X2, X3, X4, X5, X6> : DataFrameRow<X1, X2, X3, X4, X5>
{
    public static implicit operator DataFrameRow<X1, X2, X3, X4, X5, X6>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
        => new DataFrameRow<X1, X2, X3, X4, X5, X6>(x);

    public DataFrameRow((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x, DataFrameSchema Schema = null)
        : base(x.x1, x.x2, x.x3, x.x4, x.x5, Schema)
            => this.x6 = x6;

    public DataFrameRow(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, DataFrameSchema Schema = null)
        : base(x1, x2, x3, x4, x5, Schema)
            => this.x6 = x6;

    /// <summary>
    /// The value of the sixth cell in the row
    /// </summary>
    public X6 x6 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1, x2, x3, x4, x5, x6);
}

