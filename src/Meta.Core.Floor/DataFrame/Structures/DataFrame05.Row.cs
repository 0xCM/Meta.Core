// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

using static metacore;



/// <summary>
/// Realizes a five-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
/// <typeparam name="X5">The data type of the fifth column</typeparam>
public class DataFrameRow<X1, X2, X3, X4, X5> : DataFrameRowRoot<DataFrameRow<X1, X2, X3, X4, X5>>
{
    public static implicit operator DataFrameRow<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
         => new DataFrameRow<X1, X2, X3, X4, X5>(x);

    public static implicit operator (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)(DataFrameRow<X1, X2, X3, X4, X5> row)
         => row.AsTuple();

    public DataFrameRow()
        : base(true)
    {

    }

    public DataFrameRow((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x, DataFrameSchema? schema = null)
        : base(false,schema)
    {
        this.x1 = x.x1;
        this.x2 = x.x2;
        this.x3 = x.x3;
        this.x4 = x.x4;
        this.x5 = x.x5;
        this._ItemArray = defer(() => index<object>(x1, x2, x3, x4, x5));
    }

    public DataFrameRow(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, DataFrameSchema? schema = null)
        : base(false, schema)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.x3 = x3;
        this.x4 = x4;
        this.x5 = x5;
        this._ItemArray = defer(() => index<object>(x1, x2, x3, x4, x5));

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

    /// <summary>
    /// The value of the fourth cell in the row
    /// </summary>
    public X4 x4 { get; }

    /// <summary>
    /// The value of the fifth cell in the row
    /// </summary>
    public X5 x5 { get; }

    public override Index<object> ItemArray
        => _ItemArray.Value;

    /// <summary>
    /// Presents the row as a tuple
    /// </summary>
    /// <returns></returns>
    public (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) AsTuple()
        => (x1, x2, x3, x4, x5);


    protected override Lst<ClrType> ColumnTypes
        => types<X1, X2, X3, X4>();
    public override string ToString()
        => AsTuple().Format();

}

