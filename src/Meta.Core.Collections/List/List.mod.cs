//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    using static minicore;
    
    using System.Collections;
    using G = System.Collections.Generic;

    using Modules;


    /// <summary>
    /// Implelements Haskell-style list operations
    /// </summary>
    public class List 
    {
        public static ListFactory<X> ctor<X>()
            => List<X>.Factory;

        /// <summary>
        /// Constructs a list from an enumerable
        /// </summary>
        /// <typeparam name="X">The list element type</typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<X> make<X>(G.IEnumerable<X> items)
            => ctor<X>()(items);

        /// <summary>
        /// Constructs a list from a single element
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <param name="x">The singleton value</param>
        /// <returns></returns>
        public static List<X> singleton<X>(X x)
            => cons(x);

        /// <summary>
        /// Creates a new list [f(x1), ..., f(xn)] from an input list [x1,...,xn]
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f">The function to apply</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Y> map<X, Y>(Func<X, Y> f, List<X> list)
            => make(list.Stream().Select(f));

        /// <summary>
        /// The canonical bind operation for lists
        /// </summary>
        /// <typeparam name="X">The input list element type and function domain</typeparam>
        /// <typeparam name="Y">The output list elemetn type and function codomain</typeparam>
        /// <param name="list"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static List<Y> bind<X, Y>(List<X> list, Func<X, List<Y>> f)
            => flatten(map(f, list));

        /// <summary>
        /// Transforms a function f:X->Y to a function F:List[X]->List[Y]
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Func<List<X>, List<Y>> fmap<X, Y>(Func<X, Y> f)
            => lx => map(f, lx);

        /// <summary>
        /// Applies a list of function to a list of values
        /// </summary>
        /// <typeparam name="X">The input list element type</typeparam>
        /// <typeparam name="Y">The output list element type</typeparam>
        /// <returns></returns>
        public static List<Y> apply<X, Y>(List<Func<X, Y>> lf, List<X> lx)
            => from f in lf
               from x in lx
               select f(x);

        /// <summary>
        /// Constructs a new list by appending head to tail
        /// </summary>
        /// <typeparam name="X">The list element4 type</typeparam>
        /// <param name="head">The first element in the list</param>
        /// <param name="tail">The elements that follow the first element</param>
        /// <returns></returns>
        public static List<X> cons<X>(X head, params X[] tail)
            => make(stream(head).Concat(tail));

        /// <summary>
        /// Constructs a new list by successive concatenation
        /// </summary>
        /// <typeparam name="X">The list element type</typeparam>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static List<X> chain<X>(params List<X>[] lists)
            => make(from list in lists
                    from item in list.Stream()
                    select item);

        /// <summary>
        /// Constructs a new list by appending head to tail
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static List<X> cons<X>(X head, List<X> tail)
            => make(stream(head).Concat(tail.Stream()));

        /// <summary>
        /// Retrieves the first element of the list if it exists; otherwise, raises an exception
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l">The input list</param>
        /// <returns></returns>
        public static Option<X> head<X>(List<X> l)
            => l.Stream().FirstOrDefault();

        /// <summary>
        /// Gets the head of the list if nonempty, othwise returns the supplied default
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static X head<X>(List<X> list, X @default)
            => list.Stream().FirstOrDefault(@default);

        /// <summary>
        /// Retrieves the last element of the list if it exists; otherwise, none
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l">The input list</param>
        /// <returns></returns>
        public static Option<X> last<X>(List<X> l)
            => l.Stream().LastOrDefault();

        /// <summary>
        /// Produces the empty list
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <returns></returns>
        public static List<X> empty<X>()
            => List<X>.Empty;

        /// <summary>
        /// Returns the length of the list
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list">The input list</param>
        /// <returns></returns>
        public static int length<X>(List<X> list)
            => list.Count;

        /// <summary>
        /// Creates a new list [x2, ..., xn] from an input list [x1, ..., xn]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list">The input list</param>
        /// <returns></returns>
        public static Option<List<X>> tail<X>(List<X> list)
            => list.Count <= 1 ? none<List<X>>() : make(list.Stream().Skip(1));

        /// <summary>
        /// Creates a new list [x1,x2, ..., x(n-1)] from an input list [x1,...,xn]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list">The input list</param>
        /// <returns></returns>
        public static List<X> init<X>(List<X> list)
            => make(list.Stream().Take(list.Count - 1));

        /// <summary>
        /// Decomposes ("unconstructs") a nonempty list into a head/tail; otherwise returns None
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Option<(X, List<X>)> uncons<X>(List<X> list)
            => list.IsEmpty ? none<(X, List<X>)>()
                : from h in head(list)
                  from t in tail(list)
                  select (h, t);


        static G.IEnumerable<List<X>> _tails<X>(List<X> list)
        {
            var lastIdx = list.Count - 1;
            for (var i = 0; i <= lastIdx; i++)
                yield return list[i, lastIdx];            
        }

        public static List<List<X>> tails<X>(List<X> list)
            => make(_tails(list));

        /// <summary>
        /// Produces a new list from an existing list via a traversal operator
        /// </summary>
        /// <typeparam name="X">The input list item type</typeparam>
        /// <typeparam name="Y">The output list item type</typeparam>
        /// <param name="f">The traverser effector</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Y> traverse<X, Y>(Func<X, List<Y>> f, List<X> list)
            => make(from x in list.Stream()
                    from y in f(x).Stream()
                    select y);

        public static List<Y> imap<X, Y>(Func<X, Y> f, Func<Y, X> g, List<X> Fx)
        {
            var query = from x in Fx
                        select g(f(x));
            return map(f, query);
        }

        /// <summary>
        /// Creates a new list [xn, ..., x(n-1), x1] from an input list [x1,...xn]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list">The list to reverse</param>
        /// <returns></returns>
        public static List<X> reverse<X>(List<X> list)
            => make(list.Stream().Reverse());

        /// <summary>
        /// Creates a list from the first <paramref name="n"/> elements of list
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="n"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<X> take<X>(int n, List<X> list)
            => list.Count >= n ? list : make(list.Stream().Take(n));

        /// <summary>
        /// Constructs the list [x(k+1), x(k+2), ..., xn] from an existing list [x1, ..., xk]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="n">The number of elements to skip</param>
        /// <param name="list">the source list</param>
        /// <returns></returns>
        public static List<X> skip<X>(int n, List<X> list)
            => make(list.Stream().Skip(n));

        /// <summary>
        /// Creates a new list [x1, x, x2, x, ..., x, x(n-1), xn]
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="x">The value to intersperse between paired elements</param>
        /// <param name="list">The input list</param>
        /// <returns></returns>
        public static List<X> intersperse<X>(X x, List<X> list)
            => Seq.intersperse(x, list.Contained());

        /// <summary>
        /// Concatenates a sequence of lists
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="lists">The lists to concatenate</param>
        /// <returns></returns>
        public static List<X> concat<X>(G.IEnumerable<List<X>> lists)
            => make(lists.Select(l => l.Stream()).SelectMany(x => x));

        /// <summary>
        /// Appends one list to another
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l1">The firt list</param>
        /// <param name="l2">The second list</param>
        /// <returns></returns>
        public static List<X> concat<X>(List<X> l1, List<X> l2)
            => make(l1.Stream().Concat(l2.Stream()));

        /// <summary>
        /// Creates a list containing <paramref name="n"/> copies of the value <paramref name="x"/> 
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="n">The length of the resulting list</param>
        /// <param name="x">The value to replicate</param>
        /// <returns></returns>
        public static List<X> replicate<X>(int n, X x)
            => Seq.replicate(n, x);

        /// <summary>
        /// The canonical right-fold operation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="Y">The accumulation type</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The initial value</param>
        /// <param name="list">The list to which the fold will be applied</param>
        /// <returns></returns>
        public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, List<X> list)
            => Seq.foldr(f, y0, list);

        /// <summary>
        /// The canonical left-fold operation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="Y">The accumulation type</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The initial value</param>
        /// <param name="list">The list to which the fold will be applied</param>
        /// <returns></returns>
        public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, List<X> list)
            => Seq.foldl(f, y0, list);

        /// <summary>
        /// A left fold where the initial value is take from the head of the list
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="list">The list to which the fold will be applied</param>
        /// <returns></returns>
        public static Option<X> foldl<X>(Func<X, X, X> f, List<X> list)
            => Seq.foldl(f, list);

        /// <summary>
        /// Combines the values in a list using a supplied combiner function
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="combiner">A transformation (x1,x2) -> x3</param>
        /// <param name="list">The list whose elements will be combined</param>
        /// <returns></returns>
        public static X combine<X>(Combiner<X> combiner, List<X> list)
            => list.Stream().Aggregate((x, y) => combiner(x, y));


        /// <summary>
        /// Returns true if a predicate is satisfied for all elements in a list; false otherwise
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate to evaluate</param>
        /// <param name="list">The list over which to evaluate the predicate</param>
        /// <returns></returns>
        public static bool all<X>(Func<X, bool> p, List<X> list)
            => Container.all(p, list);

        /// <summary>
        /// Returns true if a predicate is satisfied for any element in a list
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate</param>
        /// <param name="list">The list over which to evaluate the predicate</param>
        /// <returns></returns>
        public static bool any<X>(Func<X, bool> p, List<X> list)
            => list.Stream().Any(p);

        /// <summary>
        /// Returns true if a specified element exists in a list, false otherwise
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="match">The value to search for</param>
        /// <param name="list">The list to search</param>
        /// <returns></returns>
        public static bool contains<X>(X match, List<X> list)
            => any(item => Equals(item, match), list);

        /// <summary>
        /// Filters an input list by an adjudicating predicate
        /// </summary>
        /// <typeparam name="X">The list item type</typeparam>
        /// <param name="p">The predicate</param>
        /// <param name="list">The list to filter</param>
        /// <returns>The elements of the input sequence that satisfy the predicate</returns>
        public static List<X> filter<X>(Func<X, bool> p, List<X> list)
            => make(list.Stream().Where(p));

        /// <summary>
        /// Joins two lists to produce a new list of ordered pairs
        /// derived from the source lists
        /// </summary>
        /// <typeparam name="X">The item type of the first list</typeparam>
        /// <typeparam name="Y">The item type of the second list</typeparam>
        /// <param name="x">The first input list</param>
        /// <param name="y">The second input list</param>
        /// <returns></returns>
        public static List<(X x, Y y)> zip<X, Y>(List<X> x, List<Y> y)
            => Seq.zip(x.Contained(), y.Contained());

        /// <summary>
        /// Transforms a list of ordered pairs into an ordered pair of lists
        /// </summary>
        /// <typeparam name="X">The left sequence element type</typeparam>
        /// <typeparam name="Y">The right sequence element type</typeparam>
        /// <param name="items">The sequence to transform</param>
        /// <returns></returns>
        public static (List<X> x, List<Y> y) unzip<X, Y>(List<(X x, Y y)> items)
        {
            var u = Seq.unzip(items.Contained());
            return (u.x, u.y);
        }         

        /// <summary>
        /// Concatenates a sequence of sequences into a single sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="sequences">The lists to concatenate</param>
        /// <returns></returns>
        public static List<X> flatten<X>(List<List<X>> sequences)
             => make(sequences.Stream().SelectMany(x => x.Stream()));

        /// <summary>
        /// flatten + map = flatmap
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f"></param>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static List<Y> flatmap<X, Y>(Func<X, Y> f, List<List<X>> lists)
             => make(from s in lists.Stream() from item in s.Stream() select f(item));

        /// <summary>
        /// Returns true if two lists are equal, false otherwise
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="x1">The first list</param>
        /// <param name="x2">The second list</param>
        /// <returns></returns>
        public static bool eq<X>(List<X> x1, List<X> x2)
            => ListEquator<X>.instance(x1, x2);

        /// <summary>
        /// Returns true if two lists are not equal
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="x1">The first list</param>
        /// <param name="x2">The second list</param>
        /// <returns></returns>
        public static bool neq<X>(List<X> x1, List<X> x2)
            => not(eq(x1, x2));

        /// <summary>
        /// Computes the list hash code
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int hash<X>(List<X> list)
            => list.Stream().GetHashCodeAggregate();

        /// <summary>
        /// Formats the list for display
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="list">The list to format</param>
        /// <returns></returns>
        public static string format<X>(List<X> list)
            => list.ToString();

        /// <summary>
        /// Constructs a <see cref="IStreamable"/> over <paramref name="list"/>
        /// </summary>
        /// <typeparam name="X">The sequence item type</typeparam>
        /// <param name="list">The input sequence</param>
        /// <returns></returns>
        public static Streamable<X> Streamable<X>(List<X> list)
            => Seq.Streamable(list.AsSeq());
    }
}