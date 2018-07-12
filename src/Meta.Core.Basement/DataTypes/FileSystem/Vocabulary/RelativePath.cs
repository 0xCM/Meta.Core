//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using static minicore;

/// <summary>
/// Represents a relative file system path
/// </summary>
public sealed class RelativePath : DomainPrimitive<RelativePath, string>
{
    public static readonly RelativePath None 
        = new RelativePath(String.Empty);

    public bool IsEmpty
        => not(this.IsSome);
       
    static readonly string sep_default 
        = Path.DirectorySeparatorChar.ToString();

    static readonly string sep_alt 
        = Path.AltDirectorySeparatorChar.ToString();

    internal static string Normalize(string s)
    {
        if (isBlank(s))
            return string.Empty;

        var x = s.Replace(sep_alt, sep_default);
        var y = x.StartsWith(sep_default) ? x.Substring(1) : x;
        return y;
    }

    /// <summary>
    /// Create a relative path from a list of constituent components
    /// </summary>
    /// <param name="components">The components used to form the path</param>
    /// <returns></returns>
    public static RelativePath FromComponents(params string[] components)
        => new RelativePath(string.Join(sep_default, components));

    /// <summary>
    /// Defines canonical parse method for <see cref="RelativePath"/> types
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static RelativePath Parse(string Value)
        => new RelativePath(Value);

    public static implicit operator RelativePath(FileName x)
        => new RelativePath(x);

    public static implicit operator RelativePath(string x)
        => new RelativePath(x);

    public static RelativePath operator + (RelativePath left, RelativePath right)
        => Path.Combine(left, right);
   
    RelativePath()
    { }

    public RelativePath(string Value)
        : base(Normalize(Value))
    {

    }

    /// <summary>
    /// Returns true if a value is specified for the file system object, otherwise false
    /// </summary>
    public bool IsSome
            => string.IsNullOrWhiteSpace(Value);

    public RelativePath Combine(RelativePath p)
        =>  (p == null || p.Equals(None)) 
        ?   p  :  new RelativePath(Path.Combine(Value, p.Value));

    public IReadOnlyList<string> Components
        => Value.Split(sep_default[0]);

    public override bool Equals(RelativePath other)
       => string.Compare((other?.Value ?? string.Empty), this.Value, true) == 0;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

}
