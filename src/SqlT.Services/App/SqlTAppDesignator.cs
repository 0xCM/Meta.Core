//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using static metacore;

    public abstract class SqlTAppDesignator<A> : SqlTModule<A>
        where A : SqlTAppDesignator<A>, new()
    {

        IReadOnlyList<Assembly> Dependencies;

        public override IReadOnlyList<Assembly> ModuleDependencies
            => Dependencies;

        protected SqlTAppDesignator(IEnumerable<Assembly> Dependencies)
            => this.Dependencies = Dependencies.ToList();
        
        protected SqlTAppDesignator()
            => Dependencies = rolist<Assembly>();

    }
}