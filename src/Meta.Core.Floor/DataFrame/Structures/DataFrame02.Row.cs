//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

/// <summary>
/// Realizes a two-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
public class DataFrameRow<X1, X2> : DataFrameRowRoot<DataFrameRow<X1, X2>>
{
    public static implicit operator DataFrameRow<X1, X2>((X1 x1, X2 x2) x)
        => new DataFrameRow<X1, X2>(x);

    public static implicit operator (X1 x1, X2 x2)(DataFrameRow<X1, X2> row)
        => row.AsTuple();

    public DataFrameRow()
        : base(true)
    {

    }

    public DataFrameRow((X1 x1, X2 x2) x, DataFrameSchema? Schema = null)
        : base(false, Schema)

    {
        this.x1 = x.x1;
        this.x2 = x.x2;
        this._ItemArray = defer(() => index<object>(x1, x2));
    }
    public DataFrameRow(X1 x1, X2 x2, DataFrameSchema? Schema = null)
        : base(false, Schema)
    {
        this.x1 = x1;
        this.x2 = x2;
        this._ItemArray = defer(() => index<object>(x1, x2));
    }


    /// <summary>
    /// The value of the first cell in the row
    /// </summary>
    public X1 x1 { get; }

    /// <summary>
    /// The value of the second cell in the row
    /// </summary>
    public X2 x2 { get; }

    Lazy<Index<object>> _ItemArray;

    public override Index<object> ItemArray
        => _ItemArray.Value;

    public (X1 x1, X2 x2) AsTuple()
        => (x1, x2);

    protected override Lst<ClrType> ColumnTypes
        => types<X1,X2>();

    public override string ToString()
        => AsTuple().Format();

}
