//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;
    using System.Collections.Immutable;


    public class Index
    {
        /// <summary>
        /// Constructs an index from a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input sequence</param>
        /// <returns></returns>
        public static Index<X> make<X>(Seq<X> items)
            => Index<X>.Factory(items);               

        /// <summary>
        /// Constructs a sequence from an index
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="index">The index to devolve</param>
        /// <returns></returns>
        public static Seq<X> devolve<X>(Index<X> index)
            => index.Contained();

        /// <summary>
        /// Returns the canonical 0 value for <see cref="Index{X}"/>
        /// </summary>
        /// <typeparam name="X">The index element type</typeparam>
        /// <returns></returns>
        public static Index<X> zero<X>()
            => Index<X>.Empty;

        /// <summary>
        /// Constructs an index from a native array
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input array</param>
        /// <returns></returns>
        public static Index<X> cons<X>(params X[] items)
            => Index<X>.FromArray(items);

        /// <summary>
        /// Constructs a new Index by appending head to tail
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static Index<X> cons<X>(X head, Index<X> tail)
            => make(Seq.cons(head, tail));

        /// <summary>
        /// Constructs concatenated index from an arbitrary number of source indexes
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="indexes">The indexes to concatenate</param>
        /// <returns></returns>
        public static Index<X> chain<X>(params Index<X>[] indexes)
            => Seq.make(indexes.SelectMany(x => x.Stream()));

        /// <summary>
        /// Appends the second index to the first
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="ix1">The first index</param>
        /// <param name="ix2">The second index</param>
        /// <returns></returns>
        public static Index<X> concat<X>(Index<X> ix1, Index<X> ix2)
            => chain(ix1, ix2);


        /// <summary>
        /// Effects the cananical mapping over an index by a function
        /// </summary>
        /// <typeparam name="X">The source item type</typeparam>
        /// <typeparam name="Y">The target item type</typeparam>
        /// <param name="f">The mapping function</param>
        /// <param name="index">The indexed data</param>
        /// <returns></returns>
        public static Index<Y> map<X, Y>(Func<X, Y> f, Index<X> index)
            => Seq.make(index.Stream().Select(f));


        /// <summary>
        /// Transforms a function f:X->Y to a function F:Index[X]->Index[Y]
        /// </summary>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to transform</param>
        /// <returns></returns>
        public static Func<Index<X>, Index<Y>> fmap<X, Y>(Func<X, Y> f)
            => lx => map(f, lx);


        /// <summary>
        /// Creates an immutable array builder
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="capacity">Optional initial capacity</param>
        /// <returns></returns>
        static ImmutableArray<X>.Builder builder<X>(int? capacity = null)
            => capacity.Map(c => ImmutableArray.CreateBuilder<X>(c), 
                    () => ImmutableArray.CreateBuilder<X>());

        /// <summary>
        /// Effects a mapping over indexed values
        /// </summary>
        /// <typeparam name="X">The source item type</typeparam>
        /// <typeparam name="Y">The target item type</typeparam>
        /// <param name="f">The mapping function</param>
        /// <param name="index">The indexed data</param>
        /// <returns></returns>
        public static Index<Y> mapi<X, Y>(Func<(int,X), Y> f, Index<X> index)
            => Seq.make(index.TupleStream().Select(pair => f(pair)));

    }
}