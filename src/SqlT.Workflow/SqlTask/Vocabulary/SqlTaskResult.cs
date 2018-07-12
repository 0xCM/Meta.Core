//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    public abstract class SqlTaskResult<T> : ISqlTaskResult
        where T : SqlTaskResult<T>
    {
        
        protected SqlTaskResult(SqlTaskName TaskName, bool Succeeded,  long? TaskId = null, IAppMessage Description = null, CorrelationToken? CT = null)
        {
            this.TaskName = TaskName;
            this.Succeeded = Succeeded;
            this.TaskId = TaskId;
            this.Description = Description;
            this.CT = CT;
        }

        public SqlTaskName TaskName { get; }

        public bool Succeeded { get; }

        public long? TaskId { get; }

        public IAppMessage Description { get; }

        public CorrelationToken? CT { get; }

        public Option<object> Value
            => none<object>();
    }


    public sealed class SqlTaskResult : SqlTaskResult<SqlTaskResult>
    {

        public SqlTaskResult(SqlTaskName TaskName, bool Succeeded, long? TaskId = null, IAppMessage Description = null, CorrelationToken? CT = null)
            : base(TaskName, Succeeded, TaskId, Description, CT)
        {

        }

    }




}