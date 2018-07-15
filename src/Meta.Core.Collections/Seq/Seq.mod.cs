//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using static minicore;

    /// <summary>
    /// Implementation module for <see cref="Seq{X}"/>
    /// </summary>

    public class Seq   : DataModule<Seq,ISeq>
    {
        public Seq()
            : base(typeof(Seq<>))
        { }

        /// <summary>
        /// Gets the primary Seq constructor
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <returns></returns>
        public static SeqFactory<X> ctor<X>()
            => Seq<X>.Factory;

        /// <summary>
        /// Returns the canonical 0 value for a sequence of elements of type <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The index element type</typeparam>
        /// <returns></returns>
        public static Seq<X> zero<X>()
            => Seq<X>.Empty;

        /// <summary>
        /// Constructs a sequence over an enumerable
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input enumerable</param>
        /// <returns></returns>
        public static Seq<X> make<X>(IEnumerable<X> items)
            => new Seq<X>(items);

        /// <summary>
        /// Constructs a sequence over an enumerable whose cardinality is known
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">The input enumerable</param>
        /// <param name="cardinality">The stream cardinality</param>
        /// <returns></returns>
        public static Seq<X> make<X>(IEnumerable<X> items, Cardinality cardinality)
            => new Seq<X>(items, cardinality);

        /// <summary>
        /// Constructs a sequence from an item array
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="items">Zero or more items</param>
        /// <returns></returns>
        public static Seq<X> items<X>(params X[] items)
            => new Seq<X>(items);

        /// <summary>
        /// Returns an enumerable from a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IEnumerable<X> unwrap<X>(Seq<X> s)
            => s.Stream();

        /// <summary>
        /// Creates a union from an array of sequences, effectively deduplicating 
        /// the chain formed by successive concatenation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="sequences">The source sequences</param>
        /// <returns></returns>
        public static Seq<X> union<X>(params Seq<X>[] sequences)
            => Set.make(chain(sequences));

        /// <summary>
        /// Constructs a new stream by successive concatenation
        /// </summary>
        /// <typeparam name="X">The list element type</typeparam>
        /// <param name="sequences"></param>
        /// <returns></returns>
        public static Seq<X> chain<X>(params Seq<X>[] sequences)
            => make(sequences.SelectMany(x => x.Stream()));

        /// <summary>
        /// Constructs a new sequence by appending head to tail
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static Seq<X> cons<X>(X head, params X[] tail)
            => make(_cons(head, tail));

        /// <summary>
        /// Concatenates two lists
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static Seq<X> concat<X>(Seq<X> s1, Seq<X> s2)
            => s1 + s2;

        /// <summary>
        /// Constructs a new sequence by appending head to tail
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static Seq<X> cons<X>(X head, Seq<X> tail)
            => concat(cons(head), tail);

        /// <summary>
        /// Constructs a sequence from a single element
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <param name="x">The singleton value</param>
        /// <returns></returns>
        public static Seq<X> singleton<X>(X x)
            => cons(x);

        /// <summary>
        /// Creates a new sequence [f(x1), ...] from an input sequence [x1,...]
        /// </summary>
        /// <typeparam name="X">The source item type</typeparam>
        /// <typeparam name="Y">The target item type</typeparam>
        /// <param name="f">The function to apply</param>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<Y> map<X, Y>(Func<X, Y> f, Seq<X> s)
            => make(s.Stream().Select(f));

        /// <summary>
        /// Transforms a function f:X->Y to a function F:Seq[X]->Seq[Y]
        /// </summary>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to transform</param>
        /// <returns></returns>
        public static Func<Seq<X>, Seq<Y>> fmap<X, Y>(Func<X, Y> f)
            => x => map(f, x);

        /// <summary>
        /// The canonical bind operation for lists
        /// </summary>
        /// <typeparam name="X">The input list element type and function domain</typeparam>
        /// <typeparam name="Y">The output list elemetn type and function codomain</typeparam>
        /// <param name="s">The input sequence</param>
        /// <param name="f">The function to bind</param>
        /// <returns></returns>
        public static Seq<Y> bind<X, Y>(Seq<X> s, Func<X, Seq<Y>> f)
            => flatten(map(f, s));

        /// <summary>
        /// Applies a list of function to a list of values
        /// </summary>
        /// <typeparam name="X">The input list element type</typeparam>
        /// <typeparam name="Y">The output list element type</typeparam>
        /// <returns></returns>
        public static Seq<Y> apply<X, Y>(Seq<Func<X, Y>> lf, Seq<X> lx)
            => from f in lf
               from x in lx
               select f(x);

        /// <summary>
        /// Creates a new sequence by injecting a specified value between each pair of values in 
        /// an input sequence
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="x">The value to interject</param>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<X> intersperse<X>(X x, Seq<X> s)
            => make(_intersperse(x, s));

        /// <summary>
        /// Transforms the input sequence into a more generalized sequence;
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Seq<Y> weaken<X, Y>(Seq<X> s)
            where Y : class
            where X : Y
                => from Y x in s select x;

        /// <summary>
        /// Evaluates the sequence
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="s">The sequence to evaluate</param>
        /// <returns></returns>
        public static ReadOnlyList<X> values<X>(Seq<X> s)
            => s.Stream().ToReadOnlyList();


        /// <summary>
        /// Produces the empty sequence
        /// </summary>
        /// <typeparam name="X">The sequence item type</typeparam>
        /// <returns></returns>
        public static Seq<X> empty<X>()
            => Seq<X>.Empty;

        /// <summary>
        /// Returns the last value of a sequence, if possible
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The sequence</param>
        /// <returns></returns>
        public static Option<X> head<X>(Seq<X> s)
            => s.Stream().FirstOrDefault();

        /// <summary>
        /// Returns the last elment of the sequence, if possible
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Option<X> last<X>(Seq<X> s)
            => s.Stream().LastOrDefault();

        /// <summary>
        /// Creates a new sequence [x2, ..., xn, ...] from an input sequence [x1, ..., xn, ...]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<X> tail<X>(Seq<X> s)
            => make(s.Stream().Skip(1));


        /// <summary>
        /// Creates a new sequence [xn, ..., x(n-1), x1] from a finite input sequence [x1,...xn]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The sequence to reverse</param>
        /// <returns></returns>
        public static Seq<X> reverse<X>(Seq<X> s)
            => not(s.IsUnbounded) ? make(s.Stream().Reverse()) : s;

        /// <summary>
        /// Creates a new sequence from the first <paramref name="n"/> elements of the sequence
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="n">The number of items to take</param>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<X> take<X>(int n, Seq<X> s)
            => make(s.Stream().Take(n));

        /// <summary>
        /// Constructs the sequence [x(k+1), x(k+2), ..., xn] from an existing sequence [x1, ..., xk]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="n">The number of elements to skip</param>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<X> skip<X>(int n, Seq<X> s)
            => make(s.Stream().Skip(n));

        /// <summary>
        /// Aggregates the values in a list using a supplied combinator
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="combiner">A transformation (x1,x2) -> x3</param>
        /// <param name="s">The list whose elements will be combined</param>
        /// <returns></returns>
        public static Option<X> combine<X>(Combiner<X> combiner, Seq<X> s)
            => s.IsEmpty ? none<X>() 
                : s.Stream().Aggregate((x, y) => combiner(x, y));

        /// <summary>
        /// Returns the aggregate or the supplied default value depending on whether the sequence is emtpy
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="combiner"></param>
        /// <param name="s"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static X combine<X>(Combiner<X> combiner, Seq<X> s, X @default)
            => s.IsEmpty ? @default : s.Stream().Aggregate((x, y) => combiner(x, y));        

        /// <summary>
        /// Creates a sequence containing <paramref name="n"/> copies of the value <paramref name="x"/> 
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="n">The number of elements in the resulting sequence</param>
        /// <param name="x">The value to replicate</param>
        /// <returns></returns>
        public static Seq<X> replicate<X>(int n, X x)
            => make(from i in Enumerable.Range(0, n) select x);

        /// <summary>
        /// Returns true if a sequence is satisfied for all elements in a list; false otherwise
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate to evaluate</param>
        /// <param name="s">The sequence over which to evaluate the predicate</param>
        /// <returns></returns>
        public static bool all<X>(Func<X, bool> p, Seq<X> s)
            => s.Stream().All(p);

        /// <summary>
        /// Returns true if a specified element exists in a sequence, false otherwise
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="match">The value to search for</param>
        /// <param name="s">The sequence to search</param>
        /// <returns></returns>
        public static bool contains<X>(X match, Seq<X> s)
            => any(item => Equals(match, match), s);

        /// <summary>
        /// Returns true if a predicate is satisfied for any element in a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate</param>
        /// <param name="s">The sequence over which to evaluate the predicate</param>
        /// <returns></returns>
        public static bool any<X>(Func<X, bool> p, Seq<X> s)
            => s.Stream().Any(p);

        /// <summary>
        /// Filters an input list by an adjudicating predicate
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <param name="p">The predicate</param>
        /// <param name="s">The sequence to filter</param>
        /// <returns>The elements of the input sequence that satisfy the predicate</returns>
        public static Seq<X> filter<X>(Func<X, bool> p, Seq<X> s)
            => make(s.Stream().Where(p));

        /// <summary>
        /// Joins two sequences to produce a sequence of 2-tuples
        /// </summary>
        /// <typeparam name="X1">The item type of the first sequence</typeparam>
        /// <typeparam name="X2">The item type of the second sequence</typeparam>
        /// <param name="s1">The first input sequence</param>
        /// <param name="s2">The second input sequence</param>
        /// <returns></returns>
        public static Seq<(X1 x1, X2 x2)> zip<X1, X2>(Seq<X1> s1, Seq<X2> s2)
            => make(s1.Stream().Zip(s2.Stream(), (a, b) => (a, b)));



        /// <summary>
        /// Transforms a sequence of ordered pairs into an ordered pair of sequences
        /// </summary>
        /// <typeparam name="X">The left sequence element type</typeparam>
        /// <typeparam name="Y">The right sequence element type</typeparam>
        /// <param name="items">The sequence to transform</param>
        /// <returns></returns>
        public static (Seq<X> x, Seq<Y> y) unzip<X, Y>(Seq<(X x, Y y)> items)
            => (items.Select(z => z.x), items.Select(z => z.y));

        /// <summary>
        /// Concatenates a sequence of sequences into a single sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="sequences">The lists to concatenate</param>
        /// <returns></returns>
        public static Seq<X> flatten<X>(Seq<Seq<X>> sequences)
            => sequences.SelectMany(x => x);
             
        /// <summary>
        /// flatten + map = flatmap
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f"></param>
        /// <param name="sequences"></param>
        /// <returns></returns>
        public static Seq<Y> flatmap<X, Y>(Func<X, Y> f, Seq<Seq<X>> sequences)
            => map(f, flatten(sequences));

        /// <summary>
        /// Computes the left fold of the sequence
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static X foldl<X>(Func<X, X, X> f, Seq<X> s, X @default = default)
            => tail(s).Stream().Aggregate(head(s).ValueOrDefault(@default), f);
                                    
        /// <summary>
        /// The canonical left-fold operation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="Y">The accumulation type</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The initial value</param>
        /// <param name="s">The sequence to which the fold will be applied</param>
        /// <returns></returns>
        public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, Seq<X> s)
        {
            var items = values(s);
            var y = y0;
            for (var i = 0; i < items.Count; i++)
                y = f(y, items[i]);
            return y;
        }

        /// <summary>
        /// The canonical right-fold operation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="Y">The accumulation type</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The initial value</param>
        /// <param name="s">The seqence to which the fold will be applied</param>
        /// <returns></returns>
        public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, Seq<X> s)
        {
            var items = values(s);
            var y = y0;
            for (var i = items.Count - 1; i >= 0; i--)
                y = f(items[i], y);
            return y;
        }

        /// <summary>
        /// Produces a new sequence from an existing sequence via a traversal operator
        /// </summary>
        /// <typeparam name="X">The input list item type</typeparam>
        /// <typeparam name="Y">The output list item type</typeparam>
        /// <param name="f">The traverser effector</param>
        /// <param name="s">The sequence to traverse</param>
        /// <returns></returns>
        public static Seq<Y> traverse<X, Y>(Func<X, Seq<Y>> f, Seq<X> s)
            => make(from x in s.Stream()
                           from y in f(x).Stream()
                           select y);

        /// <summary>
        /// Produces a new sequence by eliminating any duplicates in an existing sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The source sequence</param>
        /// <returns></returns>
        public static Seq<X> distinct<X>(Seq<X> s)
            => make(s.Stream().Distinct());

        /// <summary>
        /// Renders the canonical display format for a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The sequence</param>
        /// <returns></returns>
        public static string format<X>(Seq<X> s)
            => SeqFormatter<X>.instance.Format(s);


        /// <summary>
        /// Determines whether two seqeunces are equal
        /// </summary>
        /// <typeparam name="X">The item tpe</typeparam>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool eq<X>(Seq<X> s1, Seq<X> s2)
            => SeqEquator<X>.instance(s1, s2);

        /// <summary>
        /// Evaulates the logical negation of <see cref="eq"/>
        /// </summary>
        /// <typeparam name="X">The item tpe</typeparam>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool neq<X>(Seq<X> s1, Seq<X> s2) 
            => not(eq(s1, s2));

        static IEnumerable<X> _cons<X>(X head, params X[] tail)
        {
            yield return head;
            foreach (var x in tail)
                yield return x;
        }

        static IEnumerable<X> _intersperse<X>(X x, Seq<X> s)
        {
            var input = s.Stream();
            var first = input.FirstOrDefault();

            if (first != null)
            {
                yield return first;

                foreach (var item in input.Skip(1))
                {
                    yield return x;
                    yield return item;
                }
            }
        }

        public static Seq<S> mapi<T, S>(Seq<T> s, Func<int, T, S> f)
        {
            var idx = 0;
            return from item in s select f(idx++, item);
        }

        /// <summary>
        /// Constructs a <see cref="IStreamable"/> over <paramref name="s"/>
        /// </summary>
        /// <typeparam name="X">The sequence item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Streamable<X> Streamable<X>(Seq<X> s)
            => Modules.Streamable.make(() => s.Stream(), s.Cardinality);       
    }
}