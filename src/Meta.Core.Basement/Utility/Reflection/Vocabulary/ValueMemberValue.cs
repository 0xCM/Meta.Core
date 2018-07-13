//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Encapsulates an instance value of a <see cref="ValueMember"/> 
/// </summary>
public class ValueMemberValue : IEquatable<ValueMemberValue>
{
    public static bool operator ==(ValueMemberValue x, ValueMemberValue y)
        => Object.Equals(x, y);

    public static bool operator !=(ValueMemberValue x, ValueMemberValue y)
        => !(x == y);

    public ValueMemberValue(Type ValueType, string MemberName, object Value)
    {
        this.ValueType = ValueType;
        this.MemberName = MemberName;
        this.Value = Value;
    }

    /// <summary>
    /// The encapsulated value type
    /// </summary>
    public Type ValueType { get; }

    /// <summary>
    /// The name of the member for which a value has been captured
    /// </summary>
    public string MemberName { get; }

    /// <summary>
    /// The encapsulated value
    /// </summary>
    public object Value { get; }

    public override bool Equals(object other)
        => other is ValueMemberValue 
            ? this.Equals((ValueMemberValue)other) : false;

    public bool Equals(ValueMemberValue other)
        =>    (MemberName.Equals(other.MemberName)  
           && (ValueType?.Equals(other.ValueType) ?? false))  
            ? Object.Equals(this.Value, other.Value) 
            : false;

    public override int GetHashCode()
    => Value.GetHashCode();

    public override string ToString()
        => $"{MemberName}: {Value?.ToString() ?? "null"}";
   
}

