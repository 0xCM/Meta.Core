//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines contract for representation of a binary file
/// </summary>
public interface IBinaryFile : IDataFile
{
    /// <summary>
    /// Streams bytes to the caller each of which have a specified maximum length 
    /// </summary>
    /// <param name="maxlen">The maximum length of the returned byte array</param>
    /// <returns></returns>
    IEnumerable<BinaryFileSegment> Read(int maxlen);
}

