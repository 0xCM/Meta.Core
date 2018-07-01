//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public interface IDependencyResolver
{
    /// <summary>
    /// Retrieves the contract types for which the resolver can provide implementations
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<Type> GetResolvableConracts(IAssemblyRegistrar Registrar);

    T ResolveService<T>(string ImplementationName);

    
}

public interface IDependencyResolver<in C> : IDependencyResolver
{
    Option<T> ResolveService<T>(string ImplementationName, C Configuration);
}


