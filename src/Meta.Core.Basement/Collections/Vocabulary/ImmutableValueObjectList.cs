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
/// Defines factory methods for constructing value object lists
/// </summary>
public static class ImmutableValueObjectList
{
    public static ImmutableValueObjectList<T> Create<T>(IEnumerable<T> items)
        where T : IValueObject => new ImmutableValueObjectList<T>(items);

    public static ImmutableValueObjectList<T> Create<T>(params T[] items)
        where T : IValueObject => new ImmutableValueObjectList<T>(items);
}

/// <summary>
/// Immutable list that contains value objects (which are themselves immutable)
/// </summary>
/// <typeparam name="T">The type of value object the list will contain</typeparam>
public class ImmutableValueObjectList<T> : ImmutableValueList<T>
    where T : IValueObject
{
    public static readonly ImmutableValueObjectList<T> Empty 
        = new ImmutableValueObjectList<T>(new T[] { });

    public static implicit operator ImmutableValueObjectList<T>(T[] items) 
        => new ImmutableValueObjectList<T>(items);

    public ImmutableValueObjectList(IEnumerable<T> items)
        : base(items)
    {
            
    }

    public ImmutableValueObjectList(IEnumerable<IValueObject<T>> items)
        : base(items.Cast<T>())
    { }
}



