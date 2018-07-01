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
    /// Specifies the canonical applier signature
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    /// <param name="cf"></param>
    /// <param name="cx"></param>
    /// <returns></returns>
    public delegate CY Applier<X, CX, CFX, Y, CY>(CFX cf, CX cx)
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>;

    /// <summary>
    /// Identifies and characterizes the Apply typeclass
    /// </summary>
    public interface IApply : IFunctor
    {

    }

    /// <summary>
    /// Characterizes productions of the <see cref="IApply"/> typeclass
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public interface IApply<X, CX, CFX, Y, CY> : IApply, IFunctor<X, CX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>
    {
        CY apply(CFX cf, CX cx);
    }

    partial class classops
    {
        /// <summary>
        /// Represents the <see cref="IApply"/> apply operation
        /// </summary>
        public readonly struct apply : IClassOp<apply>
        {
            public static readonly apply op = default;
            public const string S = "<*>";
        }

    }

}