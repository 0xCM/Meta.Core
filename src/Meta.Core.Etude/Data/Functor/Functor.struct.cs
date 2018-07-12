//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Specifies a <see cref="IFunctor"/> typeclass predicated on a
    /// constructor-injected transformer
    /// </summary>
    /// <typeparam name="X">The type of the source</typeparam>
    /// <typeparam name="CX">A constructed source container type</typeparam>
    /// <typeparam name="CY">A construction target container type</typeparam>
    /// <typeparam name="Y">The type of the target</typeparam>
    public readonly struct Functor<X, CX, Y, CY> : IFunctor<X, CX, Y, CY>
        where CX : IContainer<X,CX>, new()
        where CY : IContainer<Y,CY>, new()
    {

        public Functor(FunctorMap<X, CX, Y, CY> fmap)
            => this._fmap = fmap;

        FunctorMap<X,CX,Y,CY>  _fmap { get; }

        public Func<CX, CY> fmap(Func<X, Y> f)
            => _fmap(f);

    }



    //public class Functor<F,A,B> :  Functor<B>
    //{
    //    public Functor(Func<A, B> f)
    //        => this.map = f;

    //    public Func<A, B> map { get; }
    //}

    //public abstract class TypeClass<T>
    //    where T : TypeClass<T>
    //{

    //}

    //public class Functor<F> : TypeClass<Functor<F>>        
    //{
    //    public static Func<Functor<A>, Functor<B>> fmap<A, B>(Func<A, B> f)
    //        => fa => new Functor<F,A,B>(f);

    //}

    //public class Functor<F,A,B> :  Functor<B>
    //{
    //    public Functor(Func<A, B> f)
    //        => this.map = f;

    //    public Func<A, B> map { get; }
    //}




}