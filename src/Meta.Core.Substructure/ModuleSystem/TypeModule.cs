//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    

    using static minicore;

    /// <summary>
    /// A module that defines features for a specifc (data) type
    /// </summary>
    /// <typeparam name="M">The derived subclass type</typeparam>
    public abstract class TypeModule<M> : ITypeModule<M>
        where M : TypeModule<M>, new()
    {
     
        protected static readonly M ModuleInstance
            = new M();

        protected virtual Option<TypeConstructor> TypeConstructor(int arity)
            => none<TypeConstructor>();

        public Option<ConstructedType> ConsructType(params Type[] args)
            => from tc in TypeConstructor(args.Length)
               from type in Typeclass.construct(tc, args)
               select type;

        public Type GenericTypeDefinition { get; }
    }

}