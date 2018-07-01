//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Defines configuration settings for the <see cref="IFileMonitor"/> service
    /// </summary>
    public class FileMonitorSettings : ServiceAgentSettings<FileMonitorSettings>
    {
        public static readonly AgentIdentifier AgentId 
            = FileMonitorAgent.AgentIdentifier;

        public FileMonitorSettings(IConfigurationProvider Configuration)
            : base(Configuration, FileMonitorAgent.AgentId)
        {

        }

        public IEnumerable<FolderPath> ObservedFolders
            => GetThisSetting(stream<FolderPath>());
    }

}