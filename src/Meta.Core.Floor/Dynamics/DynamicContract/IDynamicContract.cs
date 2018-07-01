//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Defines contract for dynamic operation invocation
/// </summary>
public interface IDynamicContract
{
    /// <summary>
    /// Invokes a function that is identified by and accessed via a <see cref="MethodInfo"/>
    /// </summary>
    /// <param name="method">The contracting method</param>
    /// <param name="parameters">The method parameters</param>
    /// <returns></returns>
    object InvokeFunction(MethodInfo method, object[] parameters);

    /// <summary>
    /// Invokes an action that is identified by and accessed via a <see cref="MethodInfo"/>
    /// </summary>
    /// <param name="method">The contracting method</param>
    /// <param name="parameters">The method parameters</param>
    /// <returns></returns>
    void InvokeAction(MethodInfo method, object[] parameters);

    /// <summary>
    /// Retrieves the value of a property that is indentified by and accessed via a <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    object GetPropertyValue(PropertyInfo property);

    /// <summary>
    /// Sets the value of a property that is indentified by and accessed via a <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    void SetPropertyValue(PropertyInfo property, object value);

    /// <summary>
    /// The name given to identify a particular implementation
    /// </summary>
    string ImplementationName { get; }
}

