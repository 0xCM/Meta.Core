//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using X = DistributionIdentifier;
using I = System.String;


/// <summary>
/// Identifies a set of components that have been partitioned for distribution
/// </summary>
public sealed class DistributionIdentifier :  SemanticIdentifier<X, I>
{
    public static implicit operator FolderName(X x)
        => new FolderName(x.IdentifierText);

    public static implicit operator X(I x) 
        => new X(x);

    protected override X New(I IdentifierText) 
        => new X(IdentifierText);

    DistributionIdentifier()
        : base(string.Empty)
    { }

    DistributionIdentifier(I text)
        : base(text)
    {

    }
}

public sealed class DistributionIdentifiers : TypedItemList<DistributionIdentifiers, X>
{
    public DistributionIdentifiers()
    {

    }
}

