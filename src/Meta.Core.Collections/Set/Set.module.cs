//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;
    using G = System.Collections.Generic;

    public class Set
    {
        /// <summary>
        /// Constructs a set from sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input sequence</param>
        /// <returns></returns>
        public static Set<X> make<X>(Seq<X> items)
            => Set<X>.Factory(items);

        /// <summary>
        /// Constructs a set from a stream
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input enumerable</param>
        /// <returns></returns>
        public static Set<X> make<X>(G.IEnumerable<X> items)
            => make(Seq.make(items));


        /// <summary>
        /// Constructs a sequence from a set
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="set">The set to devolve</param>
        /// <returns></returns>
        public static Seq<X> unwrap<X>(Set<X> set)
            => set.AsSeq();

        /// <summary>
        /// Returns the canonical 0 value for the set over elements of type <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The index element type</typeparam>
        /// <returns></returns>
        public static Set<X> zero<X>()
            => Set<X>.Empty;


        /// <summary>
        /// Creates a new sequence [f(x1), ...] from an input sequence [x1,...]
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f">The function to apply</param>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Set<Y> map<X, Y>(Func<X, Y> f, Set<X> s)
            => make(Seq.map(f, s.AsSeq()));

        /// <summary>
        /// Transformas a map f:X->Y to a map F:Set[X]->Set[Y]
        /// </summary>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        /// <param name="f">The transformer</param>
        /// <returns></returns>
        public static Func<Set<X>, Set<Y>> fmap<X, Y>(Func<X, Y> f)
             => s => map(f, s);
    }
}