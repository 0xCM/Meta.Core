//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using G = System.Collections.Generic;

using Meta.Core;

/// <summary>
/// Contains a list of immutable values
/// </summary>
/// <typeparam name="T">The type of value contained by the list</typeparam>
public class ImmutableValueList<T> :  ICollection<T>, IReadOnlyList<T>
{
    readonly G.List<T> items;

    //public static implicit operator ImmutableValueList<T>(G.List<T> items)
    //    => new ImmutableValueList<T>(items);

    T IReadOnlyList<T>.this[int index] 
        => items[index];

    int IReadOnlyCollection<T>.Count 
        => items.Count;

    IEnumerator IEnumerable.GetEnumerator() 
        => items.GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() 
        => items.GetEnumerator();

    public ImmutableValueList(IEnumerable<T> items)
    {
        this.items = items.ToList();
    }

    public override bool Equals(object obj)
    {
        var other = (obj as ImmutableValueList<T>)?.items;
        if (other == null)
            return false;
       
        return items.DeepEqualityWith(other);
    }

    public int Count 
        => items.Count;

    bool ICollection<T>.IsReadOnly
        => true;

    public override int GetHashCode() 
        => items.GetHashCodeAggregate();

    static string describe<X>(IEnumerable<X> items)
    {
        var subset = items.Take(3).ToList();
        var text = String.Join(";", subset);
        return items.Count() > 3 ? text + "..." : text;
    }

    public override string ToString() 
        => describe(this);

    void ICollection<T>.Add(T item)
    {
        items.Add(item);
    }

    void ICollection<T>.Clear()
    {
        items.Clear();
    }

    bool ICollection<T>.Contains(T item)
        => items.Contains(item);

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        => items.CopyTo(array, arrayIndex);

    bool ICollection<T>.Remove(T item)
        => items.Remove(item);
}


