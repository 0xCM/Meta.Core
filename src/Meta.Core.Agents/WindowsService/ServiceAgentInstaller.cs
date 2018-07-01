//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
#if NetFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;


partial class designer_begone { }
  
[RunInstaller(true)]
public class ServiceAgentInstaller : Installer
{


    public ServiceAgentInstaller()
    {
        var settings = new ServiceAgentSettings();
        this.processInstaller = new ServiceProcessInstaller();
        this.serviceInstaller = new ServiceInstaller();
        this.processInstaller.Account = settings.Account;
        this.processInstaller.Password = settings.ServiceAccountPassword;
        this.processInstaller.Username = settings.ServiceAccountUser;
        this.serviceInstaller.Description = settings.ServiceDescription;
        this.serviceInstaller.ServiceName = settings.ServiceName;
        this.serviceInstaller.StartType = settings.ServiceStartMode;
        this.Installers.AddRange(new Installer[] {
    this.processInstaller,
    this.serviceInstaller});

    }

    ServiceProcessInstaller processInstaller;
    ServiceInstaller serviceInstaller;
}
#endif