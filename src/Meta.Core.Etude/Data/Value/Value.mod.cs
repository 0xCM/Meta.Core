//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;   

    public class Value : ClassModule<Value,IValue>
    {
        public Value()
            : base(typeof(Value<>))
        {

        }

        /// <summary>
        /// Lifts content into the Value context
        /// </summary>
        /// <typeparam name="X">The content type</typeparam>
        /// <param name="content">The content</param>
        /// <returns></returns>
        public static Value<X> make<X>(X content)
            => new Value<X>(content);

        /// <summary>
        /// Extracts the content from the Value context
        /// </summary>
        /// <typeparam name="X">The content type</typeparam>
        /// <param name="value">The contented value</param>
        /// <returns></returns>
        public static X unwrap<X>(Value<X> value)
            => value.Data;

        /// <summary>
        /// Gets the value equatable instance
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <returns></returns>
        public static IEq<Value<X>> Eq<X>()
            => new Eq<Value<X>>((x1, x2) => x1.Equals(x2));

        ///// <summary>
        ///// Specifies the canonical value functor
        ///// </summary>
        ///// <returns></returns>
        public static IFunctor<X, Value<X>, Y, Value<Y>> Functor<X, Y>()
            => new Functor<X, Value<X>, Y, Value<Y>>(fmap);


        /// <summary>
        /// Applies a funtion to a value
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f"></param>
        /// <param name="vx"></param>
        /// <returns></returns>
        public static Value<Y> map<X, Y>(Func<X, Y> f, Value<X> vx)
            => from x in vx select f(x);

        /// <summary>
        /// Applies a funtion to a value
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="f"></param>
        /// <param name="vx"></param>
        /// <returns></returns>
        public static Value<Y> apply<X, Y>(Value<Func<X, Y>> f, Value<X> vx)
            => f.Data(vx);

        public static IApply<X, Value<X>, Value<Func<X, Y>>, Y, Value<Y>> Apply<X, Y>()
            => Modules.Apply.make<X, Value<X>, Value<Func<X, Y>>, Y, Value<Y>>(Functor<X,Y>(), apply);

        /// <summary>
        /// Transforms a function f:X->Y to a function F:Value[X]->Value[Y]
        /// </summary>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to transform</param>
        /// <returns></returns>
        public static Func<Value<X>, Value<Y>> fmap<X, Y>(Func<X, Y> f)
            => x => f(x);

        /// <summary>
        /// Implements traversal capability
        /// </summary>
        /// <typeparam name="F"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public Func<F, Value<X>> sequenceA<F,X>(Value<Func<F, X>> f)
            => fx => from _f in f
                select make(_f(fx));
    }
}