//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Meta.Core;

    /// <summary>
    /// Characterizes a data frame, a lightweight alternative to DataSet
    /// that is immutable and allows both strong and weakly typed interaction
    /// </summary>
    public interface IDataFrame
    {

        Seq<Index<object>> ItemArrays { get; }
    }
}