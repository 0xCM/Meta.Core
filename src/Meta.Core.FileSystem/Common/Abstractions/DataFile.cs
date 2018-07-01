//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.IO;

/// <summary>
/// Represents a file that contains data of interest/records and provides an <see cref="IDataFile"/> realization
/// </summary>
public abstract class DataFile : IDataFile
{
    /// <summary>
    /// Initializes a new <see cref="DataFile"/> instance
    /// </summary>
    /// <param name="SourcePath">The location of the represented file</param>
    protected DataFile(FilePath SourcePath, ContentType FileContentType)
    {
        this.SourcePath = SourcePath;
        this.FileContentType = FileContentType;
    }

    /// <summary>
    /// Initializes a new <see cref="DataFile"/> instance
    /// </summary>
    /// <param name="SourcePath">The location of the represented file</param>
    /// <param name="Ancestor">The file from which the new file was derived</param>
    protected DataFile(FilePath SourcePath, ContentType FileContentType, IDataFile Ancestor)
        : this(SourcePath, FileContentType)
    {
        _Ancestor = Ancestor;
    }

    /// <summary>
    /// Specifies the file's ancestor
    /// </summary>
    IDataFile _Ancestor { get; }

    /// <summary>
    /// Specifies the path to the file
    /// </summary>
    FilePath SourcePath { get; }

    /// <summary>
    /// Identifies the file content type
    /// </summary>    
    ContentType FileContentType { get; }

    /// <summary>
    /// Writes the contents of the file to the specified path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public abstract IDataFile Emit(FilePath path);

    /// <summary>
    /// Gets the path of the file
    /// </summary>
    FilePath IDataFile.SourcePath 
        => SourcePath;

    /// <summary>
    /// Streams the file segments to the caller
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<DataFileSegment> ReadSegments();

    /// <summary>
    /// Implementation of the <see cref="IDataFile.Ancestor"/> property
    /// </summary>
    /// <returns></returns>
    IDataFile IDataFile.Ancestor 
        => _Ancestor;

    /// <summary>
    /// Implementation of the <see cref="IDataFile.Emit(FilePath)"/> operation
    /// </summary>
    /// <returns></returns>
    IDataFile IDataFile.Emit(FilePath path) 
        => Emit(path);

    /// <summary>
    /// Implementation of the <see cref="IDataFile.FileName"/> property
    /// </summary>
    /// <returns></returns>
    FileName IDataFile.FileName
        => SourcePath.FileName;

    /// <summary>
    /// Implementation of the <see cref="IDataFile.Location"/> property
    /// </summary>
    /// <returns></returns>
    FolderPath IDataFile.Location
        => SourcePath.Folder;

    /// <summary>
    /// Implementation of the <see cref="IDataFile.Read"/> operation
    /// </summary>
    /// <returns></returns>
    IEnumerable<DataFileSegment> IDataFile.Read() 
        => ReadSegments();

    /// <summary>
    /// Implementation of the <see cref="IDataFile.FileContentType"/> operation
    /// </summary>
    /// <returns></returns>
    ContentType IDataFile.FileContentType 
        => FileContentType;

    /// <summary>
    /// Returns true if the file exists, false otherwise
    /// </summary>
    /// <returns></returns>
    public bool Exists()
        => File.Exists(SourcePath);

    /// <summary>
    /// Specifies the name of the file
    /// </summary>
    public FileName FileName
        => this.SourcePath.FileName;

    string IFileSystemObject.FileSystemPath
        => this.SourcePath.FileSystemPath;

    public override string ToString()
         => SourcePath;
}

/// <summary>
/// Represents a file that contains data segments/records of a specific type
/// </summary>
/// <typeparam name="T">The segment type</typeparam>
public abstract class DataFile<T> : DataFile, IDataFile
    where T : DataFileSegment
{

    protected DataFile(FilePath SourcePath, ContentType FileContentType)
        : base(SourcePath, FileContentType)
    {
    }

    protected DataFile(FilePath SourcePath, ContentType FileContentType, IDataFile Ancestor)
        : base(SourcePath, FileContentType, Ancestor)
    {
    }

    protected sealed override IEnumerable<DataFileSegment> ReadSegments() 
        => Read();

    public abstract IEnumerable<T> Read();


}

