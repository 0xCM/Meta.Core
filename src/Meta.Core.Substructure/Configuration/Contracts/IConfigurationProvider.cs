//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides access to configuration parameters in a manner that occludes the manner
/// in which configuration settings are stored/retrieved. 
/// </summary>
public interface IConfigurationProvider
{
    /// <summary>
    /// Gets the value of the specified setting if specified and otherwise fails
    /// </summary>
    /// <typeparam name="T">The setting type</typeparam>
    /// <param name="settingName">The setting name</param>
    /// <returns></returns>
    T GetSetting<T>(string settingName);

    /// <summary>
    /// Persists the value of the specified setting, if supported by the provider
    /// </summary>
    /// <typeparam name="T">The setting type</typeparam>
    /// <param name="settingName">The setting name</param>
    /// <param name="value">The value</param>
    /// <param name="description">Explains the purpose of the setting</param>
    T PutSetting<T>(string settingName, T value, string description = null);
    
    /// <summary>
    /// Determines whether an identified setting is specified
    /// </summary>
    /// <param name="settingName">The name of the setting</param>
    /// <returns></returns>
    bool HasSetting(string settingName);

    /// <summary>
    /// Specifies the environment for which the configuration is being provided
    /// </summary>
    string EnvironmentName { get; }

    /// <summary>
    /// Specifies the component for which the configuration is being provided
    /// </summary>
    string ComponentName { get; }

    /// <summary>
    /// Retrieves all settings from the provider
    /// </summary>
    /// <returns></returns>
    IReadOnlyDictionary<string, object> GetSettings();

    /// <summary>
    /// Saves the specified settings
    /// </summary>
    /// <param name="settings"></param>
    void PutSettings(IReadOnlyDictionary<string, object> settings);
}

   