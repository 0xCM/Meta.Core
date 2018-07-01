//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using static minicore;

public abstract class ProvidedConfiguration<C> : IProvidedConfiguration
    where C : ProvidedConfiguration<C>
{
    static readonly IReadOnlyDictionary<string, PropertyInfo> Properties
        = typeof(C).GetProperties().ToDictionary(x => x.Name);


    public static ConfigurationBuilder<C> FromBuilder(C init)
        => new ConfigurationBuilder<C>(init.EnvironmentName, init.ComponentName, init);

    public static ConfigurationBuilder<C> FromBuilder(string Environment, string Component, C init)
        => new ConfigurationBuilder<C>(Environment, Component, init);

    public static ConfigurationBuilder<C> FromBuilder(string Environment, string Component)
        => new ConfigurationBuilder<C>(Environment, Component);

    public static C FromProvider(IConfigurationProvider Provider)
        => (C)Activator.CreateInstance(typeof(C), Provider);

    public static C FromSettingsIndex(IReadOnlyDictionary<string, object> settings)
        => FromProvider(new ProvidedConfigurationSet(settings));

    public static C FromSettings(IEnumerable<ConfigurationSetting> settings)
        => FromProvider(new ProvidedConfigurationSet(settings));

    protected readonly IConfigurationProvider Provider;

    protected ProvidedConfiguration(IConfigurationProvider Provider)
    {
        this.Provider = Provider;
    }


    protected virtual string AlternateGroupName
        => String.Empty;


    protected virtual string SubComponentName
        => String.Empty;


    protected string GetSettingName(string propname)
    {
        var defaultGroupName = (GetType().GetProperty(propname)?.DeclaringType ?? GetType())
                               .Name
                               .Replace("Settings", String.Empty)
                               .Replace("`1", String.Empty);

        var groupName = isBlank(AlternateGroupName) ? defaultGroupName : AlternateGroupName;

        if (isBlank(groupName))
        {
            return isBlank(SubComponentName)
                   ? $"/{propname}"
                   : $"/{SubComponentName}/{propname}";
        }
        else
        {
            return isBlank(SubComponentName)
                   ? $"/{groupName}/{propname}"
                   : $"/{SubComponentName}/{groupName}/{propname}";

        }



    }


    protected virtual string GetBaseConfigurationName(string PropertyName)
        => ProvidedConfiguration.GetBaseConfigurationName(GetType(), PropertyName);


    protected T GetSetting<T>(string settingName)
        => Provider.GetSetting<T>(settingName);


    protected T GetThisSetting<T>(T defaultValue, bool persistDefault = false, [CallerMemberName] string propname = "")
    {
        var settingName = GetSettingName(propname);
        if (Provider.HasSetting(settingName))
        {
            return GetSetting<T>(settingName);
        }
        else
        {
            if (persistDefault)
            {
                var prop = GetType().GetProperty(propname);
                var doc = prop?.GetCustomAttribute<ComponentSettingAttribute>()?.Documentation;
                Provider.PutSetting(settingName, defaultValue, doc);
            }
            return defaultValue;
        }

    }

    protected T ProvidedSetting<T>([CallerMemberName] string caller = "")
        => Provider.HasSetting(caller)
        ? Provider.GetSetting<T>(caller)
        : default(T);

    //public void PutSetting<T>(Expression<Func<object, T>> selector, T value)
    //    => Provider.PutSetting(selector.GetMember().Name, value);

    protected void PutThisSetting<T>(T value, [CallerMemberName] string propname = "")
    {
        var settingName = GetSettingName(propname);
        var prop = GetType().GetProperty(propname);
        var doc = prop?.GetCustomAttribute<ComponentSettingAttribute>()?.Documentation;
        Provider.PutSetting(settingName, value, doc);
    }

    /// <summary>
    /// Returns the value if present, otherwise none.
    /// </summary>
    /// <typeparam name="T">The type of value to retrieve</typeparam>
    /// <param name="propname">The name of the caller</param>
    /// <returns></returns>
    protected Option<T> TryGetThisSetting<T>([CallerMemberName] string propname = "")
    {
        var settingName = GetSettingName(propname);
        if (Provider.HasSetting(settingName))
            return GetSetting<T>(settingName);
        else
            return none<T>();

    }


    /// <summary>
    /// The name of the environment to which the configuration applies
    /// </summary>
    public string EnvironmentName
        => Provider.EnvironmentName;

    /// <summary>
    /// The name of the component to which the configuration applies
    /// </summary>
    public string ComponentName
        => Provider.ComponentName;

    public IEnumerable<ConfigurationSetting> GetNamedSettings()
        => Provider.GetSettings().Select(kvp => new ConfigurationSetting(kvp.Key, kvp.Value, String.Empty));

    /// <summary>
    /// Gets the settings accessible via property accessors in the most-derived subtype
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ConfigurationSetting> GetPropertySettings()
        => Properties.Keys.Select(k 
                => new ConfigurationSetting(k, Properties[k].GetValue(this), String.Empty));
}


public static class ProvidedConfiguration
{

    public static string GetBaseConfigurationName(Type C, string PropertyName)
    {
        var BaseName = (C.GetProperty(PropertyName)?.DeclaringType ?? C.GetType())
                               .Name
                               .Replace("Settings", String.Empty)
                               .Replace("`1", String.Empty);
        return BaseName;
    }

    public static string GetSettingName<C>(string PropertyName)
    {
        var BaseName = GetBaseConfigurationName(typeof(C), PropertyName);
        return isBlank(BaseName) ? $"/{PropertyName}" : $"/{BaseName}/{PropertyName}";
    }
}
