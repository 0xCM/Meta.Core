//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// Provides capability to construct a concrete <see cref="ProvidedConfiguration{C}"/> for which
/// values are programmatically specified
/// </summary>
/// <typeparam name="C">The configuration under construction</typeparam>
public sealed class ConfigurationBuilder<C> where C : ProvidedConfiguration<C>
{
    /// <summary>
    /// Implicitly completes configuration construction
    /// </summary>
    /// <param name="builder"></param>
    public static implicit operator C(ConfigurationBuilder<C> builder)
        => builder.Finish();

    public ConfigurationBuilder(string Environment, string Component)
    {
        this.Environment = Environment;
        this.Component = Component;
        this.settings = new Dictionary<string, object>();
    }

    public ConfigurationBuilder(string Environment, string Component, C init)
        : this(Environment, Component)
    {
        foreach(var property in typeof(C).GetProperties())
        {
            var value = property.GetValue(init);
            if (value != null)
                settings[ProvidedConfiguration.GetSettingName<C>(property.Name)] = value;
        }
    }

    Dictionary<string, object> settings { get; }

    string Environment { get; }

    string Component { get; }


    ConfigurationBuilder<C> Assign<V>(Expression<Func<C, V>> selector, object value)
    {
        var propname = ((MemberExpression)selector.Body).Member.Name;
        var settingName = ProvidedConfiguration.GetSettingName<C>(propname);
        settings[settingName] = value;
        return this;
    }

    public ConfigurationBuilder<C> Set<V>(Expression<Func<C, V>> selector, string value) 
        => Assign(selector, value);

    public ConfigurationBuilder<C> Set<V>(Expression<Func<C, V>> selector, bool value) 
        => Assign(selector, value);

    public ConfigurationBuilder<C> Set<V>(Expression<Func<C, V>> selector, int value) 
        => Assign(selector, value);

    public ConfigurationBuilder<C> Set<V>(Expression<Func<C, V>> selector, Enum value) 
        => Assign(selector, value);

    public C Finish()
    {
        var provider = new ProvidedConfigurationSet(settings);
        return (C)Activator.CreateInstance(typeof(C), provider);
    }
}
