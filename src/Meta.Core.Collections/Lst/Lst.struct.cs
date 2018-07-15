//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Immutable;
    using System.Collections.Generic;
    using System.Collections;

    using Modules;

    using static Union;

    using static minicore;

    


    public readonly struct Lst<X> : ILst<X>
    {        
        /// <summary>
        /// The canonical 0
        /// </summary>
        public static readonly Lst<X> Empty
            = new Lst<X>(ImmutableList<X>.Empty);

        /// <summary>
        /// Converts a list to a sequence
        /// </summary>
        /// <param name="list">The list to convert</param>
        public static implicit operator Seq<X>(Lst<X> list)
            => list.Contained();

        /// <summary>
        /// Converts a list to a readonly list
        /// </summary>
        /// <param name="list">The list to convert</param>
        public static implicit operator ReadOnlyList<X>(Lst<X> list)
            => new ReadOnlyList<X>(list.Stream());

        /// <summary>
        /// Converts a sequence to a list
        /// </summary>
        /// <param name="s">The sequence to convert</param>
        public static implicit operator Lst<X>(Seq<X> s)
            => Factory(s.Stream());

        /// <summary>
        /// Converts an array to a list
        /// </summary>
        /// <param name="items">The array to convert</param>
        public static implicit operator Lst<X>(X[] items)
            => Factory(items);

        /// <summary>
        /// Converts a mutuable list to a Lst
        /// </summary>
        /// <param name="mlist">The input list</param>
        public static implicit operator Lst<X>(MutableList<X> mlist)
            => new Lst<X>(mlist.ToImmutableList());

        /// <summary>
        /// Converts a readonly list to a Lst
        /// </summary>
        /// <param name="list">The input list</param>
        public static implicit operator Lst<X>(ReadOnlyList<X> list)
            => new Lst<X>(list.ToImmutableList());

        /// <summary>
        /// Converts a list to an array
        /// </summary>
        /// <param name="list">The list to convert</param>
        public static implicit operator X[](Lst<X> list)
            => list.Data.value.ToArray();

        /// <summary>
        /// Concatenates two lists
        /// </summary>
        /// <param name="l1">The first list</param>
        /// <param name="l2">The second list</param>
        /// <returns></returns>
        public static Lst<X> operator +(Lst<X> l1, Lst<X> l2)
            => Factory(l1.Stream().Concat(l2.Stream()));

        /// <summary>
        /// Constructs a list from the components of a homogenous 2-tuple
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator Lst<X>((X x1, X x2) x)
            => Factory((new X[] {x.x1, x.x2}));

        /// <summary>
        /// Constructs a list from the components of a homogenous 3-tuple
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator Lst<X>((X x1, X x2, X x3) x)
            => Factory((new X[] { x.x1, x.x2, x.x3 }));

        /// <summary>
        /// Constructs a list from the components of a homogenous 4-tuple
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator Lst<X>((X x1, X x2, X x3, X x4) x)
            => Factory((new X[] { x.x1, x.x2, x.x3, x.x4 }));

        /// <summary>
        /// Constructs a list from the components of a homogenous 5-tuple
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator Lst<X>((X x1, X x2, X x3, X x4, X x5) x)
            => Factory((new X[] { x.x1, x.x2, x.x3, x.x4 }));


        /// <summary>
        /// Determines whether two lists are structurally equal
        /// </summary>
        /// <param name="l1">The first list</param>
        /// <param name="l2">The second list</param>
        /// <returns></returns>
        public static bool operator ==(Lst<X> l1, Lst<X> l2)
            => l1.Equals(l2);

        /// <summary>
        /// Determines whether two lists fail structural equqlity
        /// </summary>
        /// <param name="l1">The first list</param>
        /// <param name="l2">The second list</param>
        /// <returns></returns>
        public static bool operator !=(Lst<X> l1, Lst<X> l2)
            => not(l1.Equals(l2));


        /// <summary>
        /// Left-Multiplies each element in a list by a specified factor
        /// to produce a new list
        /// </summary>
        /// <param name="value">The factor</param>
        /// <param name="list">The list</param>
        /// <returns></returns>
        public static Lst<X> operator *(X value, Lst<X> list)
            => Lst.map(item => operators.mul(value, item), list);

        /// <summary>
        /// Right-Multiplies each element in a list by a specified factor
        /// to produce a new list
        /// </summary>
        /// <param name="value">The factor</param>
        /// <param name="list">The list</param>
        /// <returns></returns>
        public static Lst<X> operator *(Lst<X> list, X value)
            => Lst.map(item => operators.mul(item, value), list);

        public static LstFactory<X> Factory
            => items => new Lst<X>(items.ToImmutableList());


        internal Lst(ImmutableList<X> Value)
            => this.Data = Value;

        internal Lst(X[] Value)
            => this.Data = Value;


        CU<IReadOnlyList<X>, X[], ImmutableList<X>> Data { get; }

        //ImmutableList<X> Data { get; }

        public X this[int index]
            => Data.value[index];

        /// <summary>
        /// Retrieves the sublist determined by the supplied range, if possible. Otherwise,
        /// returns the empty list
        /// </summary>
        /// <param name="minIdx">The minimum 0-based index</param>
        /// <param name="maxIdx">The maximum 0-based index</param>
        /// <returns></returns>
        public Lst<X> this[int minIdx, int maxIdx]            
            => minIdx > maxIdx  ? Empty 
            : maxIdx >= Count ? Empty
            : Factory(Data.value.GetRange(minIdx, maxIdx - minIdx + 1));

        public int Count
            => Data.value.Count;

        public IEnumerable<X> Stream()
            => Data.value;

        public bool IsEmpty
            => this.Count == 0;

        /// <summary>
        /// Presents the contained data as a sequence
        /// </summary>
        /// <returns></returns>
        public Seq<X> Contained()
            => Seq.make(Data.value);

        public IReadOnlyList<X> AsReadOnlyList()
            => Data.value;

        public X[] AsArray()
            => Data.value.ToArray();

        public override int GetHashCode()
            => Container.hash(this);

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Lst<X> other:
                    return Lst.eq(this, other);
                default:
                    return false;
            }
        }

        public bool Equals(Lst<X> other)
            => LstEquator<X>.instance(this, other);

        public override string ToString()
            => LstFormatter<X>.instance.Format(this);

        public Cardinality Cardinality
            => IsEmpty ? Cardinality.Zero : Cardinality.Finite;

        IEnumerable<X> IStreamable<X>.Stream()
            => Data.value;

        ContainerFactory<X, Lst<X>> IContainer<X, Lst<X>>.Factory
            => stream => new Lst<X>(stream.ToImmutableList());

        ContainerFactory<X> IContainer<X>.GetFactory()
             => stream => new Lst<X>(stream.ToImmutableList());

        Lst<X> IContainer<X, Lst<X>>.Empty
            => Empty;

        IContainer<Y> IContainer<X>.GetEmpty<Y>()
            => Lst<Y>.Empty;

        IEnumerable IStreamable.Stream()
            => Stream();

        public Type ElementType
            => typeof(X);


        public Option<TypeConstruction> ConstructType(params Type[] args)
            => new TypeConstructor(typeof(Lst<>)).Construct(args);

        Array ILst.AsArray()
            => AsArray();

        ILst ILst.Fill(IEnumerable<object> items)
            => Factory(items.Cast<X>());
    }
}