//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;


public abstract class SemanticValue
{
    internal abstract void AssignValue(object value);
}

/// <summary>
/// Encapsulates a primitive of some sort that, when realized, confers upon the constructed type a domain-specific meaning
/// </summary>
/// <remarks>This would be much better implemented via structs but that would require a lot of duplication</remarks>
public abstract class SemanticValue<I,V> : SemanticValue,  IEquatable<I>, ISemanticValue<V>
    where I : SemanticValue<I,V>
{
    public static implicit operator V(SemanticValue<I, V> x)
        => x is null ? default : x.Value;

    public static bool operator == (SemanticValue<I, V> x, SemanticValue<I, V> y)
        => Object.Equals(x is null ? default : x.Value , y is null ? default : y.Value);

    public static bool operator != (SemanticValue<I, V> x, SemanticValue<I, V> y)
        => !(x == y);

    public V Value { get; internal set; }


    object ISemanticValue.Value
        => Value;

    protected SemanticValue()
    {

    }

    internal override void AssignValue(object value)
    {
        this.Value = (V)value;
    }

    public SemanticValue(V Value)
    {
        this.Value = Value;
    }

    public abstract bool Equals(I other);        

    public override bool Equals(object other)
        => other is I ? this.Equals((I)other) : false;

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

}

