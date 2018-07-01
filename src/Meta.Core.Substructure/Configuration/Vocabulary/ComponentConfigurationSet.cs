//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Encapsulates the settings for a component in a way that can be
/// easily export, imported or otherwise managed as a single entity
/// </summary>
public class ComponentConfigurationSet
{
    /// <summary>
    /// The name of the environment to which the configuration applies
    /// </summary>
    public string Environment { get; set; }

    /// <summary>
    /// The name of the component to which the configuration applies
    /// </summary>
    public string Component { get; set; }

    /// <summary>
    /// The settings included in the set
    /// </summary>
    public List<ComponentSetting> Settings { get; set; }
}
