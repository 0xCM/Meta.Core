//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    using static metacore;

    public class Foldable : ClassModule<Foldable,IFoldable> 
    {
        public Foldable()
            : base(typeof(Foldable<,>))
        { }

        public static IFoldable<X, CX> make<X,CX>()
            where CX : IContainer<X>
                => new Foldable<X,CX>();                

        class Fold<C, X> 
        {
            public static Option<Func<Func<X, Y, Y>, Y, Foldable, Y>> foldr<T, Y, Foldable>()
                => from m in methods<T>("foldr").First()
                   from d in m.CloseGenericMethod<X, Y>()
                   select d.Func<Func<X, Y, Y>, Y, Foldable, Y>();
        }
     }
}