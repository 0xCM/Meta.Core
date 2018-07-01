//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// A primary implementation of the <see cref="IDynamicContractMessenger"/> contract
/// that delgates contract implementation through a supplied <see cref="DelegateIndex"/>
/// </summary>
class DelegatedContract : IDynamicContractMessenger
{
    /// <summary>
    /// Realizes implementation of a contract by mediating access to a <see cref="DelegateIndex"/>
    /// </summary>
    /// <typeparam name="TContract">The type of realized contract</typeparam>
    /// <returns></returns>
    internal static TContract Realize<TContract>(string implementationName, DelegateIndex delegates)
    {
        var implementation = new DelegatedContract(implementationName, delegates);
        var type = DynamicContractImplementor.ImplementContract<TContract>(implementationName);
        return (TContract)Activator.CreateInstance(type, implementation);
    }

    public DelegatedContract(string implementationName, DelegateIndex delegates)
    {
        this.implementationName = implementationName;
        this.delegates = delegates;
    }

    string implementationName { get; }

    DelegateIndex delegates { get; }

    object IDynamicContractMessenger.InvokeFunctionWithParameters(MethodBase method, object[] parameters) 
        => delegates.Function(method.Name).DynamicInvoke(parameters);

    void IDynamicContractMessenger.InvokeActionWithParameters(MethodBase method, object[] parameters) 
        => delegates.Action(method.Name).DynamicInvoke(parameters);

    object IDynamicContractMessenger.GetPropertyValue(MethodBase getter) 
        => delegates.Getter(getter.Name)();

    void IDynamicContractMessenger.SetPropertyValue(MethodBase setter, object[] value) 
        => delegates.Setter(setter.Name)(value[0]);

    object IDynamicContractMessenger.InvokeFunction(MethodBase method) 
        => delegates.Function(method.Name).DynamicInvoke(method);

    void IDynamicContractMessenger.InvokeAction(MethodBase method) 
        => delegates.Action(method.Name).DynamicInvoke(method);

    string IDynamicContractMessenger.ImplementationName 
        => implementationName;
}
