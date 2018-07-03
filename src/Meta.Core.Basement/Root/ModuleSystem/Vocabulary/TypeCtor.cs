//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;


    // represents a type constructor of the type k parameterized by a
    // if the language would allow it, it would perhaps be
    // denoted by k<a> or k[a]
    // example: tc: List -> a -> List<a>
    public readonly struct Τ<k, a>
    {
        //public static List<a> operator *(Τ<k, a> t, List l)
        //    => List<a>.Empty;


    }

    public class TypeCtor
    {

        public TypeCtor(Type GenericType)
        {
            this.GenericType = GenericType;
        }

        /// <summary>
        /// The open generic type from which a closed type can be formed
        /// </summary>
        public Type GenericType { get; }

    }

 
}