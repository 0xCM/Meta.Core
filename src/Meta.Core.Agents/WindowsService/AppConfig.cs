//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
#if NetFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Reflection;

/// <summary>
/// Changes the app.config at runtime 
/// </summary>
/// <remarks>
/// See http://stackoverflow.com/questions/6150644/change-default-app-config-at-runtime
/// </remarks>
public abstract class AppConfig : IDisposable
{
    /// <summary>
    /// Activates the identified configuration file
    /// </summary>
    /// <param name="path">The path to the file that specifies the new configuration</param>
    /// <returns></returns>
    public static AppConfig Change(string path)
    {
        return new ChangeAppConfig(path);
    }

    public abstract void Dispose();

    /// <summary>
    /// Nested realization of declaring type for purposes of both amusement and encapsulation
    /// </summary>
    class ChangeAppConfig : AppConfig
    {
        private readonly string oldConfig =
            AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();

        private bool disposedValue;

        public ChangeAppConfig(string path)
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path);
            ResetConfigMechanism();
        }

        public override void Dispose()
        {
            if (!disposedValue)
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", oldConfig);
                ResetConfigMechanism();


                disposedValue = true;
            }
            GC.SuppressFinalize(this);
        }

        static void ResetConfigMechanism()
        {
            typeof(ConfigurationManager)
                .GetField("s_initState", BindingFlags.NonPublic |
                                            BindingFlags.Static)
                .SetValue(null, 0);

            typeof(ConfigurationManager)
                .GetField("s_configSystem", BindingFlags.NonPublic |
                                            BindingFlags.Static)
                .SetValue(null, null);

            typeof(ConfigurationManager)
                .Assembly.GetTypes()
                .Where(x => x.FullName ==
                            "System.Configuration.ClientConfigPaths")
                .First()
                .GetField("s_current", BindingFlags.NonPublic |
                                        BindingFlags.Static)
                .SetValue(null, null);
        }
    }
}

#endif