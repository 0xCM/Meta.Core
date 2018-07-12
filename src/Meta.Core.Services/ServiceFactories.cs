//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public static class ServiceFactories
    {

        public static IFileMonitor FileMonitorAgent(this IApplicationContext C)
            => C.NodeContext(SystemNode.Local).Agent<IFileMonitor>(Meta.Core.FileMonitorAgent.AgentId);

        public static ILocalCommandStore LocalCommandStore(this IApplicationContext C, 
                FolderPath StorgeRoot, 
                Action<FilePath, ICommandSpec> Processor = null,
                Action<IAppMessage> Observer = null)
                    => new LocalCommandStore(C, StorgeRoot, Processor, Observer);

        public static IFileArchiveManager FileArchiveManager(this IApplicationContext C)
            => C.Service<IFileArchiveManager>();

        public static IIconStore IconStore(this IApplicationContext C)
            => C.Service<IIconStore>();

        public static ISysOpProvider SysOpProvider(this IApplicationContext C)
            => C.Service<ISysOpProvider>();


    }
}
