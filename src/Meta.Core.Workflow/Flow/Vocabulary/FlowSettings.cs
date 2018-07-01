//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{   
    /// <summary>
    /// Defines settings that can be used to customize the execution of a transformation
    /// </summary>
    public class FlowSettings : ProvidedConfiguration<FlowSettings>
    {

        public FlowSettings(IConfigurationProvider configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// The number of milliseconds to pause between full-queue checks
        /// </summary>
        [ComponentSetting("The number of milliseconds to pause between full-queue checks")]
        public int PullPause
            => GetThisSetting<int>(250, true);

        /// <summary>
        /// The number of milliseconds to pause between sorce->target pushes
        /// </summary>
        [ComponentSetting("The number of milliseconds to pause between sorce->target pushes")]
        public int PushPause
            => GetThisSetting<int>(250, true);

        /// <summary>
        /// The maximum number of records included in a workflow unit-of-work
        /// </summary>
        [ComponentSetting("The maximum number of records included in a workflow unit-of-work")]
        public int DefaultBatchSize
            => GetThisSetting<int>(50000, true);

        /// <summary>
        /// The number of milliseconds to pause between source selections
        /// </summary>
        [ComponentSetting("The number of milliseconds to pause between source selections")]
        public int SelectCycleCheckFrequency
            => GetThisSetting<int>(DefaultBatchSize * 2, true);

        /// <summary>
        /// The maximum number of records allowed to collect in the source queue before suspending the selection and enqueing activity
        /// </summary>
        [ComponentSetting("The maximum number of records allowed to collect in the source queue before suspending the selection and enqueing activity")]
        public int MaxSourceQueueLength
            => GetThisSetting<int>(DefaultBatchSize * 5, true);

        /// <summary>
        /// The maximum number of items removed from the source queue in one cycle
        /// </summary>
        [ComponentSetting("The maximum number of items removed from the source queue in one cycle")]
        public int MaxSourceReadSize
            => GetThisSetting<int>(DefaultBatchSize * 2, true);


        /// <summary>
        /// Determines whether the operations within the transformation are permitted to execute concurrently
        /// </summary>
        [ComponentSetting("Determines whether the operations within the transformation are permitted to execute concurrently")]
        public bool ParallelExecution
            => GetThisSetting(true, true);

        /// <summary>
        /// The maximum number of seconds to wait before abandoning an attempt to emit transformed source records to the target
        /// </summary>
        [ComponentSetting("The maximum number of seconds to wait before abandoning an attempt to emit transformed source records to the target")]
        public int EmitTimeout
            => GetThisSetting(1200, true);


    }

}
