//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Pairs a value with a name
/// </summary>
public readonly struct NamedValue<V>
{
    public static implicit operator NamedValue<V>((string Name, V Value) pair)
        => new NamedValue<V>(pair);

    public static implicit operator (string Name, V Value)(NamedValue<V> nv)
        => (nv.Name, nv.Value);


    public NamedValue((string Name, V Value) pair)
    {
        this.Name = pair.Name;
        this.Value = pair.Value;
    }

    public NamedValue(string Name, V Value)
    {
        this.Name = Name;
        this.Value = Value;
    }

    /// <summary>
    /// The value name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The value
    /// </summary>
    public V Value { get; }

    public override string ToString()
        => $"{Name}: {Value}";
}


/// <summary>
/// Pairs a value with a name
/// </summary>
public class NamedValue
{
    public static implicit operator NamedValue((string name, object value) x) 
        => new NamedValue(x.name, x.value);

    public NamedValue()
    {

    }

    public NamedValue(string Name, object Value)
    {
        this.Name = Name;
        this.Value = Value;
    }

    public string Name { get; set; }

    public object Value { get; set; }

    public override string ToString()
        => $"{Name}: {Value}";
}

/// <summary>
/// Defines a <see cref="NamedValue"/> list
/// </summary>
public sealed class NamedValues : ReadOnlyList<NamedValue>
{
    /// <summary>
    /// Implicitly constructs <see cref="NamedValues"/> list from a <see cref="NamedValue"/> array
    /// </summary>
    /// <param name="values"></param>
    public static implicit operator NamedValues(NamedValue[] values)
        => new NamedValues(values);


    /// <summary>
    /// Constructs an instance via an array
    /// </summary>
    /// <param name="values"></param>
    public NamedValues(NamedValue[] values)
        : base(values)
    {

    }

    /// <summary>
    /// Constructs an instance via a sequence
    /// </summary>
    /// <param name="values"></param>
    public NamedValues(IEnumerable<NamedValue> values)
        : base(values)
    {

    }

    /// <summary>
    /// Looks up a value by name
    /// </summary>
    /// <param name="Name">The value name</param>
    /// <returns></returns>
    public object this[string Name]
        => this.FirstOrDefault(x => x.Name == Name).Value;

    /// <summary>
    /// Looks up a value by relative index position
    /// </summary>
    /// <param name="idx">The index position</param>
    /// <returns></returns>
    public new object this[int idx]
        => base[idx].Value;
}

