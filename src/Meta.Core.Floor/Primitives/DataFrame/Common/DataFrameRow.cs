//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using static metacore;

using Meta.Core;

/// <summary>
/// Represents a row of data in a <see cref="IDataFrame"/>
/// </summary>
public partial class DataFrameRow : IDataFrameRow
{
    public static readonly DataFrameRow Empty 
        = new DataFrameRow(DataFrameSchema.Empty);

    public static DataFrameRow Create(DataFrameSchema Schema, Index<object> Data)
        => new DataFrameRow(Schema, Data);

    public DataFrameRow(DataFrameSchema Schema, Index<object> Data)
    {
        this.Schema = Schema;
        this.Data = Data;
    }

    protected DataFrameRow(DataFrameSchema Schema)
    {
        this.Data = new object[] { };
        this.Schema = Schema ?? DataFrameSchema.Empty;
    }

    /// <summary>
    /// The schema of the defining frame
    /// </summary>
    public DataFrameSchema Schema { get; }

    /// <summary>
    /// The encapsulated data
    /// </summary>
    public Index<object> Data { get; }


    protected virtual Index<object> Weaken()
        => Data;


}