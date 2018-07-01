//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Core;
using Meta.Core.Modules;

using static metacore;

partial class DataFrame
{
}

public class DataFrame<X1> : DataFrame
{
    public DataFrame(Seq<DataFrameRow<X1>> rows, DataFrameSchema schema = null)
        : base(schema)
            => this.Rows = rows;

    public Index<DataFrameRow<X1>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
  
}
