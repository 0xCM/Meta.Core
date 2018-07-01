//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines an instance of <see cref="IMonad"/> predicated on specified Applicative and Bind realizations
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Monad<X, CX, CFX, Y, CY> : IMonad<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>

    {
        IApplicative<X, CX, CFX, Y, CY> Applicative { get; }

        IBind<X, CX, CFX, Y, CY> Bind { get; }

        public Monad(IApplicative<X, CX, CFX, Y, CY> Applicative, IBind<X, CX, CFX, Y, CY> Bind)
        {
            this.Applicative = Applicative;
            this.Bind = Bind;
        }

        public CY apply(CFX cf, CX Fx)
            => Applicative.apply(cf, Fx);

        public CY bind(CX f, Func<X, CY> g)
            => Bind.bind(f, g);

        public Func<CX, CY> fmap(Func<X, Y> f)
            => Applicative.fmap(f);

        public CX pure(X x) 
            => Applicative.pure(x);
    }
}