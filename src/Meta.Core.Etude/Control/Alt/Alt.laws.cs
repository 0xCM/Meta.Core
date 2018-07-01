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
    public interface IAlt : IFunctor
    {

    }


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

    public static class AltX
    {
        public static AltMap<CX> alt<X, CX>(this IAlt<X, CX> alt)
            where CX : IContainer<X>
                => alt.alt;

    }


    partial class classops
    {
        public readonly struct alt : IClassOp<alt>
        {
            public static readonly alt op = default;
            public const string S = "<|>";
        }

        //public readonly struct alt<X,CX>
        //    where CX : IContainer<X>
        //{
        //    public static readonly alt<X, CX> instance = default;

        //    public AltMap<CX> this[IAlt<X,CX> instance]
        //        => instance.alt;
        //}


        
    }

    public class AltLaws
    {
        public static object Associativity()
        {

            var x = list(3, 4, 5);
            var y = list(8, 9, 10);
            var z = list(2, 3, 7);

            var alt = ListAlt<int>.instance.alt();
            var same = alt(alt(x, y), z) == alt(x, alt(y, z));
          

            return null;
        }
    }
}