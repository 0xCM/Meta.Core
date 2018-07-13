//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;
    using static minicore;

    /// <summary>
    /// Represents a cartesian product of types
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="KA"></typeparam>
    public readonly struct TypeConstructor<K, A, KA> : ITypeConstructor<K, A, KA>
        where K : IClassModule<K>, new()
        where KA : IContext<A, KA>, new()
    {
        public static readonly TypeConstructor<K, A, KA> instance = default;

        public KA construct()
            => new KA();
    }



    public readonly struct TypeConstructor
    {
               
        /// <summary>
        /// Closes a typeclass with the supplied arguments 
        /// </summary>
        /// <param name="Arguments"></param>
        /// <returns></returns>
        public static Option<TypeConstruction> construct(TypeConstructor constructor, params Type[] Arguments)
            => Try(() => new TypeConstruction(constructor,
                    Arguments, constructor.GenericType.MakeGenericType(Arguments)));

        public TypeConstructor(Type GenericType)
        {
            this.GenericType = GenericType;
        }

        /// <summary>
        /// The open generic type from which a closed type can be formed
        /// </summary>
        public Type GenericType { get; }

        public Option<TypeConstruction> Construct(params Type[] args)
            => construct(this, args);

    } 
}