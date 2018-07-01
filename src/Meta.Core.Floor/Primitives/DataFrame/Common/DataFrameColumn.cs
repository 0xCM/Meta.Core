//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

/// <summary>
/// Describes a <see cref="IDataFrame"/> column
/// </summary>
public class DataFrameColumn
{
    public DataFrameColumn(string ColumnName, int Position, CoreTypeReference DataType)
    {
        this.ColumnName = ColumnName;
        this.Position = Position;
        this.DataType = this.DataType;
    }

    /// <summary>
    /// The column name
    /// </summary>
    public string ColumnName { get; }

    /// <summary>
    /// The column position
    /// </summary>
    public int Position { get; }

    /// <summary>
    /// The column's data type
    /// </summary>
    public CoreTypeReference DataType { get; }

    public override string ToString()
        => concat(Position.ToString().PadLeft(2, '0'), space(), 
                ColumnName, space(), DataType.DataTypeName);
}