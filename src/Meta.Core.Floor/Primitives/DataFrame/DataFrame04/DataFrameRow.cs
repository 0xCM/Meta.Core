//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Core;

using static metacore;

public partial class DataFrameRow
{
    public static DataFrameRow<X1, X2, X3, X4> 
        Define<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4, DataFrameSchema Schema = null)
            => new DataFrameRow<X1, X2, X3, X4>(x1, x2, x3, x4, Schema);

    public static DataFrameRow<X1, X2, X3, X4>
        Define<X1, X2, X3, X4>((X1 x1, X2 x2, X3 x3, X4 x4) x, DataFrameSchema Schema = null)
            => new DataFrameRow<X1, X2, X3, X4>(x.x1, x.x2, x.x3, x.x4, Schema);
}

/// <summary>
/// Realizes a four-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
public class DataFrameRow<X1, X2, X3, X4> : DataFrameRow<X1, X2, X3>
{
    public static implicit operator DataFrameRow<X1, X2, X3, X4>((X1 x1, X2 x2, X3 x3, X4 x4) x)
        => new DataFrameRow<X1, X2, X3, X4>(x.x1, x.x2, x.x3, x.x4);

    public DataFrameRow(X1 x1, X2 x2, X3 x3, X4 x4, DataFrameSchema schema = null)
        : base(x1, x2, x3, schema)
    {
        this.x4 = x4;
    }

    /// <summary>
    /// The value of the fourth cell in the row
    /// </summary>
    public X4 x4 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1, x2, x3, x4);
}
