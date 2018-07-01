//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using X = ComponentIdentifier;
using I = System.String;

/// <summary>
/// Assigns identity to a component within some context
/// </summary>
public sealed class ComponentIdentifier : SemanticIdentifier<X, I>
{
    public static implicit operator X(ModuleIdentifier module)
        => new X(module.IdentifierText);

    public static implicit operator X(I x)
        => new X(x);

    protected override X New(I text)
        => new X(text);

    //public RelativePath Location
    //    => RelativePath.Parse(IdentifierText);

    ComponentIdentifier()
        : base(string.Empty) {}

    ComponentIdentifier(I text)
        : base(text)
    {
        
    }
}

