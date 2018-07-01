//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class WorkflowDecision : StepReference
    {

        public WorkflowDecision()
        {

        }

        public WorkflowDecision(WorkflowName Workflow, WorkflowStepName StepName)
            : base(Workflow, StepName)
        {
        }

        public override string ToString()
            => $"{base.ToString()} (Decision)";

    }

    public class WorkflowDecision<X, Y> : StepReference<X, Y>
    {

        public WorkflowDecision()
        {

        }

        public WorkflowDecision(WorkflowName Workflow, WorkflowStepName StepName)
            : base(Workflow, StepName)
        {
        }


    }



}
