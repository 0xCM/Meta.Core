//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Encapsulates workflow execution state
    /// </summary>
    public class WorkflowContext : NodeContext, IWorkflowContext
    {
        public static IWorkflowContext Define(INodeContext C)
            => new WorkflowContext(C);

        public static WorkflowContext<W> Define<W>(INodeContext C)
            => new WorkflowContext<W>(C);

        public static WorkflowContext<A, R> Define<A, R>(INodeContext C)
                => new WorkflowContext<A, R>(C);

        protected WorkflowContext(INodeContext C)
            : base(C, C.Host)
        {

        }
    }

    public class WorkflowContext<R> : WorkflowContext, IWorkflowContext<R>
    {
        public WorkflowContext(INodeContext C)
            : base(C)
        {

        }
    }

    public class WorkflowContext<A,R> : WorkflowContext, IWorkflowContext<A,R>
    {

        public WorkflowContext(INodeContext C)
            : base(C)
        {

        }
    }
}