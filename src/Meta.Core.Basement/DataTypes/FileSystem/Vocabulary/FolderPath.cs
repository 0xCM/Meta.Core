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
/// Represents a path to a folder
/// </summary>
public sealed class FolderPath : DomainPrimitive<FolderPath, string>, IFolderPath
{
    public static readonly FolderPath Empty 
        = new FolderPath(String.Empty);

    public static readonly FolderPath None
        = Empty;

    /// <summary>
    /// Gets the current working directory from the environment
    /// </summary>
    public static FolderPath CurrentDirectory
        => Environment.CurrentDirectory;

    /// <summary>
    /// Creates a <see cref="FolderPath"/> representation
    /// </summary>
    /// <param name="Value">The value to transform</param>
    /// <returns></returns>
    public static FolderPath Parse(string Value)
        => new FolderPath(Value);

    /// <summary>
    /// Implcitly constructs a <see cref="FolderPath"/> value from a string
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator FolderPath(string x)
        => new FolderPath(x ?? String.Empty);

    /// <summary>
    /// Implcitly constructs a <see cref="Uri"/> value from a <see cref="FolderPath"/> value
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator Uri(FolderPath x)
        => new Uri($"file:///{x.ToString().Replace('\\', '/')}");

    /// <summary>
    /// Implicitly converts the path to a string
    /// </summary>
    /// <param name="x">The path to convert</param>
    public static implicit operator string(FolderPath x)
        => x?.FileSystemPath ?? String.Empty;

    /// <summary>
    /// Combines a folder and a filename to produce a <see cref="FilePath"/>
    /// </summary>
    /// <param name="folder">The folder path</param>
    /// <param name="file">The filename</param>
    /// <returns></returns>
    public static FilePath operator +(FolderPath folder, FileName file)
        => FilePath.Parse(Path.Combine(folder, file));

    /// <summary>
    /// Combines a folder and a filename to produce a <see cref="FilePath"/>
    /// </summary>
    /// <param name="path">The folder path</param>
    /// <param name="folderName">The folder name</param>
    /// <returns></returns>
    public static FolderPath operator +(FolderPath path, FolderName folderName)
        =>  Parse(Path.Combine(path, folderName));

    /// <summary>
    /// Combines a folder path and a relative path to produce a folder path
    /// </summary>
    /// <param name="folder">The folder path</param>
    /// <param name="relative">The relative path</param>
    /// <returns></returns>
    public static FolderPath operator +(FolderPath folder, RelativePath relative)
        => Parse(Path.Combine(folder, relative));

    FolderPath()
    {

    }

    public FolderPath(string FullPath)
    : base( FullPath.EndsWith(":") ?   FullPath + "\\" : FullPath)
    {
    }

    /// <summary>
    /// Specifies the physical file system path
    /// </summary>
    public string FileSystemPath
        => ScriptText.SpecifyEnvironmentParameters(Value);

    /// <summary>
    /// Gets the literal value of the path, prior to any environment parameter expansions
    /// </summary>
    public string FullPath
        => base.Value;

    /// <summary>
    /// Gets the name of the folder, i.e. the value of the last path component
    /// </summary>
    public FolderName FolderName
        => not(string.IsNullOrWhiteSpace(FullPath))
        ?  FolderName.Parse(Path.GetFileName(FullPath.TrimEnd('/')))
        : global::FolderName.None;

    /// <summary>
    /// Creates a <see cref="FilePath"/> by appending a relative path to the represented folder path
    /// </summary>
    /// <param name="RelativePath">The relative path to append</param>
    /// <returns></returns>
    public FilePath GetCombinedFilePath(RelativePath RelativePath)
        => Path.Combine(FullPath, RelativePath);

    /// <summary>
    /// Creates a <see cref="FolderPath"/> by appending a relative path to the represented folder path
    /// </summary>
    /// <param name="RelativePath">The relative path to append</param>
    /// <returns></returns>
    public FolderPath GetCombinedFolderPath(RelativePath RelativePath)
        => Path.Combine(FullPath, RelativePath);

    /// <summary>
    /// Returns true if the path has no value
    /// </summary>
    public bool IsUnspecified
        => isBlank(Value);

    /// <summary>
    /// Modifies the folder path by appending specified text to the path anme
    /// </summary>
    /// <param name="text">The text to append to the path name</param>
    /// <returns></returns>
    public FolderPath Append(string text)
        => this.Value + text;

    /// <summary>
    /// Modifies the folder path by appending a specified character to the path name
    /// </summary>
    /// <param name="c">The character to append to the path name</param>
    /// <returns></returns>
    public FolderPath Append(char c)
        => this.Value + c;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

    public override bool Equals(FolderPath other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override string ToString()
        => FileSystemPath;

}
