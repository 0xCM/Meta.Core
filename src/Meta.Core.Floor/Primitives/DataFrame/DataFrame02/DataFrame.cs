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

partial class DataFrame
{
    public static DataFrame<X1, X2> Define<X1, X2>(Seq<DataFrameRow<X1, X2>> rows, DataFrameSchema schema = null)
        => new DataFrame<X1, X2>(rows, schema);
}


/// <summary>
/// Realizes a two-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
public class DataFrame<X1, X2> : DataFrame
{
    public DataFrame(Seq<DataFrameRow<X1, X2>> Rows, DataFrameSchema Schema = null)
        : base(Schema)
            => this.Rows = Rows;

    public Index<DataFrameRow<X1, X2>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
}
