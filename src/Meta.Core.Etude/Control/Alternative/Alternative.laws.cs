//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IAlternative : IApplicative, IPlus
    {

    }
    
    //IAlternative should specialize IPlus but cannot due to type system constraints
    public interface IAlternative<X, CX, CFX, Y, CY> : IAlternative, IApplicative<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>
    {

        /// <summary>
        /// The container's additive identity
        /// </summary>
        CX empty { get; }

    }

}