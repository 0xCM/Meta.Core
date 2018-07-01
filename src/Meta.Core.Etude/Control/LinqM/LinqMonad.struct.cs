//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// Defines a minimalistic monad optimized for both simplicity and generality
    /// </summary>
    /// <typeparam name="X">The base space over which the monad is defined</typeparam>
    public readonly struct LinqMonad<X> : IMonad<X>
    {
        public static readonly IMonad<X> Default = new LinqMonad<X>();

        /// <summary>
        /// Implicitly lifts a value from the base space X into monadic X-space, often denoted by M(X)
        /// </summary>
        /// <param name="x">The value to lift</param>
        public static implicit operator LinqMonad<X>(X x)
            => x;

        /// <summary>
        /// Explicitly drops a value from monadic space M(X) to base space X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static explicit operator X(LinqMonad<X> x)
            => x.Value;

        /// <summary>
        /// Drops a value from monadic space M(X) to base space X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static X operator ~(LinqMonad<X> x)
            => x.Value;

        /// <summary>
        /// Initalizes a point in monadic with a value from the base space
        /// </summary>
        /// <param name="Value"></param>
        public LinqMonad(X Value)
            => this.Value = Value;

        /// <summary>
        /// The encapsulated value
        /// </summary>
        X Value { get; }

        public override string ToString()
           => $"{Value}";

        X IMonad<X>.unwrap()
            => Value;

        IMonad<Y> IMonad<X>.pure<Y>(Y value)
            => new LinqMonad<Y>(value);

        IMonad<Y> IMonad<X>.fmap<Y>(Func<X, Y> f)
            => LinqMonad.fmap(Value, f);

        IMonad<Y> IMonad<X>.bind<Y>(Func<X, IMonad<Y>> f)
            => throw new NotImplementedException();

        IMonad<Z> IMonad<X>.bind<Y, Z>(Func<X, IMonad<Y>> f, Func<X, Y, Z> compose)
            => throw new NotImplementedException();

    }

}