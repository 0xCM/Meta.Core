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

    public abstract class ClassModule : IClassModule
    {
        
        public Type GenericTypeDefinition { get; }

        protected virtual Option<TypeConstructor> TypeConstructor(int arity)
            => none<TypeConstructor>();

        public Option<ConstructedType> ConsructType(params Type[] args)
            => from tc in TypeConstructor(args.Length)
               from type in TypeClass.construct(tc, args)
               select type;

        protected ClassModule(Type GenericTypeDefinition)
            => this.GenericTypeDefinition = GenericTypeDefinition;
    }

    /// <summary>
    /// Base class for typeclass-specific modules
    /// </summary>
    /// <typeparam name="M"></typeparam>
    /// <typeparam name="I"></typeparam>
    public abstract class ClassModule<M, I> : ClassModule, IClassModule<M>
        where I : ITypeClass
        where M : ClassModule<M, I>,  new()

    {


        protected static readonly M ModuleInstance
            = new M();

        protected ClassModule(Type GenericTypeDefinition)
            : base(GenericTypeDefinition)
        {

        }

        //protected virtual ITypeConstructor<M, X, MX> TypeConstructor<X, MX>(int arity)
        //      where MX : IContext<X, MX>, new() => TypeConstructor<M, X, MX>.instance;

    }
}