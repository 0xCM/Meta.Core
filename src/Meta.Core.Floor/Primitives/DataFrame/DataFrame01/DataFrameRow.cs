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
    public static DataFrameRow<X1> Define<X1>(X1 x1, DataFrameSchema schema = null)
        => new DataFrameRow<X1>(x1, schema);
}


public class DataFrameRow<X1> : DataFrameRow
{ 
    public DataFrameRow(X1 x1, DataFrameSchema Schema = null)
        : base(Schema)
    {
        this.x1 = x1;
    }

    /// <summary>
    /// The value of the first cell in the row
    /// </summary>
    public X1 x1 { get; }

    protected override Index<object> Weaken()
        => index<object>(x1);
}
