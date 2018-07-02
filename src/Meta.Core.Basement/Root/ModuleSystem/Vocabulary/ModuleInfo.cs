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
            IEnumerable<ResolvedExport> Resolutions, IEnumerable<ITypeClass> Constructions)
        {
            this.ModuleType = ModuleType;
            this.Exports = Exports;
            this.Resolutions = Resolutions;
            this.Constructions = Constructions;
        }

        public Type ModuleType { get; }
        public IEnumerable<InstanceExport> Exports { get; }

        public IEnumerable<ResolvedExport> Resolutions { get; }

        public IEnumerable<ITypeClass> Constructions { get; }


        public Option<InstanceExport> Export<K>()
            where K : ITypeClass
                => Exports.TryGetFirst(x => x.ClassType == typeof(K));

    }


}