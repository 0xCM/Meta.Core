//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using G = System.Collections.Generic;

    public abstract class MutableSet<B, T> : HashSet<T>, IMutableSet<T>
        where B : MutableSet<B, T>
    {

        public MutableSet()
        {

        }

        public MutableSet(G.ISet<T> set)
            : base(set)
        {


        }

        public MutableSet(MutableSet<T> set)
            : base(set)
        {


        }

        public MutableSet(IEqualityComparer<T> comparer)
            : base(comparer)
        { }

        public MutableSet(IEnumerable<T> collection)
            : base(collection)
        { }

        public MutableSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
            : base(collection, comparer)
        { }


    }

    public static class MutableSet
    {
        public static MutableSet<T> Empty<T>()
            => MutableSet<T>.Empty;

        public static MutableSet<T> Create<T>(IEnumerable<T> items)
            => new MutableSet<T>(items);

        public static MutableSet<T> Create<T>(IEnumerable<T> items, IEqualityComparer<T> comparer)
            => new MutableSet<T>(items, comparer);
    }

    public sealed class MutableSet<T> : HashSet<T>, IReadOnlySet<T>
    {
        public static readonly MutableSet<T> Empty = new MutableSet<T>();

        public MutableSet()
        {

        }

        public MutableSet(G.ISet<T> MutableSet)
            : base(MutableSet)
        {

        }

        public MutableSet(MutableSet<T> MutableSet)
            : base(MutableSet)
        {

        }

        public MutableSet(IEqualityComparer<T> comparer)
            : base(comparer)
        { }

        public MutableSet(IEnumerable<T> collection)
            : base(collection)
        { }

        public MutableSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
            : base(collection, comparer)
        { }

    }

}