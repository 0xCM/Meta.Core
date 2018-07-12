//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.IO;

using static minicore;

/// <summary>
/// Represents the name of a file
/// </summary>
/// <typeparam name="T">The concrete subtype</typeparam>
public abstract class FileName<T> : DomainPrimitive<T, string>
    where T : FileName<T>, new()
{
    public static readonly T Empty = new T();
    public static readonly T None = Empty;
    public static readonly char[] InvalidCharacters = Path.GetInvalidFileNameChars();

    /// <summary>
    /// Creates a <see cref="FileName{T}"/> from the supplied text
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static T Define(string text)
        => Empty.Reconstructor(text);

    static string Format(string FileName, FileExtension Extension)
        => ifNull(Extension, () => FileExtension.Empty).IsEmpty
        ? $"{FileName}"
        : $"{FileName}.{Extension.Value}";

    protected FileName(string Value)
        : base(Value)
    {
        Value.Iterate(c =>
        {
            if (InvalidCharacters.Contains(c))
                throw new ArgumentException($"The supplied filename {Value} is invalid");
        });
    }

    protected FileName(string Value, FileExtension Extension)
        : this(Format(Value, Extension))
    { }

    public bool StartsWith(string value)
        => this.Value.ToLower().StartsWith(value.ToLower());

    public FileExtension Extension
        => Path.GetExtension(Value);

    protected string WithoutExtension
        => Path.GetFileNameWithoutExtension(Value);

    public bool HasExtension(FileExtension extension)
        => string.Equals(Extension.Value, extension.Value, StringComparison.InvariantCultureIgnoreCase);

    public T RemoveExtension()
        => Reconstructor(WithoutExtension);

    public T ChangeExtension(FileExtension NewExtension)
        => Reconstructor(Path.ChangeExtension(Value, NewExtension));

    public T AddExtension(FileExtension x, bool onlyIfMissing = false)
    {
        if (onlyIfMissing)
        {
            if (HasExtension(Extension))
                return Clone();
        }

        return Reconstructor($"{Value}.{x}");
    }

    public T Replace(char search, char replace)
        => Reconstructor(Value.Replace(search, replace));

    public override bool Equals(T other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

    protected T Clone()
        => Reconstructor(Value);

    protected abstract Func<string, T> Reconstructor { get; }

}

public sealed class FileName : FileName<FileName>
{
    /// <summary>
    /// Defines a <see cref="FileName"/> instance but does not modify the file system
    /// </summary>
    /// <param name="fn">The filename without the extension</param>
    /// <param name="x">The extension, if specified</param>
    /// <returns></returns>
    public static FileName Define(string fn, FileExtension x = null)
        => x != null ? new FileName(fn, x) : new FileName(fn);    

    public static FileName operator +(FileName filename, FileExtension extension)
        => ifNull(filename, () => FileName.Empty).AddExtension(extension ?? Empty);

    /// <summary>
    /// Defines a <see cref="FileName"/> by concatenating an arbitrary number of 
    /// constituent parts
    /// </summary>
    /// <param name="parts">The parts to concatenate</param>
    /// <returns></returns>
    public static FileName Parse(params string[] parts)
        => string.Join(string.Empty, parts);

    //public static implicit operator FilePath(FileName x)
    //    => new FilePath(x.Value);

    public static implicit operator FileName(string x)
        => new FileName(x);

    public FileName()
        : base(String.Empty)
    { }

    public FileName(string Value)
        : base(Value ?? String.Empty)
    { }

    public FileName(string Value, FileExtension Extension)
        : base(Value ?? String.Empty, Extension)
    { }

    public FileName UniqueName()
    {
        var ext = $"{Guid.NewGuid().ToString("N")}.{Extension}";
        return this.ChangeExtension(ext);
    }
   
    public FileName Replace(string substring, string replacement)
        => Value.Replace(substring, replacement);

    protected override Func<string, FileName> Reconstructor
        => text => new FileName(text);

    /// <summary>
    /// Appends an <see cref="FileExtension"/> value to a <see cref="FileName"/> value
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public FileName Append(FileExtension x)
        => FileName.Parse($"{this.Value}.{x.Value}");
}
