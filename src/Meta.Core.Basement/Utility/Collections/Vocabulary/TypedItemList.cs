//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

using Meta.Core;


public abstract class TypedItemList<B, T> : ITypedItemList<B, T>
    where B : TypedItemList<B,T>, new()
{
    public static B Value 
        => new B();

    public static B operator + (TypedItemList<B,T> x, TypedItemList<B, T> y) 
        => Create(x.Concat(y));

    static IReadOnlyDictionary<string, T> DeclaredItemIndex { get; }

    static IReadOnlyList<T> DeclaredItems { get; }

    public static Option<T> TryFind(string FieldName)
        => DeclaredItemIndex.TryFind(FieldName);

    public static Option<T> TryFind(Func<T, bool> predicate)
        => DeclaredItems.Where(predicate).FirstOrDefault();

    public static B Create(IEnumerable<T> items, string Delimiter = null)
        => new B().Initialize(items, Delimiter);


    static TypedItemList()
    {
        DeclaredItems 
            = typeof(B).GetDeclaredImmutableFields(MemberInstanceType.Static)
                .Select(f => f.GetValue(null)).OfType<T>().ToReadOnlyList();

        DeclaredItemIndex 
            = (from f in typeof(B).GetDeclaredImmutableFields(MemberInstanceType.Static)
                    select (f.Name, (T)f.GetValue(null))).ToReadOnlyDictionary();
    }

    Type ITypedItemList.ItemType
        => typeof(T);

    Type ITypedItemList.ListType
        => typeof(B);

    protected virtual void Filled(){ }

    B Initialize(IEnumerable<T> items, string Delimiter)
    {
        this.Items = MutableList.FromItems(items);
        this.Delimiter = Delimiter ?? ",";
        Filled();
        return (B)this;
    }


    protected TypedItemList()
    {
        this.Items = DeclaredItems;
        this.Delimiter = ",";
    }

    protected TypedItemList(string Delimiter)
    {
        this.Items = DeclaredItems;
        this.Delimiter = Delimiter ?? ",";
    }

    protected TypedItemList(char Delimiter)
        : this(Delimiter.ToString())
    {


    }

    protected string Delimiter;

    public IReadOnlyList<T> Items { get; private set; }

    public T this[int index] 
        => Items[index];


    public int Count
        => Items.Count;

    public IEnumerator<T> GetEnumerator()
        => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public override string ToString()
        => string.Join(Delimiter, this.Items);

    public static bool Contains(T item)
       => DeclaredItems.Contains(item);

}
