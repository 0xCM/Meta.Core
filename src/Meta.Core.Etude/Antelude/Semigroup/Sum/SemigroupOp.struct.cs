//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// A pure monadic Sum
    /// </summary>
    /// <typeparam name="X">The type of the lifted Sum</typeparam>
    public readonly struct SemigroupOp<X> : IEquatable<SemigroupOp<X>>
    {
        static readonly Func<X, X, X> Operator = operators.add;

        /// <summary>
        /// Content-Sum lift
        /// </summary>
        /// <param name="Content"></param>
        public static implicit operator SemigroupOp<X>(X Content)
            => new SemigroupOp<X>(Content);

        /// <summary>
        /// Sum-Content descent
        /// </summary>
        /// <param name="Sum"></param>
        public static implicit operator X(SemigroupOp<X> Sum)
            => Sum.Value;

        public static SemigroupOp<X> operator +(SemigroupOp<X> a, SemigroupOp<X> b)
            => Operator(a.Value, b.Value);

        public static bool operator == (SemigroupOp<X> a, SemigroupOp<X> b)
            => a.Value.Equals(b.Value);

        public static bool operator !=(SemigroupOp<X> a, SemigroupOp<X> b)
            => not(a.Value.Equals(b.Value));

        public SemigroupOp(X Content)
            => this.Value = Content;

        /// <summary>
        /// The encapsulated Sum
        /// </summary>
        public X Value { get; }

        public bool Equals(SemigroupOp<X> other)
            => Equals(Value, other.Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object obj)
            => (obj is SemigroupOp<X>) ? Equals((SemigroupOp<X>)obj) : false;

        /// <summary>
        /// Canonical bind
        /// </summary>
        /// <typeparam name="Y">The base space fro the range of the bound function</typeparam>
        public SemigroupOp<Y> Bind<Y>(Func<X, SemigroupOp<Y>> f)
            => f(Value);

        /// <summary>
        /// Canonical select
        /// </summary>
        /// <typeparam name="Y">The target base space</typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public SemigroupOp<Y> Select<Y>(Func<X, Y> selector)
                => selector(Value);

        /// <summary>
        /// Canonical select many for LINQ integration
        /// </summary>
        /// <typeparam name="Y">The intermediate base space</typeparam>
        /// <typeparam name="Z">The target base space</typeparam>
        /// <param name="select"></param>
        /// <param name="applicative"></param>
        /// <returns></returns>
        public SemigroupOp<Z> SelectMany<Y, Z>(Func<X, SemigroupOp<Y>> select, Func<X, Y, Z> applicative)
        {
            var x = Value;
            return select(x).Bind<Z>(y => applicative(x, y));
        }

    }
}