//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

/// <summary>
/// Base type for specialized generic <see cref="IDataFrame"/> realizations
/// </summary>
public abstract partial class DataFrame : IDataFrame
{

    public DataFrame(DataFrameSchema Description)
    {
        this.Schema = Description;
    }

    public DataFrameSchema Schema { get; }


    protected abstract Seq<IDataFrameRow> Weaken();


    Seq<IDataFrameRow> IDataFrame.UntypedRows
        => Weaken();

    public static DataFrame<X1> Define<X1>(Seq<DataFrameRow<X1>> rows, DataFrameSchema schema = null)
        => new DataFrame<X1>(rows, schema);



}




