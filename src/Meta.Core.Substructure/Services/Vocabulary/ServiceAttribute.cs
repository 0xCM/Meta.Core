//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Applied to a service implementation to identify it and the contracts it realizes
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ServiceAttribute : Attribute
{

    public ServiceAttribute(Type contractType, string implementationName)
    {
        this.ContractTypes = new[] { contractType };
        this.ImplementationName = implementationName;
    }

    public ServiceAttribute(params Type[] contractTypes)
    {
        this.ContractTypes = contractTypes;
        this.ImplementationName = "Default";
    }

    public ServiceAttribute(Type contractType)
        : this(contractType, "Default")
    { }

    public Type[] ContractTypes { get; set; }

    public string ImplementationName { get; set; }
}

    
