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
    public static DataFrameRow<X1, X2, X3> 
        Define<X1, X2, X3>(X1 x1, X2 x2, X3 x3, DataFrameSchema schema = null)
            => new DataFrameRow<X1, X2, X3>(x1, x2, x3, schema);

    public static DataFrameRow<X1, X2, X3>
        Define<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x, DataFrameSchema schema = null)
            => new DataFrameRow<X1, X2, X3>(x, schema);
}


/// <summary>
/// Realizes a 3-column row
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
public class DataFrameRow<X1, X2, X3> : DataFrameRow<X1, X2>
{

    public static implicit operator DataFrameRow<X1,X2,X3>((X1 x1, X2 x2, X3 x3) x)
        => new DataFrameRow<X1, X2, X3>(x);

    public DataFrameRow((X1 x1, X2 x2, X3 x3) x, DataFrameSchema Schema = null)
        : base(x.x1, x.x2, Schema)
        => this.x3 = x3;

    public DataFrameRow(X1 x1, X2 x2, X3 x3, DataFrameSchema Schema = null)
        : base(x1, x2, Schema)
        => this.x3 = x3;

    /// <summary>
    /// The value of the third cell in the row
    /// </summary>
    public X3 x3 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1, x2, x3);
}
