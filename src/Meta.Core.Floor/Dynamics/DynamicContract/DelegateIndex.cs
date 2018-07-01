//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Indexes a collection of delegates that (potentially) specify a <see cref="IDynamicContractMessenger"/> realization
/// </summary>
public class DelegateIndex
{
    public static DelegateIndexBuilder<T> Build<T>() 
        => new DelegateIndexBuilder<T>();

    public DelegateIndex()
    {
    }

    IDictionary<string, Delegate> functions { get; }
        = new Dictionary<string, Delegate>();

    IDictionary<string, Delegate> actions { get; }
        = new Dictionary<string, Delegate>();

    IDictionary<string, Func<object>> getters { get; }
        = new Dictionary<string, Func<object>>();

    IDictionary<string, Action<object>> setters { get; }
        = new Dictionary<string, Action<object>>();

    /// <summary>
    /// Indexes a property get method
    /// </summary>
    /// <typeparam name="T">The property type</typeparam>
    /// <param name="name">The name of the property get method</param>
    /// <param name="f">The get delegate</param>
    public void Getter<T>(string name, Func<T> f) 
        => getters.Add(name, () => f());

    /// <summary>
    /// Retrieves a property get method
    /// </summary>
    /// <param name="name">The name of the get method</param>
    /// <returns></returns>
    public Func<object> Getter(string name) 
        => getters[name];

    /// <summary>
    /// Specifies a property setter
    /// </summary>
    /// <typeparam name="T">The property type</typeparam>
    /// <param name="name">The name of the property set method</param>
    /// <param name="a">The set action</param>
    public void Setter<T>(string name, Action<T> a) 
        => setters.Add(name, (x) => a((T)x));

    /// <summary>
    /// Retrieves named property set method
    /// </summary>
    /// <param name="name">The name of the get method</param>
    /// <returns></returns>
    public Action<object> Setter(string name) 
        => setters[name];

    /// <summary>
    /// Specifies a function delegate
    /// </summary>
    /// <param name="name">The method</param>
    /// <param name="f">The delegate</param>
    public void Function(string name, Delegate f) 
        => functions.Add(name, f);

    /// <summary>
    /// Specifies an action delegate
    /// </summary>
    /// <param name="name">The name of the action</param>
    /// <param name="a">The action</param>
    public void Action(string name, Delegate a) 
        => actions.Add(name, a);

    /// <summary>
    /// Retrieves an action delegate
    /// </summary>
    /// <param name="name">The name of the action</param>
    /// <returns></returns>
    public Delegate Action(string name) 
        => actions[name];

    /// <summary>
    /// Retrieves a function delegate
    /// </summary>
    /// <param name="name">The name of the function</param>
    /// <returns></returns>
    public Delegate Function(string name) 
        => functions[name];
}

