//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

/// <summary>
/// Characterizes a data frame, a lightweight alternative to DataSet
/// that is immutable and allows both strong and weakly typed interaction
/// </summary>
public interface IDataFrame
{
    Option<DataFrameSchema> Schema { get; }

    Seq<Index<object>> ItemArrays { get; }
}
