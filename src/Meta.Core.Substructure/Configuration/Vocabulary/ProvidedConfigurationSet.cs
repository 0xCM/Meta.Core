//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

using static minicore;

/// <summary>
/// Implements a <see cref="IConfigurationProvider"/>
/// </summary>
public sealed class ProvidedConfigurationSet : IConfigurationProvider
{    

    public ProvidedConfigurationSet(IEnumerable<ConfigurationSetting> settings)
        => SettingsIndex = settings.ToDictionary(x => x.Name, x => x.Value).ToConcurrentDictionary();

    public ProvidedConfigurationSet(IReadOnlyDictionary<string,object> settings)
        => SettingsIndex = new ConcurrentDictionary<string, object>(settings);

    ConcurrentDictionary<string, object> SettingsIndex { get; }

    string Environment { get; }
        = String.Empty;

    string Component { get; }
        = String.Empty;

    string IConfigurationProvider.ComponentName 
        => Component;

    string IConfigurationProvider.EnvironmentName 
        => Environment;

    T IConfigurationProvider.PutSetting<T>(string settingName, T value, string description)
    {
        SettingsIndex.AddOrUpdate(settingName, value, (_, __) => value);
        return value;
    }

    void IConfigurationProvider.PutSettings(IReadOnlyDictionary<string, object> settings)
    {
        foreach (var setting in settings)
            SettingsIndex.AddOrUpdate(setting.Key, setting.Value, (_, __) => setting.Value);
    }

    IReadOnlyDictionary<string, object> IConfigurationProvider.GetSettings()
        => SettingsIndex.ToReadOnlyDictionary();

    T IConfigurationProvider.GetSetting<T>(string settingName)
    {
        var value = SettingsIndex.TryFind(settingName).OnNone(() =>
        {
            throw new ArgumentException($"The setting {settingName} is unspecified");
        }).Require();        
        return convert<T>(value);
    }

    bool IConfigurationProvider.HasSetting(string settingName)
        => SettingsIndex.ContainsKey(settingName);    
}