//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using X = ModuleArea;
using I = System.String;

/// <summary>
/// Identifies a module area
/// </summary>
public sealed class ModuleArea : SemanticIdentifier<X, I>
{
    //public static implicit operator FolderName(X x)
    //    => x.IdentifierText;

    public static implicit operator X(I i)
        => new X(i);

    protected override X New(I i)
        => new X(i ?? I.Empty);


    ModuleArea()
        : base(I.Empty)
    { }

    public ModuleArea(I i)
        : base(i)
    {

    }


}


