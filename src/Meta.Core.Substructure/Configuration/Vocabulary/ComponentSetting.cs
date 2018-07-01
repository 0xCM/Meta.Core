//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// Specifies the value of a component setting within a specific environment
/// </summary>
public sealed class ComponentSetting  : ValueObject<ComponentSetting>
{
    /// <summary>
    /// Identifies the component's environment
    /// </summary>
    public readonly string Environment;
        
    /// <summary>
    /// Identifies the component to which the configuration applies
    /// </summary>
    public readonly string Component;
        
    /// <summary>
    /// The name of the configuration setting
    /// </summary>
    public readonly string SettingName;
        
    /// <summary>
    /// The setting value determined by the intersection of environment, component and setting name
    /// </summary>
    public readonly object SettingValue;

    /// <summary>
    /// Describes the purpose of the setting
    /// </summary>
    public readonly string SettingDescription;


    /// <summary>
    /// Initializes a new <see cref="ComponentSetting"/> instance
    /// </summary>
    /// <param name="Environment">Identifies the component's environment</param>
    /// <param name="Component">Identifies the component to which the configuration applies</param>
    /// <param name="SettingName">The name of the configuration setting</param>
    /// <param name="SettingValue">The setting value determined by the intersection of environment, component and setting name</param>
    /// <param name="SettingDescription">Describes the purpose of the setting</param>
    public ComponentSetting
        (
            string Environment,
            string Component,
            string SettingName,
            object SettingValue,
            string SettingDescription
        )
    {
        this.Environment = Environment;
        this.Component = Component;
        this.SettingName = SettingName;
        this.SettingValue = SettingValue;
        this.SettingDescription = SettingDescription;
    }
}


