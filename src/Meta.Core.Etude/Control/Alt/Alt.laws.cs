//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using static metacore;

    /// <summary>
    /// Specifies the signature for the alt map
    /// </summary>
    /// <typeparam name="CX">The container type</typeparam>
    /// <param name="cx1"></param>
    /// <param name="cx2"></param>
    /// <returns></returns>
    public delegate CX AltMap<CX>(CX cx1, CX cx2);

    /// <summary>
    /// Identifies and characterizes the Alt typeclass
    /// </summary>
    public interface IAlt : IFunctor { }

    /// <summary>
    /// Characterizes productions of the <see cref="IAlt"/> typeclass and thus defines
    /// the contract for membership in same
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <typeparam name="CX">The element container type</typeparam>   
    public interface IAlt<X,CX> : IAlt, IFunctor<X, CX, X, CX>
        where CX : IContainer<X>
    {
        CX alt(CX f, CX g);
    }

    partial class classops
    {
        public readonly struct alt : IClassOp<alt>
        {
            public static readonly alt op = default;
            public const string S = "<|>";
        }

    }

}