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

    public abstract class ClassModule : CodeModule, IClassModule
    {

        protected ClassModule(Type GenericTypeDefinition)
            : base(GenericTypeDefinition)
        { }
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

    }
}