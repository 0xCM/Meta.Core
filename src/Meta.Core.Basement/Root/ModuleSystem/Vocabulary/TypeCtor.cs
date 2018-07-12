//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;

    // represents a type constructor of the type K parameterized by A
    // if the language would allow it, it would perhaps be
    // denoted by k<a> or k[a]
    // example: tc: List -> a -> List<a>

    public interface ITypeConstructor<M,X,MX>
        where M : IClassModule<M>, new()
        where MX : IContext<X, MX>, new()
    {
        MX construct();    
    }

    public readonly struct TypeConstructor<M, X, MX> : ITypeConstructor<M,X,MX>
        where M : IClassModule<M>,new()
        where MX : IContext<X, MX>, new()
    {
        public static readonly TypeConstructor<M, X, MX> instance = default;

        public MX construct()
            => new MX();
    }

    public class TypeConstructor
    {

        public TypeConstructor(Type GenericType)
        {
            this.GenericType = GenericType;
        }

        /// <summary>
        /// The open generic type from which a closed type can be formed
        /// </summary>
        public Type GenericType { get; }

    } 
}