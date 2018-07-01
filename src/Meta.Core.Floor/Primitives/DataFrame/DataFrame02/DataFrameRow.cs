//-------------------------------------------------------------------------------------------
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
    public static DataFrameRow<X1, X2> Define<X1, X2>(X1 x1, X2 x2, DataFrameSchema schema = null)
        => new DataFrameRow<X1, X2>(x1, x2, schema);

    public static DataFrameRow<X1, X2>
        Define<X1, X2>((X1 x1, X2 x2) x, DataFrameSchema schema = null)
            => new DataFrameRow<X1, X2>(x, schema);

}


/// <summary>
/// Realizes a two-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
public class DataFrameRow<X1, X2> : DataFrameRow<X1>
{
    public static implicit operator DataFrameRow<X1, X2>((X1 x1, X2 x2) x)
        => new DataFrameRow<X1, X2>(x);

    public DataFrameRow((X1 x1, X2 x2) x, DataFrameSchema Schema = null)
        : base(x.x1)
        => this.x2 = x.x2;

    public DataFrameRow(X1 x1, X2 x2, DataFrameSchema Schema = null)
        : base(x1, Schema)
        => this.x2 = x2;

    /// <summary>
    /// The value of the second cell in the row
    /// </summary>
    public X2 x2 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1, x2);

}
