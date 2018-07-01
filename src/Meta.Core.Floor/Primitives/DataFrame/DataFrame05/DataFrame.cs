//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

using static metacore;

partial class DataFrame
{

    /// <summary>
    /// Construcs a 5-column data frame from a stream of rows
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="DataRows">The source rows</param>
    /// <returns></returns>
    public static DataFrame<X1, X2, X3, X4, X5> Define<X1, X2, X3, X4, X5>(DataFrameSchema Schema,
            Seq<DataFrameRow<X1, X2, X3, X4, X5>> DataRows)
                => new DataFrame<X1, X2, X3, X4, X5>(Schema, DataRows);
}


/// <summary>
/// Realizes a four-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the fourth column</typeparam>
/// <typeparam name="X5">The data type of the fifth column</typeparam>
public class DataFrame<X1, X2, X3, X4, X5> : DataFrame
{

    public DataFrame(DataFrameSchema Description, Seq<DataFrameRow<X1, X2, X3, X4, X5>> DataRows)
        : base(Description)
    {
        this.Rows = DataRows;
    }

    public Index<DataFrameRow<X1, X2, X3, X4, X5>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
}
