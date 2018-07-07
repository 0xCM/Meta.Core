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
/// Realizes a two-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
public class DataFrame<X1, X2> : DataFrameRoot<DataFrame<X1,X2>>
{
    public DataFrame()
        : base(null)
        => this.Rows = Seq<DataFrameRow<X1,X2>>.Empty;

    public DataFrame(Seq<DataFrameRow<X1, X2>> Rows, DataFrameSchema? Schema = null)
        : base(Schema)
            => this.Rows = Rows;

    public Index<DataFrameRow<X1, X2>> Rows { get; }

    public override Seq<Index<object>> ItemArrays
        => from row in Rows
           select row.ItemArray;

    public override DataFrame<X1, X2> Construct(Seq<object[]> data, DataFrameSchema? schema = null)
        => DataFrame.make(map(data, item => DataFrameRow.make((X1)item[0], (X2)item[1], schema)));
}
