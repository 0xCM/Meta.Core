//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines contract for configuration-related persistence operations
/// </summary>
public interface IConfigurationStore
{
    IEnumerable<ComponentSetting> GetComponentSettings(string environment, string component);

    void SaveComponentSettings(IEnumerable<ComponentSetting> settings);

    IConfigurationProvider CreateConfigurationProvider(string environment, string componnent);

    void CopyComponentSettings(string environment, string component, IConfigurationStore target);
}



