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

    public class ResolvedExport : InstanceExport
    {
        public ResolvedExport(Type ModuleType, Type ClassType, Type GenericDefinition, Type Closure)
            : base(ModuleType, ClassType, GenericDefinition)
        {

            this.Closure = Closure;
        }

        public Type Closure { get; }

        public Option<K> Instantiate<K>()
            where K : ITypeclass
                => Try( () => (K)Activator.CreateInstance(Closure));
    }


}