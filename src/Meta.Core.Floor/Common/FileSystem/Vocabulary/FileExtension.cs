﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using static metacore;

/// <summary>
/// File extention base type
/// </summary>
/// <typeparam name="T">The derived subypte</typeparam>
public abstract class FileExtension<T> : DomainPrimitive<T, string>
    where T : FileExtension<T>, new()
{
    public static readonly T Empty = new T();
    public static readonly T None = Empty;

    public FileExtension(string Value)
        : base(Value.StartsWith(".") && Value.Length > 1 ? Value.Substring(1) : Value)
    {

    }

    public override bool Equals(T other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();
}

/// <summary>
/// Specifies a file extension
/// </summary>
public sealed class FileExtension : FileExtension<FileExtension>
{
    public static FileExtension operator +(FileExtension x, FileExtension y)
        => ifNull(x, () => Empty).Combine(y);

    public static FileExtension Parse(string Value)
        => isBlank(Value) ? Empty : new FileExtension(Value);

    public static implicit operator FileExtension(string x)
        => isBlank(x) ? Empty : new FileExtension(x);

    public static implicit operator FileExtension(FileName x)
        => (x is null || Empty.Equals(x)) ? x :  x.Extension;


    public FileExtension()
        : base(string.Empty)
    { }
    
    public FileExtension(string Value)
        : base(ltrim(Value ?? string.Empty, '.'))
    {

    }

    /// <summary>
    /// Specifies whether the extension value is equivalent to the canonical empty value
    /// </summary>
    public bool IsEmpty
        => isBlank(this.Value);

    /// <summary>
    /// Appends a second (third, fourth...) extension to the existing extension
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public FileExtension Combine(FileExtension x)
        => new FileExtension((x is null || isBlank(x))
            ? $"{this}" :  $"{this}.{x}");

}
