//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

using static minicore;

sealed class AssemblyRegistar : ApplicationService<AssemblyRegistar, IAssemblyRegistrar>, IAssemblyRegistrar
{
    readonly ConcurrentDictionary<Assembly, Assembly> assemblies 
        = new ConcurrentDictionary<Assembly, Assembly>();

    public AssemblyRegistar(IApplicationContext context)
        : base(context)
    { }

    public void RegisterAssemblies(params Assembly[] assemblies)
        => iter(assemblies, assembly => this.assemblies.TryAdd(assembly, assembly));

    public IReadOnlyList<Assembly> GetRegisteredAssemblies()
        => assemblies.Keys.ToList();

    public void UnregisterAssemblies(params Assembly[] assemblies)
        => iter(assemblies, assembly => this.assemblies.TryRemove(assembly));

    public IReadOnlyList<Type> GetAssemblyTypes()
        => assemblies.Values.SelectMany(x => x.GetTypes())
                            .Where(t => t.GetCustomAttribute<CompilerGeneratedAttribute>() == null).ToList();

    public IEnumerable<Type> Types(Predicate<Type> IfSatisfied)
        => assemblies.Values.SelectMany(a => a.GetTypes().Where(t => IfSatisfied(t)));
           
}