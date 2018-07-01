//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public delegate object ServiceFactory(IApplicationContext context);

public delegate T ServiceFactory<out T>(IApplicationContext context);

/// <summary>
/// Applied to a service implementation to identify a factory that can create instances of the service
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ServiceFactoryAttribute : Attribute
{

    /// <summary>
    /// Initializes a new <see cref="ServiceFactoryAttribute"/> instance
    /// </summary>
    /// <param name="host">The type on which the factory method is declared</param>
    /// <param name="method">The name of the factory method</param>
    public ServiceFactoryAttribute(Type host, string method)
    {
        this.HostType = host;
        this.FactoryMethod = method;
    }
    /// <summary>
    /// Specifies the type on which the factory method is declared
    /// </summary>
    public Type HostType { get; }
    /// <summary>
    /// Specifies the name of the factory method
    /// </summary>
    public string FactoryMethod { get; }
}



