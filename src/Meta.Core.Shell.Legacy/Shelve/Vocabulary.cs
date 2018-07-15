//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Assigns identity to a vocabulary
/// </summary>
public sealed class Vocabulary : SemanticIdentifier<Vocabulary, string>, IVocabulary
{
    public static implicit operator Vocabulary(string x)
        => new Vocabulary(x);

    protected override Vocabulary New(string text)
        => new Vocabulary(text);

    public RelativePath Location
        => RelativePath.Parse(IdentifierText);

    Vocabulary()
        : base(string.Empty) { }

    Vocabulary(string text)
        : base(text)
    {

    }
}



