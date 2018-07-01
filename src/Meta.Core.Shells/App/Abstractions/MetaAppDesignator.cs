//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;


    public abstract class MetaAppDesignator<A> : AssemblyDesignator<A>
        where A : MetaAppDesignator<A>, new()
    {



        protected abstract IReadOnlySet<Assembly> RequiredComponents { get; }

        public override sealed IReadOnlyList<Assembly> ModuleDependencies
            => RequiredComponents.ToList();

        protected MetaAppDesignator()
        {


        }

    }
    public abstract class MetaAppDesignator<H, S> : AssemblyDesignator<H>
        where H : MetaAppDesignator<H, S>, new()
    {


        public static ClrAssembly HostAssembly
            => global::ClrAssembly.Get(Assembly);

        Guid ServiceIdentifier { get; }
        string ServiceName { get; }

        static string ConventionalName()
        {
            var start = typeof(S).Name;
            var finish = start.TrimStart('I');
            if (!finish.EndsWith("Service"))
                finish = $"{finish}Service";
            return finish;
        }

        protected MetaAppDesignator(Guid ServiceIdentifier, string ServiceName = null)
        {
            this.ServiceIdentifier = ServiceIdentifier;
            this.ServiceName = ServiceName ?? ConventionalName();
        }


        protected abstract IReadOnlySet<Assembly> RequiredComponents { get; }

        public override sealed IReadOnlyList<Assembly> ModuleDependencies
            => RequiredComponents.ToList();

    }
}