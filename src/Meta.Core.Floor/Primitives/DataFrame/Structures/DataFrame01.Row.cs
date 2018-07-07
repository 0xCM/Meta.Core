//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

public class DataFrameRow<X1> : DataFrameRowRoot<DataFrameRow<X1>>
{ 
    
    public DataFrameRow()
        : base(true)
    {

    }

    public DataFrameRow(X1 x1, DataFrameSchema? Schema = null)
        : base(false,Schema)
    {
        this.x1 = x1;
    }

    /// <summary>
    /// The value of the first cell in the row
    /// </summary>
    public X1 x1 { get; }

    public override Index<object> ItemArray
        => index<object>(x1);

    public override string ToString()
        => toString(x1, "null");

    protected override Lst<ClrType> ColumnTypes
        => list(type<X1>());
}
