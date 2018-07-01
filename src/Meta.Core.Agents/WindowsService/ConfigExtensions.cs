//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Meta.Core;

public static class AppConfigExtensions
{
    /// <summary>
    /// Gets the runtime environment for the process
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <returns></returns>
    public static Option<RuntimeEnvironment> CurrentEnvironment(this IApplicationContext C)
        => RuntimeEnvironments.TryFind(x => x.Name == C.EnvironmentName);

    public static IMutableContext WithConfigurationProvider(this IMutableContext C, IConfigurationProvider provider)
    {
        //was AppSettings
        C.InjectService<IConfigurationProvider>(provider);
        return C;
    }

    public static T GetSetting<T>(this IConfigurationProvider config, string settingName, T defaultValue = default(T))
        => config.HasSetting(settingName) ? config.GetSetting<T>(settingName) : defaultValue;

}