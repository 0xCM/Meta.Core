//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static metacore;

public static class AsyncX
{
    /// <summary>
    /// Determines whether the lifecycle of the task has ended
    /// </summary>
    /// <param name="t">The task to evaluate</param>
    /// <returns></returns>
    public static bool IsFinished(this Task t) 
        => not
        (
            t.Status == TaskStatus.Created ||
            t.Status == TaskStatus.Running ||
            t.Status == TaskStatus.WaitingForActivation ||
            t.Status == TaskStatus.WaitingForChildrenToComplete ||
            t.Status == TaskStatus.WaitingToRun
        );

    /// <summary>
    /// Counts the number of tasks with incomplete lifecycles
    /// </summary>
    /// <param name="tasks">The tasks to evaluate</param>
    /// <returns></returns>
    public static int CountUnfinished(this IEnumerable<Task> tasks) 
        => tasks.Count(x => not(x.IsFinished()));

    public static bool Cancelled(this Task task)
         => task.Status == TaskStatus.Canceled;

    public static bool Faulted(this Task task)
        => task.Status == TaskStatus.Faulted;

    public static bool Completed(this Task task)
        => task.Status == TaskStatus.RanToCompletion;

    public static bool Finished(this Task task)
        => task.Cancelled() || task.Faulted() || task.Completed();

    public static bool Running(this Task task)
        => task.Status == TaskStatus.Running;

    public static bool Pending(this Task task)
        => (
               task.Status == TaskStatus.Created
            || task.Status == TaskStatus.WaitingForActivation
            || task.Status == TaskStatus.WaitingToRun
        );

}

