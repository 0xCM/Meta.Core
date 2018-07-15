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
    /// Represents a source-code level module (as opposed to a .net module, an assembly, etc.)
    /// </summary>
    public abstract class CodeModule : ICodeModule
    {
        public Type GenericTypeDefinition { get; }

        protected Option<TypeConstructor> Constructor(int arity)
            => new TypeConstructor(GenericTypeDefinition);

        public Option<TypeConstruction> ConstructType(params Type[] args)
            => from tc in Constructor(args.Length)
               from type in TypeConstructor.construct(tc, args)
               select type;


        protected CodeModule(Type GenericTypeDefinition)
            => this.GenericTypeDefinition = GenericTypeDefinition;


    }

}