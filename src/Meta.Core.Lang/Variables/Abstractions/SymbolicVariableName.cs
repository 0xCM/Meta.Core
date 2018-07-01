//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Identifies a symbolic variable
/// </summary>
public abstract class SymbolicVariableName<X> : SemanticIdentifier<X, string>
    where X : SymbolicVariableName<X>
{


    SymbolicVariableName()
        : base(string.Empty)
    { }

    public SymbolicVariableName(string text)
        : base(text)
    {

    }

    public SymbolicVariableName(char delimiter, params string[] NameComponents)
        : base(string.Join(delimiter.ToString(), NameComponents))
    {

    }
}

public sealed class SymbolicVariableName : SymbolicVariableName<SymbolicVariableName>
{

    public static implicit operator SymbolicVariableName(string name)
        => new SymbolicVariableName(name);

    protected override SymbolicVariableName New(string IdentifierText)
    {
        return new SymbolicVariableName(IdentifierText);
    }

    public SymbolicVariableName(string text)
        : base(text)
    {

    }

    SymbolicVariableName()
        : base(string.Empty)
    {

    }
}
