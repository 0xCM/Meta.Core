//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

public interface IDataFrameRow
{
    DataFrameSchema Schema { get; }

    /// <summary>
    /// Presents the encapsulated data as an array of objects
    /// </summary>
    Index<object> ItemArray { get; }
}
