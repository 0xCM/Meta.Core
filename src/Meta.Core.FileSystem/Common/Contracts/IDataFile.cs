//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
    
/// <summary>
/// Defines contract for representation of a file
/// </summary>
public interface IDataFile : IFileSystemObject
{
    /// <summary>
    /// The file from which the current file was derived via <see cref="Emit(FilePath)"/>, if applicable
    /// </summary>
    IDataFile Ancestor { get; }
        
    /// <summary>
    /// The logical path to the source file
    /// </summary>
    FilePath SourcePath { get; }

    /// <summary>
    /// Streams the segments in the file to the caller
    /// </summary>
    /// <returns></returns>
    IEnumerable<DataFileSegment> Read();

    /// <summary>
    /// Writes the represented file to the output path and returns a new <see cref="IDataFile"/> instance
    /// that represents the emitted file
    /// </summary>
    /// <param name="path">The path to which the file should be emitted</param>
    IDataFile Emit(FilePath path);

    /// <summary>
    /// Gets the name of the file, excluding the path
    /// </summary>
    FileName FileName { get; }

    /// <summary>
    /// Gets the location of the file, e.g., the directory in which the file lives
    /// </summary>
    FolderPath Location { get; }

    /// <summary>
    /// Specifies the MIME file type
    /// </summary>
    ContentType FileContentType { get; }
}



