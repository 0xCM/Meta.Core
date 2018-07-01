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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines an isolated transactional work segment
    /// </summary>
    public class WorkPartition
    {
        static int lastClrTaskId;

        /// <summary>
        /// Returns an integer that identifies the task for the scope of the application domain
        /// Unfortunately the TaskId property on the task itself is not guaranteed to be unique and is
        /// therefore unsuitable for identity assignment. 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// See: https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.id(v=vs.110).aspx
        /// </remarks>
        public static int AssignIdentity()
            => Interlocked.Increment(ref lastClrTaskId);

        public static WorkPartition<W> Create<W>(int taskid, W work, Action<W> worker, Action<W> success = null)
            where W : IPartitionedWork
            => new WorkPartition<W>(work, new Task(() => worker(work)), taskid, success);

        /// <summary>
        /// Creates a Work Task parametrized by both work and result types
        /// </summary>
        /// <typeparam name="W">The work specification type</typeparam>
        /// <typeparam name="R">The work result type</typeparam>
        /// <param name="taskid">The task id</param>
        /// <param name="work">Specification of work to be performed</param>
        /// <param name="worker">Function that can carry out the specified work</param>
        /// <param name="success">Success action</param>
        /// <returns></returns>
        public static WorkPartition<W, R> Create<W, R>(int taskid, W work, Func<W, R> worker, Action<W, R> success = null)
            where W : IPartitionedWork
            => new WorkPartition<W, R>(work, new Task<R>(() => worker(work)), taskid, success);

        public WorkPartition(IPartitionedWork work, Task task, int taskid, Action<IPartitionedWork> success = null)
        {
            this.Work = work;
            this.ClrTaskId = taskid;
            this.ClrTask = task;
            this.ClrTask.ContinueWith(t => success?.Invoke(work));
        }

        /// <summary>
        /// Represents the work to be performed
        /// </summary>
        public IPartitionedWork Work { get; }

        /// <summary>
        /// Transient identifier that should be considered valid for the lifetime of the application domain
        /// </summary>
        public int ClrTaskId { get; }

        /// <summary>
        /// The task that will be started to execute the work
        /// </summary>
        public Task ClrTask { get; }

        /// <summary>
        /// The name of the partition
        /// </summary>
        public string Partition
            => Work.PartitionName;

        /// <summary>
        /// Starts the encapsulated task
        /// </summary>
        public void Start()
            => ClrTask.Start();

        /// <summary>
        /// Waits for the task to complete execution
        /// </summary>
        public void Wait()
            => ClrTask.Wait();

        /// <summary>
        /// Determines whether the task has finished
        /// </summary>
        /// <returns></returns>
        public bool IsFinished()
            => ClrTask.IsFinished();
    }


    /// <summary>
    /// Defines an isolated transactional work segment
    /// </summary>
    /// <typeparam name="W">The type of work</typeparam>
    public class WorkPartition<W> : WorkPartition where W : IPartitionedWork
    {

        /// <summary>
        /// Initializes a new <see cref="WorkPartition{W}"/> instance
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="task">The task that will executed the work to be performed</param>
        /// <param name="completed">Optional action invoked when the work has been completed</param>
        public WorkPartition(W work, Task task, int taskid, Action<W> completed = null)
            : base(work, task, taskid, w => completed?.Invoke((W)w))
        {


        }

        /// <summary>
        /// The work to be performed
        /// </summary>
        public new W Work
            => (W)base.Work;
    }


    /// <summary>
    /// Defines an isolated transactional work segment
    /// </summary>
    /// <typeparam name="W">The type of work</typeparam>
    /// <typeparam name="R">The type of result</typeparam>
    public class WorkPartition<W, R> : WorkPartition<W> where W : IPartitionedWork
    {

        /// <summary>
        /// Initializes a new <see cref="WorkPartition{W}"/> instance
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="task">The task that will executed the work to be performed</param>
        /// <param name="completed">Optional action invoked when the work has been completed</param>
        public WorkPartition(W work, Task<R> task, int taskid, Action<W, R> completed = null)
            : base(work, task, taskid, w => completed?.Invoke(w, task.Result))
        {


        }

        /// <summary>
        /// The work to be performed
        /// </summary>
        public new W Work
            => base.Work;

        public new Task<R> ClrTask
            => (Task<R>)base.ClrTask;
    }
}