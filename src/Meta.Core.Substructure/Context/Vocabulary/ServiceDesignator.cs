//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


/// <summary>
/// Identifies a service implementation
/// </summary>
public readonly struct ServiceDesignator : IEquatable<ServiceDesignator>
{
    [DebuggerStepThrough]
    public ServiceDesignator(Type contractType, string implementationName)
    {
        if (implementationName == null)
            throw new ArgumentNullException(nameof(implementationName));

        this.ContractType = contractType;            
        this.ImplementationName = implementationName;
    }

    [DebuggerStepThrough]
    public ServiceDesignator(Type contractType)
        : this(contractType, "Default")
    {
    }

    public string ImplementationName { get; }

    public Type ContractType { get;}

    public override string ToString() 
        => $"{ContractType.Name} : {ImplementationName}";

    public bool Equals(ServiceDesignator other)
        => other.ContractType == ContractType
        && this.ImplementationName == other.ImplementationName;

    public override int GetHashCode()
        => ToString().GetHashCode();

    public override bool Equals(object obj)
        => obj is ServiceDesignator 
        ? Equals((ServiceDesignator)obj) : false;
}

