//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

/// <summary>
/// Base type for a domain primitive, an atomic value upon which domain-specific semantics is conferred
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
/// <typeparam name="V">The primitive value type</typeparam>
public abstract class DomainPrimitive<T, V> : ValueObject<T>, ISemanticValue<V>
    where T : DomainPrimitive<T, V>
{
    public static implicit operator V(DomainPrimitive<T, V> x)
        => x != null ? x.Value : default(V);

    protected DomainPrimitive(V Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Exists for serialization purposes
    /// </summary>
    protected DomainPrimitive()
    {

    }


    /// <summary>
    /// The value of the primitive
    /// </summary>
    public V Value { get; }


    object ISemanticValue.Value
        => Value;

    public override string ToString()
        => Value.ToString();
}
