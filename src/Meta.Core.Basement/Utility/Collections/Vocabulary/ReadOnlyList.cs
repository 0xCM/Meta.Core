//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using G = System.Collections.Generic;


public static class ReadOnlyList
{
    public static ReadOnlyList<T> Create<T>(params IEnumerable<T>[] sequences)
    {
        var list = new G.List<T>();
        sequences.Where(s => s != null).Iterate(s => list.AddRange(s));
        return new ReadOnlyList<T>(list);
    }

    public static ReadOnlyList<T> Create<T>(List<T> items)
        => new ReadOnlyList<T>(items ?? new G.List<T>());


    public static ReadOnlyList<T> Create<T>(IReadOnlyList<T> items)
        => new ReadOnlyList<T>(items ?? new T[] { });

    public static ReadOnlyList<T> Create<T>(T[] items)
        => new ReadOnlyList<T>(items ?? new T[] { });

    public static ReadOnlyList<T> Create<T>(IEnumerable<T> items, string delimiter)
        => new ReadOnlyList<T>(items, delimiter);
}

public class ReadOnlyList<T> : IReadOnlyList<T>
{

    public static readonly ReadOnlyList<T> Empty 
        = new ReadOnlyList<T>(new T[] { });

    public static implicit operator ReadOnlyList<T>(T[] items)
        => new ReadOnlyList<T>(items);

    public static implicit operator ReadOnlyList<T>(List<T> list)
        => new ReadOnlyList<T>(list);

    IReadOnlyList<T> Items { get; }

    string Delimiter { get; }
        = ";";

    int ElisionLimit { get; }
        = 10;

    public ReadOnlyList(List<T> items)
        => this.Items = items ?? Empty.Items;

    public ReadOnlyList(IReadOnlyList<T> items)
        => Items = items ?? Empty;

    public ReadOnlyList(T[] items)
        => Items = items ?? Empty.Items;

    public ReadOnlyList(IEnumerable<T> items)
        => this.Items = new G.List<T>(items);

    public ReadOnlyList(IEnumerable<T> items, string delimiter, int? elisionLimit = null)
    {
        this.Items = new G.List<T>(items);
        this.Delimiter = delimiter;
        this.ElisionLimit = elisionLimit ?? 10;
    }

    public T this[int index] 
        => Items[index];

    public int Count 
        => Items.Count;

    public IEnumerator<T> GetEnumerator() 
        => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => Items.GetEnumerator();

    public override string ToString()
        => string.Join(Delimiter 
                + " ", Items.Take(ElisionLimit)) 
                + (Items.Count > ElisionLimit ? "..." : String.Empty);

    public override int GetHashCode()
        => this.GetHashCodeAggregate();

    public override bool Equals(object obj)
    {
        switch(obj)
        {
            case ReadOnlyList<T> other:
                if (this.Count != other.Count)
                    return false;

                for(var i=0; i< other.Count; i++)
                {
                    var left = this[i];
                    var right = other[i];
                    var same = Equals(left, right);
                    if (!same)
                        return false;                    
                }
                return true;                

            default:
                return false;
        }
    }
}
