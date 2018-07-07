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
/// Realizes a four-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the third column</typeparam>
public class DataFrame<X1, X2, X3, X4> : DataFrameRoot<DataFrame<X1, X2, X3, X4>>
{
    public DataFrame()
        : base(null)
        => this.Rows = Seq<DataFrameRow<X1, X2,X3,X4>>.Empty;

    public DataFrame(Seq<DataFrameRow<X1, X2, X3, X4>> DataRows, DataFrameSchema? Description = null)
        : base(Description)
    {
        this.Rows = DataRows;
    }

    public Index<DataFrameRow<X1, X2, X3,X4>> Rows { get; }

    public override Seq<Index<object>> ItemArrays
        => from row in Rows
           select row.ItemArray;

    public override DataFrame<X1, X2, X3, X4> Construct(Seq<object[]> data, DataFrameSchema? schema = null)
        => DataFrame.make(map(data, item => DataFrameRow.make((X1)item[0], (X2)item[1], (X3)item[2], (X4)item[3], schema)));

}
