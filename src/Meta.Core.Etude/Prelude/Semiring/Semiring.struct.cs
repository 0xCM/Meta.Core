//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Predicates a <see cref="ISemiring"/> instance on constructor-injected values
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <remarks>A semiring is almost a ring but is not because the additive inverse of a given
    /// element is not required to exist</remarks>
    readonly struct Semiring<X> : ISemiring<X>
    {
        public Semiring(X zero, X one, Combiner<X> add, Combiner<X> mul)
        {
            this.zero = zero;
            this.one = one;
            this._add = add;
            this._mul = mul;
        }

        Combiner<X> _add { get; }

        Combiner<X> _mul { get; }

        public X zero { get; }
            
        public X one { get; }

        public X combine(X x1, X x2)
            => _add(x1, x2);

        public X mul(X x1, X x2)
            => _mul(x1, x2);
    }
}