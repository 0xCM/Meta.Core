//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    public abstract class ModuleDescriptor
    {
        protected ModuleDescriptor(ModuleIdentifier Module, ModuleKind Classification, IEnumerable<ModuleIdentifier> Dependencies)
        {
            this.Classification = Classification;
            this.Module = Module;
            this.Dependencies = Dependencies.ToReadOnlySet();

        }

        public ModuleKind Classification { get; }


        public ModuleIdentifier Module { get; }

        public ReadOnlySet<ModuleIdentifier> Dependencies { get; }
    }

    public abstract class ModuleDescriptor<C> : ModuleDescriptor
    {
        protected ModuleDescriptor(ModuleKind Classification, ModuleIdentifier Module, IEnumerable<ModuleIdentifier> Dependencies)
            : base(Module, Classification, Dependencies)
        {

        }

    }

}