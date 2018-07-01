//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using static metacore;

using Meta.Core;

/// <summary>
/// Characterizes a data frame, a lightweight alternative to DataSet
/// that is immutable and allows both strong and weakly typed interaction
/// </summary>
public interface IDataFrame
{
    DataFrameSchema Schema { get; }

    Seq<IDataFrameRow> UntypedRows { get; }
}
