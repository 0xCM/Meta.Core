//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
#if NetFramework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

/// <summary>
/// Provides realization of <see cref="IConfigurationProvider"/> contract using the
/// App.config file as a backing store
/// </summary>
public sealed class AppSettings : IConfigurationProvider
{
    public static AppSettings Get()
        => new AppSettings();

    static string GetConfiguredSetting(string name)
        => Script.SpecifyEnvironmentParameters(ConfigurationManager.AppSettings[name]);

    public AppSettings()
    {
        environment = ConfigurationManager.AppSettings["EnvironmentName"];
        component = ConfigurationManager.AppSettings["ComponentName"];
    }

    string environment { get; }

    string component { get; }

    public string ComponentName
        => component;

    public string EnvironmentName 
        => environment;

    bool HasSetting(string settingName) 
        => ConfigurationManager.AppSettings.AllKeys.Contains(settingName);

    T IConfigurationProvider.PutSetting<T>(string settingName, T value, string description)         
        => value; //Ignore save directive

    T IConfigurationProvider.GetSetting<T>(string settingName) 
        => HasSetting(settingName) 
        ? (T)Convert.ChangeType(GetConfiguredSetting(settingName), typeof(T))
        : default(T);

    bool IConfigurationProvider.HasSetting(string settingName) 
        => HasSetting(settingName);

    string IConfigurationProvider.ComponentName 
        => ComponentName;

    IReadOnlyDictionary<string, object> IConfigurationProvider.GetSettings()
    {
        var settings = new Dictionary<string, object>();
        foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            settings[key] = GetConfiguredSetting(key);
        return settings;
    }

    void IConfigurationProvider.PutSettings(IReadOnlyDictionary<string, object> settings) { }
}

#endif