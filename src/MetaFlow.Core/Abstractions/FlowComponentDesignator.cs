//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using static metacore;

    public abstract class FlowComponentDesignator<A> : AssemblyDesignator<A>
        where A : FlowComponentDesignator<A>, new()
    {

        public const string ProductName = "MetaFlow";
        public const string AssemblyVersion = "1.1.*";
        IReadOnlyList<Assembly> Dependencies;


        public override sealed IReadOnlyList<Assembly> ModuleDependencies
            => ComponentDependencies;

        public virtual IReadOnlyList<Assembly> ComponentDependencies
            => (Dependencies ?? array(Assembly.GetExecutingAssembly()));


        protected FlowComponentDesignator(IEnumerable<Assembly> Dependencies)
        {
            this.Dependencies = Dependencies.ToList();
            this.DefiningSystem = SystemIdentifier.Empty;
        }

        protected FlowComponentDesignator(SystemIdentifier DefiningSystem)
        {
            this.Dependencies = Dependencies.ToList();
            this.DefiningSystem = DefiningSystem;

        }
        protected FlowComponentDesignator()
        {
            DefiningSystem = SystemIdentifier.Empty;

        }

        public SystemIdentifier DefiningSystem { get; }

    }
}
