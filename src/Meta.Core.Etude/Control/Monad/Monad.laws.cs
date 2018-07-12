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
    /// Identifies and characterizes the IMonad typeclass
    /// </summary>
    public interface IMonad : ITypeClass { }

    public interface IMonad<X> : IMonad
    {
        IMonad<Y> pure<Y>(Y value);

        X unwrap();
        
        IMonad<Y> fmap<Y>(Func<X, Y> f);

        IMonad<Y> bind<Y>(Func<X, IMonad<Y>> f);

        IMonad<Z> bind<Y, Z>(Func<X, IMonad<Y>> f, Func<X, Y, Z> compose);
    }

    public interface IMonad<X, CX, CFX, Y, CY> : IMonad, IApplicative<X, CX, CFX, Y, CY>, IBind<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>

    {

    }
}