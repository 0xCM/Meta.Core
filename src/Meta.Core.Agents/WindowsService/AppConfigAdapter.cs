//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
#if NetFramework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Configuration;

public abstract class AppConfigAdapter
{
    protected static string GetThisSetting([CallerMemberName] string name = null)
        => ConfigurationManager.AppSettings[name];

    protected static T GetThisSetting<T>([CallerMemberName] string name = null)
        => (T)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(T));
}
#endif