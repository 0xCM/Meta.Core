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
    /// Specifies the bind operation signature
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    /// <returns></returns>
    public delegate CY Binder<X, CX, CFX, Y, CY>(CX cx, Func<X, CY> f);

    /// <summary>
    /// Identifies and characterizes the Bind typeclass
    /// </summary>
    public interface IBind : IApply
    {

    }

    /// <summary>
    /// Characterizes productions of the <see cref="IBind"/> typeclass
    /// </summary>
    public interface IBind<X, CX, CFX, Y, CY> : IBind, IApply<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>
    {
        CY bind(CX f, Func<X, CY> g);
    }

    partial class classops
    {
        /// <summary>
        /// Represents the <see cref="IBind"/> bind operation
        /// </summary>
        public readonly struct bind : IClassOp<bind>
        {
            public static readonly bind op = default;
            public const string S = ">>=";
        }


    }

}