//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines contract for representation of a text file
/// </summary>
public interface ITextFile : IDataFile
{
    /// <summary>
    /// Streams the lines in the file to the caller
    /// </summary>
    /// <returns></returns>
    new IEnumerable<TextLine> Read();

    /// <summary>
    /// Read a specifiec number of lines from the beginning of the file
    /// </summary>
    /// <param name="count">The number of lines to read</param>
    /// <returns></returns>
    IEnumerable<TextLine> ReadFirst(int count);

    /// <summary>
    /// Streams the incoming lines into the file
    /// </summary>
    /// <returns></returns>
    Option<FilePath> Overwrite(IEnumerable<TextLine> lines);

}

