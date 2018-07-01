//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System.Reflection;

/// <summary>
/// Defines communication channel between application code and dynamically generated IL
/// </summary>
/// <remarks>
/// This interface is defined without overloaded methods or other aspects that would
/// make IL interop more troublesome
/// </remarks>
public interface IDynamicContractMessenger
{
    /// <summary>
    /// Sends a 0-argument function invocation through the channel
    /// </summary>
    /// <param name="method">The method to invoke</param>
    /// <returns></returns>
    object InvokeFunction(MethodBase method);

    /// <summary>
    /// Sends an n-argument function invocation through the channel and returns the result
    /// </summary>
    /// <param name="method">The method to invoke</param>
    /// <returns></returns>
    object InvokeFunctionWithParameters(MethodBase method, object[] parameters);

    /// <summary>
    /// Send a 0-argument action invocation through the channel
    /// </summary>
    /// <param name="method">The method to invoke</param>
    void InvokeAction(MethodBase method);

    /// <summary>
    /// Send an n-argument action invocation through the channel
    /// </summary>
    /// <param name="method">The method to invoke</param>
    void InvokeActionWithParameters(MethodBase method, object[] parameters);

    /// <summary>
    /// Retrieves the value of a property through the channel
    /// </summary>
    /// <param name="getter">The get accessor</param>
    /// <returns></returns>
    object GetPropertyValue(MethodBase getter);

    /// <summary>
    /// Sets the vale of a property through the channel
    /// </summary>
    /// <param name="setter">The set accessor</param>
    /// <param name="value">The value to send</param>
    void SetPropertyValue(MethodBase setter, object[] value);

    /// <summary>
    /// The name of the contract implementation
    /// </summary>
    string ImplementationName { get; }
}
