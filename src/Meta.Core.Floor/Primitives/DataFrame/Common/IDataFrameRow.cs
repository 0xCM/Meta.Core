//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

public interface IDataFrameRow
{
    DataFrameSchema Schema { get; }

    /// <summary>
    /// The data contained by the row represented as a 0-based index of objects
    /// </summary>
    Index<object> Data { get; }
}
