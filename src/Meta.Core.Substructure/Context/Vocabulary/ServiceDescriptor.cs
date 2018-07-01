//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



/// <summary>
/// Describes an application service
/// </summary>
public sealed class ServiceDescriptor
{
    

    public ServiceDescriptor(Type Implementor, params Type[] Contracts)
    {
        
        if (Contracts.Length == 0)
            throw new ArgumentException($"A service must support at least 1 contract");

        if (Implementor.IsAbstract)
            throw new ArgumentException($"The supposed implementation type {Implementor} is abstract");

        foreach(var c in Contracts)
        {
            if (!c.IsInterface && !c.IsDelegate())
                throw new ArgumentException($"Contract type must be either a delegate or interface");
        }

        var attrib = Implementor.GetCustomAttribute<ApplicationServiceAttribute>();
        this.implementationName = attrib?.ImplementationName ?? "Default";
        this.implementor = Implementor;
        this.contracts = Contracts.ToList();

    }

    public ServiceDescriptor(Type Implementor, string ImplementationName, params Type[] Contracts)
        : this(Implementor, Contracts)
    {
        this.implementationName = ImplementationName ?? "Default";
    }

    Type implementor { get; }

    IReadOnlyList<Type> contracts { get; }

    string implementationName { get; }

    public Type ImplementationType
        => implementor;

    public string ImplementationName
        => implementationName;

    public IReadOnlyList<Type> Contracts
        => contracts;

    public bool IsDefaultImplementation
        => ImplementationName == "Default";

    public bool SupportsContract<T>()
        => Contracts.Contains(typeof(T));

    public override string ToString()
        => $"{contracts.First().Name.ToString()} ({ImplementationName})";


}

