//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static minicore;

public static class SemanticInteger
{
    public static Option<T> TryParse<T>(string text) where T : SemanticInteger<T>, new()
    {
        int x = 0;
        if (Int32.TryParse(text, out x))
        {
            var i = new T();
            i.Value = x;
            return i;
        }
        else
            return none<T>();
    }
}


/// <summary>
/// Encapsulates an integer value that has an associated domain-specific meaning
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks>This would be much better implemented via structs but that would require a lot of duplication</remarks>
public abstract class SemanticInteger<T> : SemanticValue<T, int>, IEquatable<T>, IComparable<T>
    where T : SemanticInteger<T>, new()
{
    public static implicit operator int(SemanticInteger<T> x)
        => x.Value;

    public static T operator +(SemanticInteger<T> x, SemanticInteger<T> y)
    {
        var z = new T();
        z.Value = x.Value + y.Value;
        return z;
    }

    public static T operator -(SemanticInteger<T> x, SemanticInteger<T> y)
    {
        var z = new T();
        z.Value = x.Value - y.Value;
        return z;
    }

    protected SemanticInteger()
    {

    }

    protected SemanticInteger(int Value)
        : base(Value)
    {

    }

    public override bool Equals(T other)
        => this.Value == other.Value;

    public int CompareTo(T other)
        => Value.CompareTo(other.Value);

}
