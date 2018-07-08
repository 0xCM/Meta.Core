//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
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
        /// Constructs an index from a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input sequence</param>
        /// <returns></returns>
        public static Index<X> make<X>(IEnumerable<X> items)
            => Index<X>.Factory(Seq.make(items));

        /// <summary>
        /// Creates an index containing <paramref name="n"/> copies of <paramref name="value"/> 
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="n">The number of elements in the resulting index</param>
        /// <param name="value">The value to replicate</param>
        /// <returns></returns>
        public static Index<X> replicate<X>(int n, X value)
            => Seq.replicate(n, value);

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
        public static Index<X> items<X>(params X[] items)
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
        /// Effects a mapping over indexed values
        /// </summary>
        /// <typeparam name="X">The source item type</typeparam>
        /// <typeparam name="Y">The target item type</typeparam>
        /// <param name="f">The mapping function</param>
        /// <param name="index">The indexed data</param>
        /// <returns></returns>
        public static Index<Y> mapi<X, Y>(Func<(int,X), Y> f, Index<X> index)
            => Seq.make(index.TupleStream().Select(pair => f(pair)));

        /// <summary>
        /// Concatenates a sequence of sequences into a single sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="sequences">The lists to concatenate</param>
        /// <returns></returns>
        public static Index<X> flatten<X>(Index<Index<X>> sequences)
             => make(sequences.Stream().SelectMany(x => x.Stream()));

        /// <summary>
        /// The canonical bind operation for lists
        /// </summary>
        /// <typeparam name="X">The input list element type and function domain</typeparam>
        /// <typeparam name="Y">The output list elemetn type and function codomain</typeparam>
        /// <param name="list"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Index<Y> bind<X, Y>(Index<X> list, Func<X, Index<Y>> f)
            => flatten(map(f, list));

        /// <summary>
        /// Applies an index  of functions to an index of values
        /// </summary>
        /// <typeparam name="X">The input element type</typeparam>
        /// <typeparam name="Y">The output element type</typeparam>
        /// <returns></returns>
        public static Index<Y> apply<X, Y>(Index<Func<X, Y>> lf, Index<X> lx)
            => from f in lf
               from x in lx
               select f(x);
    }
}