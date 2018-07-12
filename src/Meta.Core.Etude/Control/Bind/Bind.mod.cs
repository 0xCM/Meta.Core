//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    /// <summary>
    /// Constructs and manipulates <see cref="IBind"/> types and values
    /// </summary>
    public class Bind : ClassModule<Bind,IBind>, IBind
    {

        public Bind()
            : base(typeof(Bind<,,,,>))
        {

        }

        public static IBind<X, CX, CFX, Y, CY> make<X, CX, CFX, Y, CY>(IApply<X, CX, CFX, Y, CY> applier, Binder<X, CX, CFX, Y, CY> binder)
            where CX : IContainer<X>
            where CFX : IContainer<Func<X, Y>>
            where CY : IContainer<Y>
                => new Bind<X, CX, CFX, Y, CY>(applier, binder);


    }

}