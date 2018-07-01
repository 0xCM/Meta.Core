//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using Meta.Core.Workflow;

    public interface ITestWorkflow
    {
        SystemUri WorkflowName { get; }
    }

    public abstract class TestWorkflow<T> : WorkflowNode<T>, ITestWorkflow
    {

        public TestWorkflow(IWorkflowContext C)
            : base(C)
        {

            WorkflowName = GetType().Uri();
        }

        public virtual SystemUri WorkflowName { get; }
            

    }

}