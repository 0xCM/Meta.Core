//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public sealed class CommandOrchestrationSettings : ProvidedConfiguration<CommandOrchestrationSettings>
{
    public CommandOrchestrationSettings(IConfigurationProvider configuration)
        : base(configuration)
    {
    }

    /// <summary>
    /// Specifies whether tasks can be executed concurrently
    /// </summary>
    public bool ConcurrentProcessing
        => GetThisSetting<bool>(false, true);

    /// <summary>
    /// Specifies whether tasks should be dispatched for execution
    /// </summary>
    /// <remarks>
    /// This should be true unless you're just interested in just scheduling tasks
    /// </remarks>
    public bool DispatchCommands
        => GetThisSetting<bool>(true, true);

    /// <summary>
    /// Specifies whether tasks should be scheduled
    /// </summary>
    /// <remarks>
    /// A task must be scheduled before it is dispatched; scheduling and dispatching are independent
    /// concerns. It may be desirable (during testing for example) to schedule tasks without
    /// executing them and for various reasons it might be useful to turn scheduling off to allow
    /// existing tasks to be dispatched/processed.
    /// </remarks>
    public bool ScheduleCommands
        => GetThisSetting<bool>(false, true);

    /// <summary>
    /// Specifies the earliest date that should be considered for
    /// task scheduling
    /// </summary>
    public DateTime MinScheduleDate
        => GetThisSetting<DateTime>(new DateTime(2015, 01, 01), true);


    /// <summary>
    /// Identifies the setting that specifies the latest date tasks should be considered for
    /// task scheduling
    /// </summary>
    public DateTime MaxScheduleDate
        => GetThisSetting<DateTime>(DateTime.Now.AddDays(-2));

    /// <summary>
    /// Specifies the number of tasks to process in a batch
    /// </summary>
    public int CommandBatchSize
        => GetThisSetting<int>(20, true);

    /// <summary>
    /// Specifies whether the orchestration should repeat the enqueue/dispatch/execute pattern indefinitely
    /// If false, only on repetition of this pattern is completed prior to the orchestration terminating
    /// </summary>
    public bool Cycle
        => GetThisSetting<bool>(true, true);

    public int CyclePauseDuration
        => GetThisSetting<int>(5000, true);

}

