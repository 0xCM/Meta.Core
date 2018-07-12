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

    using MetaFlow.Core;

    using static metacore;

    public abstract class PlatformComponent<A> : AssemblyDesignator<A>, IPlatformComponent
        where A : PlatformComponent<A>, new()
    {
        static readonly PlatformSystems Systems = new PlatformSystems();

        public static SystemIdentifier DefiningSystem
        {
            get
            {
                return( from attrib in typeof(A).Assembly.TryGetAttribute<PlatformSystemAttribute>()
                        let kind = attrib.Classification
                        from id in Systems.TryGetSingle(s => s.Identifier == kind.ToSystemIdentifier())
                        select id).ValueOrDefault(SystemIdentifier.Empty);
                                
            }


        }
        public const string ProductName = "MetaFlow";
        public const string AssemblyVersion = "1.0.*";
        IReadOnlyList<Assembly> Dependencies;


        public override sealed IReadOnlyList<Assembly> ModuleDependencies
            => ComponentDependencies;

        public virtual IReadOnlyList<Assembly> ComponentDependencies
            => (Dependencies ?? array(Assembly.GetExecutingAssembly()));


        protected PlatformComponent(SystemIdentifier DefiningSystem)
        {
            this.Dependencies = rolist<Assembly>();
            
        }

        protected PlatformComponent()
        {
            this.Dependencies = rolist<Assembly>();
        }

        SystemIdentifier IPlatformComponent.DefiningSystem
            => DefiningSystem;


    }
}
