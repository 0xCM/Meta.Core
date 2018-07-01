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
    /// <summary>
    /// Constructs a data frame from a stream of six-column rows
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="schema">The associated schema</param>
    /// <param name="rows">The data stream</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5, X6>
        Define<X1, X2, X3, X4, X5, X6>(Seq<DataFrameRow<X1, X2, X3, X4, X5, X6>> rows,
            DataFrameSchema schema = null)
                => new DataFrame<X1, X2, X3, X4, X5, X6>(rows, schema);

}

/// <summary>
/// Realizes a six-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
/// <typeparam name="X5">The data type of the fifth column</typeparam>
/// <typeparam name="X6">The data type of the sixth column</typeparam>
public class DataFrame<X1, X2, X3, X4, X5, X6> : DataFrame
{
    public DataFrame(Seq<DataFrameRow<X1, X2, X3, X4, X5, X6>> DataRows, DataFrameSchema Description = null)
        : base(Description)
    {
        this.Rows = DataRows;
    }

    public Index<DataFrameRow<X1, X2, X3, X4, X5, X6>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
}
