// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;
using Meta.Core.Modules;


partial class DataFrame
{
    public static DataFrame<X1, X2, X3, X4> Define<X1, X2, X3, X4>(
            Seq<DataFrameRow<X1, X2, X3, X4>> DataRows, DataFrameSchema Schema = null)
                => new DataFrame<X1, X2, X3, X4>(DataRows, Schema);
}


/// <summary>
/// Realizes a four-column data frame
/// </summary>
/// <typeparam name="X1">The data type of the first column</typeparam>
/// <typeparam name="X2">The data type of the second column</typeparam>
/// <typeparam name="X3">The data type of the third column</typeparam>
/// <typeparam name="X4">The data type of the third column</typeparam>
public class DataFrame<X1, X2, X3, X4> : DataFrame
{
    public DataFrame(Seq<DataFrameRow<X1, X2, X3, X4>> DataRows, DataFrameSchema Description = null)
        : base(Description)
    {
        this.Rows = DataRows;
    }

    public Index<DataFrameRow<X1, X2, X3,X4>> Rows { get; }

    protected override Seq<IDataFrameRow> Weaken()
        => Seq.make(Rows.Stream().Cast<IDataFrameRow>());
}
