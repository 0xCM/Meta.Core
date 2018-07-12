//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using MetaFlow.Core;

    using static metacore;  

    public static class WorkflowMessages
    {
        public static IAppMessage DefinedCommands<K>(int Count)
            => inform($"Defined {Count} {typeof(K).Name} commands");

        public static IAppMessage EnqueuedTasks<T>(int Count)
            => inform($"Enqueued {Count} {typeof(T)} tasks");

        public static IAppMessage ExecutingQueue<T>(SystemNodeIdentifier Host)
            => inform($"Executing {typeof(T).Name} task queue on {Host}");

        public static IAppMessage ExecutedQueue<T>(SystemNodeIdentifier Host)
            => inform($"Executing {typeof(T).Name} task queue on {Host}");

        public static IAppMessage ExecutingBatch<T>(int count)
            where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
            => inform($"Executing batch of {typeof(T).Name} tasks");

        public static IAppMessage ExecutingTask<T>(T task)
            where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
            => inform($"Executing {typeof(T).Name} task {task.TaskId}");

        public static IAppMessage ExecutedTask<R>(R result)
            where R : class, ITaskResult, ISqlTableTypeProxy, new()
                => result.Succeeded ?
                inform($"Execution of task {result.TaskId} succeeded")
            : warn($"Execution of task {result.TaskId} failed: {result.ResultDescription}");

        public static IAppMessage ExecutedBatch<T>(int count)
            where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
            => inform($"Executed batch of {typeof(T).Name} tasks");

        public static IAppMessage BeginningTaskCycle<T>(int cycles)
                where T : class, IWorkflowTask, ISqlTableTypeProxy, new()

            => inform($"Beginning {typeof(T).Name} cycle {cycles}");

        public static IAppMessage FinishedTaskCycle(int cycles)
            => inform($"Finished task cycle {cycles}");

        public static IAppMessage AllTasksDispatched<T>()
            => inform($"All {typeof(T).Name} tasks have been dispatched");


        public static IAppMessage Dispatched(int count)
            => inform($"Dispatched {count} tasks");


        public static IAppMessage DispatchedSystemTasks(int count)
            => count != 0 ?
            inform($"Dispatched {count} system commands")
                : inform("No commands were available for dispatch");

        public static IAppMessage TaskNotExecuting(long TaskId)
            => warn($"Task {TaskId} is not executing");

        public static IAppMessage ExecutingTask(SystemTask task)
            => inform($"Executing {task.CommandUri}");

        public static IAppMessage CommandNotRecognized(SystemTask task)
            => error($"The task {task.CommandUri} could not be matched with an executor");

        public static IEnumerable<IAppMessage> DescribeOutcome(ISystemTaskResult outcome)
        {
            if (outcome.Succeeded && isNotBlank(outcome.ResultDescription))
                yield return inform($"Executed {outcome.TaskId}: {outcome.ResultDescription}");
            else if (outcome.Succeeded && isBlank(outcome.ResultDescription))
                yield return inform($"Executed {outcome.TaskId}");
            else
            {
                yield return error($"Execution of task {outcome.TaskId} failed");
                yield return error(outcome.ResultDescription);
            }
        }
    }
}