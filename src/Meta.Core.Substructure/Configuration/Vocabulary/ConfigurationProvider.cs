//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

/// <summary>
/// Specifies default <see cref="IConfigurationProvider"/> implementation
/// </summary>
public class ConfigurationProvider : IConfigurationProvider    
{

    public static IConfigurationProvider FromFunction(Func<string, object> f)
        => new ConfigurationProvider(f);

    public static IConfigurationProvider FromFunction(Func<IDictionary<string,object>> f)
        => new ConfigurationProvider(f);

    public static IConfigurationProvider FromDictionary(IDictionary<string,object> settings)
        => new ConfigurationProvider(() => settings);

    public static IConfigurationProvider FromValue(object value)
        => new ConfigurationProvider(value);

    public static IConfigurationProvider Default()
        => FromDictionary(new Dictionary<string, object>());

    /// <summary>
    /// Defines a configuration set based on values obtained from a function dictionary delegate
    /// </summary>
    /// <param name="ComponentName"></param>
    /// <param name="SettingDictionaryProvider"></param>
    public ConfigurationProvider(Func<IDictionary<string, object>> SettingDictionaryProvider)
    {
        this.ComponentName = string.Empty;
        this.SettingDictionaryProvider = SettingDictionaryProvider;
        this.SettingProvider = name => SettingDictionaryProvider().TryFind(name).ValueOrDefault();
    }

    public ConfigurationProvider(Func<string,object> SettingProvider)
    {
        this.ComponentName = string.Empty;
        this.SettingProvider = SettingProvider;
        this.SettingDictionaryProvider 
            = () => new Dictionary<string, object>();
    }

    public ConfigurationProvider(object ObjectSettingProvider)
    {
        this.ComponentName = string.Empty;
        var osp = ObjectSettingProvider ?? this;
        var propidx = (osp.GetType().GetPublicProperties(true).Select(p => (p.Name, p)))
                                    .ToReadOnlyDictionary();
        this.SettingProvider = name => propidx.TryFind(name).Map(p => p.GetValue(osp)).ValueOrDefault();

        this.SettingDictionaryProvider = () => new Dictionary<string, object>();
    }

    public string EnvironmentName
        => SystemNode.Local.NodeName; //EnvironmentVariables.SystemNode;

    public string ComponentName { get; }

    Func<string, object> SettingProvider { get; }

    Func<IDictionary<string, object>> SettingDictionaryProvider { get; }

    T IConfigurationProvider.GetSetting<T>(string settingName)
        => (T)SettingProvider(settingName);

    IReadOnlyDictionary<string, object> IConfigurationProvider.GetSettings()
        => SettingDictionaryProvider().ToReadOnlyDictionary();

    bool IConfigurationProvider.HasSetting(string settingName)
        => !(SettingProvider(settingName) is null);

    T IConfigurationProvider.PutSetting<T>(string settingName, T value, string description)
    {
        SettingDictionaryProvider()[settingName] = value;
        return value;
    }

    void IConfigurationProvider.PutSettings(IReadOnlyDictionary<string, object> settings)
        => throw new NotSupportedException();
}

public abstract class ConfigurationProvider<C> : ConfigurationProvider
    where C : ConfigurationProvider<C>
{

    protected ConfigurationProvider()
        : base(typeof(C).Name)
    {

    }
}