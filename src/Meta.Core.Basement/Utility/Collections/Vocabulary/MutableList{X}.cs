//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using G = System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Grafts a facade over a <see cref="System.Collections.Generic.List{T}"/> so that
    /// mutable lists can be used without using the type name "List" which is
    /// used for the immutable list type
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    public class MutableList<X> : IMutableList<X>
    {

        G.List<X> Data { get; }
            = new G.List<X>();

        //public static implicit operator MutableList<X>(G.List<X> list)
        //    => list;

        MutableList()
        {

        }

        public MutableList(int Capacity)
            => Data = new G.List<X>(Capacity);

        public MutableList(G.IEnumerable<X> items)
            => this.Data = new G.List<X>(items);

        public MutableList(G.List<X> list)
            => this.Data = list;

        public X this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public int Count
            => Data.Count;

        public bool IsReadOnly { get; }

        public void Add(X item)
            => Data.Add(item);

        public void Clear()
            => Data.Clear();

        public bool Contains(X item)
            => Data.Contains(item);

        public void CopyTo(X[] array, int arrayIndex)
            => Data.CopyTo(array, arrayIndex);

        public G.IEnumerator<X> GetEnumerator()
            => Data.GetEnumerator();

        public int IndexOf(X item)
            => IndexOf(item);

        public void Insert(int index, X item)
            => Data.Insert(index, item);

        public bool Remove(X item)
            => Data.Remove(item);

        public void RemoveAt(int index)
            => Data.RemoveAt(index);

        public void InsertRange(int index, G.IEnumerable<X> items)
            => Data.InsertRange(index, items);

        public void AddRange(G.IEnumerable<X> items)
            => Data.AddRange(items);

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();

        /// <summary>
        /// Converts the list to an array
        /// </summary>
        /// <returns></returns>
        public X[] ToArray()
            => Data.ToArray();
    }
}