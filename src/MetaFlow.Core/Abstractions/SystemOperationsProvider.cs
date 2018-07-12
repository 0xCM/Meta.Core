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

    using Meta.Core;

    using static metacore;

    public abstract class SystemOperationsProvider<A> : PlatformComponent<A>, ISystemOperationsProvider
        where A : SystemOperationsProvider<A>, new()
    {

        static IReadOnlySet<SystemOperation> ProvidedOperations { get; }

        static SystemOperationsProvider()
        {
            var ass = typeof(A).Assembly;
            
            var commands = ShellCommandLibrary.Create(stream(ass)).Commands(false);
            ProvidedOperations = roset(commands.Select(c => new SystemOperation(DefiningSystem, c)));           
        }

        protected SystemOperationsProvider()
        {

        }

        protected SystemOperationsProvider(SystemIdentifier DefiningSystem)
        {
        }

        public virtual IEnumerable<Assembly> LoadedComponents
            => stream<Assembly>();


        IEnumerable<SystemOperation> ISystemOperationsProvider.ProvidedOperations
            => ProvidedOperations;
    }


}