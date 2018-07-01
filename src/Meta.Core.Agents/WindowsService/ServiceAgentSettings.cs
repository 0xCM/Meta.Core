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
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;

class ServiceAgentSettings
{
    private static T GetThisSetting<T>([CallerMemberName] string memberName = "")
    {
        var value = default(T);
        var setting = ConfigurationManager.AppSettings[$"/App/{memberName}"];
        if (!String.IsNullOrWhiteSpace(setting))
        {
            value = (T)Convert.ChangeType(setting, typeof(T));
        }
        return value;
    }

    readonly string AgentBaseRuntimeFolderDefault;
    public ServiceAgentSettings()
    {
        var serviceFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var agentFolder = Path.Combine(serviceFolder, @"agents\");
        if (!Directory.Exists(agentFolder))
            agentFolder = serviceFolder;

        AgentBaseRuntimeFolderDefault = agentFolder;
    }

    public ServiceAccount Account
        => (ServiceAccount)Enum.Parse(typeof(ServiceAccount), GetThisSetting<string>());

    public string ServiceAccountPassword
        => GetThisSetting<string>();

    public string ServiceAccountUser
        => GetThisSetting<string>();

    public string ServiceDescription
        => GetThisSetting<string>();

    public string ServiceName
        => GetThisSetting<string>();

    public ServiceStartMode ServiceStartMode
        => (ServiceStartMode)Enum.Parse(typeof(ServiceStartMode), GetThisSetting<string>());
    public string AgentBaseRuntimeFolder =>
        String.IsNullOrWhiteSpace(GetThisSetting<string>())
        ? AgentBaseRuntimeFolderDefault
        : GetThisSetting<string>();

    public IEnumerable<string> AgentIdentifiers
        => GetThisSetting<string>().Split(',');

}
#endif