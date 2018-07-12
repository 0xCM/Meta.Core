//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.IO;

using static minicore;


public abstract class FileSystemObject<T> : DomainPrimitive<T, string>, IFileSystemObject
    where T : FileSystemObject<T>, new()
{
    public static readonly T Empty = new T();

    /// <summary>
    /// Creates a file system object representation which may or may not actually exist
    /// </summary>
    /// <param name="x">The textual representation of the object</param>
    /// <returns></returns>
    public static T Parse(string x)
    {
        if (x is null)
            throw new ArgumentNullException("A null value is not allowed for a path specification");
        return Empty.Reconstructor(x);
    }

    /// <summary>
    /// Gets the primary path separator
    /// </summary>
    protected static readonly string sep_default
        = Path.DirectorySeparatorChar.ToString();

    /// <summary>
    /// Gets the secondary path separator
    /// </summary>
    protected static readonly string sep_alt
        = Path.AltDirectorySeparatorChar.ToString();

    protected static string Normalize(string s)
        => isBlank(s)
        ? string.Empty
        : s.Replace("file:///", string.Empty).Replace(sep_alt, sep_default);

    protected FileSystemObject()
        : base(string.Empty)
    {
    }

    public FileSystemObject(string Value)
        : base(Normalize(Value))
    {

    }

    /// <summary>
    /// Specifies the expanded path, replacing any environment variables with
    /// their environment-specific values
    /// </summary>
    public virtual string FileSystemPath
        => ScriptText.SpecifyEnvironmentParameters(Value);

    protected abstract Func<string, T> Reconstructor { get; }

    /// <summary>
    /// Determines whether the represented object exists in the file system
    /// </summary>
    /// <returns></returns>
    public abstract bool Exists();

    /// <summary>
    /// Calculates the structural equality between this and another object
    /// </summary>
    /// <param name="other">The other file system object</param>
    /// <returns></returns>
    public override bool Equals(T other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

}