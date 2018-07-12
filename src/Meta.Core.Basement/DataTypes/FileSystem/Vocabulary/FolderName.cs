//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.IO;

using Meta.Core;

using static minicore;


/// <summary>
/// Represents the name of a folder
/// </summary>
/// <typeparam name="F"></typeparam>
public abstract class FolderName<F> : DomainPrimitive<F, string>
    where F : FolderName<F>
{
    
    protected static string clean(string name)
        => ifNull(name, () => string.Empty).Trim('/', '\\');

    FolderName()
    { }

    public FolderName(string Value)
        : base(clean(Value))
    { }

    public FolderName UniqueName()
        => new FolderName($"{this.Value}.{Guid.NewGuid().ToString("N")}");
           
    public bool IsEmpty
        => String.IsNullOrWhiteSpace(Value);

}

public sealed class FolderName : FolderName<FolderName>
{
    public static readonly FolderName None
        = new FolderName(String.Empty);

    public static FolderName Parse(string name)
        => new FolderName(name);

    public static RelativePath operator +(FolderName parent, FolderName child)
        => Path.Combine(parent, child);

    public static implicit operator FolderName(string x)
        => new FolderName(x);

    public static implicit operator RelativePath(FolderName x)
        => new RelativePath(x);

    public FolderName(string Value)
        : base(clean(Value))
    { }

    public override bool Equals(FolderName other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();
}