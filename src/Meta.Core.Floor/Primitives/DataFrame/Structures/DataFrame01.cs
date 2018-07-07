//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

using static metacore;

public class DataFrame<X1> : DataFrameRoot<DataFrame<X1>>
{
    public DataFrame()
        : base(null)
        => this.Rows = Seq<DataFrameRow<X1>>.Empty;

    public DataFrame(Seq<DataFrameRow<X1>> rows, DataFrameSchema? schema = null)
        : base(schema)
            => this.Rows = rows;

    public Index<DataFrameRow<X1>> Rows { get; }

    public override Seq<Index<object>> ItemArrays
        => from row in Rows
           select row.ItemArray;


    public override DataFrame<X1> Construct(Seq<object[]> data, DataFrameSchema? schema = null)
        => DataFrame.make(map(data, item => DataFrameRow.make((X1)item[0], schema)));

    

}
