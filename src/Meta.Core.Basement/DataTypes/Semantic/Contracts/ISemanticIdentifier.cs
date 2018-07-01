//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;

public interface ISemanticIdentifier 
{
    string IdentifierText { get; }

    ISemanticIdentifier New(string IdentifierText);

    bool IsEmpty { get; }
}

public interface ISemanticIdentifier<I> : ISemanticIdentifier
{
    I Identifier { get; }
}
