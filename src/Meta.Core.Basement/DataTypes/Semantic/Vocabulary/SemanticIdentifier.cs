//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using System;

public abstract class SemanticIdentifier<X, I> : ISemanticIdentifier<I>, IEquatable<SemanticIdentifier<X,I>>
    where X : SemanticIdentifier<X, I>
{    

    public static readonly X Empty =
        typeof(X).TryGetDefaultPrivateConstructor()
                 .Map(
                    c => (X)c.Invoke(new object[] { }), () => default(X));

    public static X Parse(string IdentifierText)
        => Empty.New(IdentifierText ?? string.Empty);


    public static bool operator == (SemanticIdentifier<X,I> left, SemanticIdentifier<X,I> right)
        => left?.Equals(right) ?? false;

    public static bool operator !=(SemanticIdentifier<X, I> left, SemanticIdentifier<X, I> right)
        => !(left?.Equals(right) ?? false);


    public static implicit operator I(SemanticIdentifier<X,I> x)
        => x.Identifier;

    protected SemanticIdentifier(I Identifier)
    {
        this.Identifier = Identifier;
    }

    public I Identifier { get; }

    public virtual string IdentifierText
        => Identifier?.ToString() ?? String.Empty;


    public bool Equals(SemanticIdentifier<X, I> other)
        => Equals(Identifier, other.Identifier);

    public override bool Equals(object obj)
        => (obj as SemanticIdentifier<X, I>)?.Equals(this) ?? false;

    public override string ToString()
        => Identifier.ToString();

    public override int GetHashCode()
        => typeof(X).GetHashCode() & Identifier.GetHashCode();

    protected abstract X New(string IdentifierText);

    public virtual bool IsEmpty
        => Object.ReferenceEquals(this, Empty);

    ISemanticIdentifier ISemanticIdentifier.New(string IdentifierText)
        => New(IdentifierText);

    bool ISemanticIdentifier.IsEmpty
        => IsEmpty;
}

public sealed class SemanticIdentifier : SemanticIdentifier<SemanticIdentifier, string> 
{
    readonly Type SpecializedType;

    public SemanticIdentifier(Type SpecializedType, string IdentifierText)
        : base(IdentifierText)
    {
        this.SpecializedType = SpecializedType;
    }

    protected override SemanticIdentifier New(string IdentifierText)
        => new SemanticIdentifier(SpecializedType, IdentifierText);

}
