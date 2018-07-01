//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Meta.Core;

using static metacore;


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
        => new FolderName($"{this.Value}.{guid().ToString("N")}");
           
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