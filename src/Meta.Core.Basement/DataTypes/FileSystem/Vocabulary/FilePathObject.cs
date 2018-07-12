//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.IO;

using Meta.Core;

using static minicore;

/// <summary>
/// Reprents a file path
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
public abstract class FilePath<T> : FileSystemObject<T>, IFilePath
    where T : FilePath<T>, new()
{
    protected static FilePath DeleteIfExists(FilePath p)
    {
        if (p.Exists())
            File.Delete(p);
        return p;
    }

    protected FilePath()
        : base(string.Empty)
    {
    }

    public FilePath(string Value)
        : base(Normalize(Value))
    {

    }

    /// <summary>
    /// Returns true if the encapsulated path string is empty
    /// </summary>
    public bool IsEmpty
        => String.IsNullOrWhiteSpace(Value);

    /// <summary>
    /// Returns true if the encapsulated path string is empty
    /// </summary>
    public bool IsSpecified
        => not(String.IsNullOrWhiteSpace(Value));

    /// <summary>
    /// Determines whether the represented file exists
    /// </summary>
    /// <returns></returns>
    public override bool Exists()
        => IsEmpty ? false : File.Exists(FileSystemPath);

    /// <summary>
    /// Gets the file's <see cref="global::FileName"/>
    /// </summary>
    public FileName FileName
        => IsEmpty ? FileName.Empty 
            : FileName.Parse(Path.GetFileName(this));
        
    /// <summary>
    /// Gets the <see cref="FolderPath"/> in which the file resides
    /// </summary>
    public FolderPath Folder
        => IsEmpty 
        ? FolderPath.Empty 
        : FolderPath.Parse(Path.GetDirectoryName(this));

    /// <summary>
    /// Gets the file's <see cref="FileExtension"/> 
    /// </summary>
    public FileExtension Extension
        => IsEmpty 
        ? FileExtension.Empty 
        : FileExtension.Parse(Path.GetExtension(this));

    /// <summary>
    /// If the file exists, returns the timestamp when it was last modified,
    /// consistent with the value displayed in explorer in the "Date Modified" column
    /// </summary>
    public DateTime? ModifiedTime
        => Exists() ? File.GetLastWriteTime(Value) : (DateTime?)null;

    /// <summary>
    /// If the file exists, returns the size of the file; otherwise, returns null
    /// </summary>
    public long? FileSize
        => Exists() ? new FileInfo(Value).Length : (long?)null;

    /// <summary>
    /// Changes the extension of the file
    /// </summary>
    /// <param name="newExtension">The new extension</param>
    /// <returns></returns>
    public T ChangeExtension(FileExtension newExtension)
        => Reconstructor(Path.ChangeExtension(Value, newExtension));


    IFolderPath IFilePath.Folder
        => Folder;
}

