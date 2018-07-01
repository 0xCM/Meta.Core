//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

/// <summary>
/// Defines contract for service resolution
/// </summary>
public interface IServiceProvider : System.IServiceProvider
{
    /// <summary>
    /// Retrieves a named service implementation
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="Implementor"></param>
    /// <returns></returns>
    T GetService<T>(string Implementor);

    /// <summary>
    /// Retrieves the default service implementation, if any; otherwise returns the first service
    /// found that matches the contract
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <returns></returns>
    T GetService<T>();

    /// <summary>
    /// Retrieves, if possible, the default implemention of the identified service
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <returns></returns>
    Option<T> TryGetService<T>();


    /// <summary>
    /// Identifies all known services
    /// </summary>
    /// <returns></returns>
    IEnumerable<ServiceDesignator> IdentifyServices();

    /// <summary>
    /// Identifies all known services that implement a specified contract
    /// </summary>
    /// <returns></returns>
    IEnumerable<ServiceDesignator> IdentifyServices<C>();

    /// <summary>
    /// Registers service implementations in aan assembly
    /// </summary>
    /// <param name="assembly"></param>
    void RegisterImplementations(Assembly assembly);

    /// <summary>
    /// Registers a service instance with the provider
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="designator">Identifies the service to be registered</param>
    /// <param name="instance">The instance to regiser</param>
    void RegisterInstance<T>(ServiceDesignator designator, T instance);

    /// <summary>
    /// Replaces an existing service instance with another
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="designator">Identifies the service to be replace</param>
    /// <param name="instance">The replacing instance</param>
    void ReplaceInstance<T>(ServiceDesignator designator, T instance);

    /// <summary>
    /// Determines whether the provider is capable of yielding a conforming contract
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="Implementor">The name of the implementation</param>
    /// <returns></returns>
    bool IsServiceProvided<T>(string Implementor = Defaults.Name);

    /// <summary>
    /// Determines whether the provider is capable of yielding a conforming contract
    /// </summary>
    /// <param name="Implementor">The name of the implementation</param>
    /// <returns></returns>
    bool IsServiceProvided(Type ContractType, string Implementor);

    /// <summary>
    /// Retreives the identified service if possible, otherwise NONE
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="Implementor">The name of the implementation</param>
    /// <returns></returns>
    Option<T> TryGetService<T>(string Implementor = Defaults.Name);

    /// <summary>
    /// Retrieves all services realizing the secified contract type 
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <returns></returns>
    IEnumerable<T> GetServices<T>();
}

