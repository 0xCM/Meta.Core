//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class ModuleInfo
    {
        public ModuleInfo(Type ModuleType, IEnumerable<InstanceExport> Exports, 
            IEnumerable<ResolvedExport> Resolutions, IEnumerable<ITypeclass> Constructions)
        {
            this.ModuleType = ModuleType;
            this.Exports = Exports;
            this.Resolutions = Resolutions;
            this.Constructions = Constructions;
        }

        public Type ModuleType { get; }
        public IEnumerable<InstanceExport> Exports { get; }

        public IEnumerable<ResolvedExport> Resolutions { get; }

        public IEnumerable<ITypeclass> Constructions { get; }


        public Option<InstanceExport> Export<K>()
            where K : ITypeclass
                => Exports.TryGetFirst(x => x.ClassType == typeof(K));

    }


}