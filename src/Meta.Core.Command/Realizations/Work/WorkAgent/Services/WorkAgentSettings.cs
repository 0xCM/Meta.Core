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
    using System.Text;
    using System.Threading.Tasks;

    public class WorkAgentSettings : ProvidedConfiguration<WorkAgentSettings>
    {
        public WorkAgentSettings(IConfigurationProvider configuration)
            : base(configuration)
        {

        }

        /// <summary>
        /// The maximum number of tasks from a given partition that can execute concurrently
        /// </summary>
        /// <remarks>
        /// For example, if the limit is set to 5, each partition in the queue will be limited
        /// to 5 concurrent tasks. So, if there are 3 partitions then a total of 15 tasks can
        /// execute concurrently.
        /// </remarks>
        [ComponentSetting("The maximum number of tasks from a given partition that can execute concurrently")]
        public int PartitionTaskLimit
            => GetThisSetting<int>(5);

        [ComponentSetting("After cancellation has been requested, the maximum number of seconds to wait for currently executing tasks to finish before forcing cancellation")]
        public int CancellationTimeout
            => GetThisSetting<int>(60000);

        [ComponentSetting("The number of milliseconds to wait between empty queue checks")]
        public int SpinDelay
            => GetThisSetting<int>(1000);

        [ComponentSetting("Specifies whether to eliminate or restrict concurrency to facilitate debugging")]
        public bool DiagnosticMode
            => GetThisSetting(false);
    }


}