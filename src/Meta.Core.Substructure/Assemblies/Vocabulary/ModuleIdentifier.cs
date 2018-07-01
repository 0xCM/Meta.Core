//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using X = ModuleIdentifier;
using I = System.String;

/// <summary>
/// Identifies a module where a module is defined as a collection
/// of one or more artifacts, each of which may determine a 
/// module aggregation.
/// </summary>
public sealed class ModuleIdentifier : SemanticIdentifier<X, I>
{

    public static implicit operator X(ComponentIdentifier component)
        => new X(component.IdentifierText);


    //public static FileName operator +(X id, FileExtension ext)
    //    => FileName.Parse(id.IdentifierText).AddExtension(ext);

    public static implicit operator X(I x)
        => new X(x);

    protected override X New(I text)
        => new X(text);


    ModuleIdentifier()
        : base(string.Empty) {}

    ModuleIdentifier(I text)
        : base(text)
    {

    }
}

