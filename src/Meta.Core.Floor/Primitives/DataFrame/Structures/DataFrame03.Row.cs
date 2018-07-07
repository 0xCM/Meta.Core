// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

/// <summary>
/// Realizes a 3-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
public class DataFrameRow<X1, X2, X3> : DataFrameRowRoot<DataFrameRow<X1, X2, X3>>
{

    public static implicit operator DataFrameRow<X1,X2,X3>((X1 x1, X2 x2, X3 x3) x)
        => new DataFrameRow<X1, X2, X3>(x);

    public DataFrameRow()
        : base(true)
    {

    }
        
    public DataFrameRow((X1 x1, X2 x2, X3 x3) x, DataFrameSchema? Schema = null)
        : base(false, Schema)
    {
        this.x1 = x.x1;
        this.x2 = x.x2;
        this.x3 = x.x3;
        this._ItemArray = defer(() => index<object>(x1, x2, x3));
    }

    public DataFrameRow(X1 x1, X2 x2, X3 x3, DataFrameSchema? Schema = null)
        : base(false, Schema)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.x3 = x3;
        this._ItemArray = defer(() => index<object>(x1, x2, x3));
    }

    Lazy<Index<object>> _ItemArray;

    /// <summary>
    /// The value of the first cell in the row
    /// </summary>
    public X1 x1 { get; }

    /// <summary>
    /// The value of the second cell in the row
    /// </summary>
    public X2 x2 { get; }

    /// <summary>
    /// The value of the third cell in the row
    /// </summary>
    public X3 x3 { get; }


    public override Index<object> ItemArray
        => _ItemArray.Value;

    public (X1 x1, X2 x2, X3 x3) AsTuple()
        => (x1, x2, x3);

    public override string ToString()
        => AsTuple().Format();

    protected override Lst<ClrType> ColumnTypes
        => types<X1, X2, X3>();

}
