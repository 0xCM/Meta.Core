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
    public static IApplicationMessage TaskGroupExecutionCancelled(string GroupName)
        => ApplicationMessage.Inform("The @GroupName task group was cancelled", new
        {
            GroupName
        });

    public static IApplicationMessage WaitingForTasks(int Count, int Timeout)
        => ApplicationMessage.Inform("Waiting a maximum of @Timeout ms for @Count currently executing tasks to finish", new
        {
            Count,
            Timeout
        });

    public static IApplicationMessage TasksUnfinished(int Count, int Timeout)
        => ApplicationMessage.Warn("There were @Count currentingly executing tasks when a wait timeout of @Timeout ms expired", new
        {
            Count,
            Timeout
        });

    public static IApplicationMessage ExecutionIndexUpdateFailed(int TaskId)
        => ApplicationMessage.Error("Could not add task @TaskId to the execution index", new
        {
            TaskId
        });

    public static IApplicationMessage Pausing(int TaskId, int Duration)
        => ApplicationMessage.Babble("Pausing control task @TaskId for @Duration ms",
            new
            {
                TaskId,
                Duration
            });

    public static IApplicationMessage SpinnerCreated(Task spinner)
        => ApplicationMessage.Babble("Spinner @TaskId created", new
        {
            TaskId = spinner.Id
        });

    public static IApplicationMessage SpinnerCompleted(Task spinner)
        => ApplicationMessage.Babble("Spinner @TaskId completed", new
        {
            TaskId = spinner.Id
        });

    public static IApplicationMessage Stopping()
        => ApplicationMessage.Inform("Stopping agent");

    public static IApplicationMessage Stopped()
        => ApplicationMessage.Inform("Agent execution stopped");

    public static IApplicationMessage AlreadyRunning()
        => ApplicationMessage.Warn("The agent is already running");

}
