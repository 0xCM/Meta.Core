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
    public static DataFrame<X1, X2, X3> Define<X1, X2, X3>(Seq<DataFrameRow<X1, X2, X3>> rows, DataFrameSchema schema = null)
        => new DataFrame<X1, X2, X3>(rows, schema);
}

/// <summary>
/// Chracterizes a three-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the second column</typeparam>
public interface IDataFrame<X1, X2, X3> : IDataFrame
{
    Index<DataFrameRow<X1, X2, X3>> Rows { get; }
}

/// <summary>
/// Realizes a three-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
public class DataFrame<X1, X2, X3>  : DataFrame
{
    public DataFrame(Seq<DataFrameRow<X1, X2, X3>> rows, DataFrameSchema schema = null)
        : base(schema)
        => this.Rows = rows;

    public Index<DataFrameRow<X1, X2, X3>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
}
