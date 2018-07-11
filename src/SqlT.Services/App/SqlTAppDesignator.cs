//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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