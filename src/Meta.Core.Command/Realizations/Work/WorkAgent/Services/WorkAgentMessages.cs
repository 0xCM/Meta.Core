//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

static class WorkAgentMessages
{
    public static IAppMessage TaskGroupExecutionCancelled(string GroupName)
        => AppMessage.Inform("The @GroupName task group was cancelled", new
        {
            GroupName
        });

    public static IAppMessage WaitingForTasks(int Count, int Timeout)
        => AppMessage.Inform("Waiting a maximum of @Timeout ms for @Count currently executing tasks to finish", new
        {
            Count,
            Timeout
        });

    public static IAppMessage TasksUnfinished(int Count, int Timeout)
        => AppMessage.Warn("There were @Count currentingly executing tasks when a wait timeout of @Timeout ms expired", new
        {
            Count,
            Timeout
        });

    public static IAppMessage ExecutionIndexUpdateFailed(int TaskId)
        => AppMessage.Error("Could not add task @TaskId to the execution index", new
        {
            TaskId
        });

    public static IAppMessage Pausing(int TaskId, int Duration)
        => AppMessage.Babble("Pausing control task @TaskId for @Duration ms",
            new
            {
                TaskId,
                Duration
            });

    public static IAppMessage SpinnerCreated(Task spinner)
        => AppMessage.Babble("Spinner @TaskId created", new
        {
            TaskId = spinner.Id
        });

    public static IAppMessage SpinnerCompleted(Task spinner)
        => AppMessage.Babble("Spinner @TaskId completed", new
        {
            TaskId = spinner.Id
        });

    public static IAppMessage Stopping()
        => AppMessage.Inform("Stopping agent");

    public static IAppMessage Stopped()
        => AppMessage.Inform("Agent execution stopped");

    public static IAppMessage AlreadyRunning()
        => AppMessage.Warn("The agent is already running");

}
