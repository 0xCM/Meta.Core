//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


using static metacore;


using Meta.Core;

public abstract class SymbolicVariable<S,V> : IEquatable<S>, ISymbolicVariable<V>
    where S : SymbolicVariable<S,V>, new()
{
    /// <summary>
    /// Joins the left symbolic variable with the right symbolic variable
    /// </summary>
    /// <param name="L"></param>
    /// <param name="R"></param>
    /// <returns>A symbolic variable that represents the join</returns>    
    /// <remarks>
    /// Note that this operation is NOT commutative!
    /// </remarks>
    public static S operator + (SymbolicVariable<S,V> L, S R)
        => L.Join(R);

    public static bool operator == (SymbolicVariable<S,V> L, S R)
        => L.Equals(R);

    public static bool operator != (SymbolicVariable<S,V> L, S R)
        => L.Equals(R);

    public static implicit operator string(SymbolicVariable<S,V> v)
        => v.ToString();

    static bool CompareAttributes(S l, S r)
    {
        bool equal = true;
        equal &= equals(l.VariableName, r.VariableName);
        equal &= equals(l.Label, r.Label);
        equal &= equals(l.Label, r.Label);
        equal &= l.IsRoot == r.IsRoot;
        return equal;
    }

    protected SymbolicVariable(string Name = null, string Label = null, string Description = null, Symbol? Delimiter = null)
    {
        this.VariableName = ifBlank(Name, "anonymous");
        this.Label = ifBlank(Label, Name);
        this.Description = ifBlank(Description, string.Empty);
        this.Components = roitems((S)this);
        this.Delimiter = Delimiter ?? Symbol.pipe;
        this.IsRoot = true;
    }

    protected IReadOnlyList<S> Components { get; private set; }

    protected virtual Symbol Delimiter { get; }

    bool IsRoot { get; set; }   

    public SymbolicVariableName VariableName { get; private set; }

    public bool IsAnonymous
        => VariableName.IsEmpty;

    public bool IsEmpty
        => Components.Count == 0;

    public string Label { get; private set; }

    public string Description { get; private set; }

    IEnumerable<ISymbolicExpression> ISymbolicExpression.Components
        => stream<ISymbolicExpression>();

    public SymbolicReference CreateReference()
        => new SymbolicReference(this);

    protected abstract ISymbolicFormatter DefaultFormatter { get; }

    Option<object> ISymbolicVariable.ResolveValue()
        => ResolveValue();

    public virtual string Format()
        => string.Join(Delimiter.Represenation, Components);

    S Copy(S src, S dst)
    {
        dst.VariableName = src.VariableName;
        dst.Label = src.Label;
        dst.Description = src.Description;
        dst.Components = src.Components.ToList();        
        dst.IsRoot = src.IsRoot;
        return dst;
    }

    public S Join(S other)
    {
        var result = Copy((S)this, new S());
        result.Components = stream(Components, stream(other)).ToReadOnlyList();
        return result;
    }
         
    public abstract Option<V> ResolveValue();

    /// <summary>
    /// Defines iteration construct invokes an action for every integer
    /// contained in the half-open interval [lower, upper) and returns
    /// the unit value
    /// </summary>
    /// <param name="lower">The lower bound</param>
    /// <param name="upper">The upper bound</param>
    /// <param name="action">The action to invoke</param>
    static Unit iter(int lower, int upper, Action<int> action)
    {
        for (int i = lower; i < upper; i++)
            action(i);

        return Unit.Value;
    }

    public bool Equals(S other)
    {

        if (isNull(other))
            return false;

        var l = (S)this;
        var r = other;

        if (l.Components.Count != r.Components.Count)
            return false;

        var equal = true;
        iter(0, l.Components.Count - 1,
            i => equal &= CompareAttributes(l.Components[i], r.Components[i]));
        return equal;
    }

    public override bool Equals(object obj)
        => Equals(obj as S);

    public override int GetHashCode()
        => ToString().GetHashCode();

    public override string ToString()
        => Format();

}

