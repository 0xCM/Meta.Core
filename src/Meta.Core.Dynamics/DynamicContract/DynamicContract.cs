//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Provides access to high-level dynamic contract capabilities
/// </summary>
public sealed class DynamicContract
{
    /// <summary>
    /// Realizes implementation of a user-defined contract by delegating through a <see cref="IDynamicContractMessenger"/> implementation
    /// </summary>
    /// <typeparam name="TContract">The type of realized contract</typeparam>
    /// <param name="messenger">The dynamic contract</param>
    /// <returns></returns>
    public static TContract Realize<TContract>(IDynamicContractMessenger messenger)
    {
        var type = DynamicContractImplementor.ImplementContract<TContract>(messenger.ImplementationName);
        return (TContract)Activator.CreateInstance(type, messenger);
    }

    /// <summary>
    /// Realizes implementation of an interface contract via an instance of the <see cref="DynamicContractHost{T}"/> type
    /// </summary>
    /// <typeparam name="TContract"></typeparam>
    /// <param name="contract"></param>
    /// <returns></returns>
    public static TContract Realize<TContract>(IDynamicContract contract)
    {
        var host = new DynamicContractHost<TContract>(contract);
        return Realize<TContract>(host.Messenger);
    }

}
