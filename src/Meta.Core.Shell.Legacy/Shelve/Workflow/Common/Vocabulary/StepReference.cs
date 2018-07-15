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

   
    

    public class StepReference : IWorkflowStep
    {
        public StepReference()
        {

        }

        public StepReference(WorkflowName Workflow, WorkflowStepName StepName)
        {
            this.Name = StepName;
            this.Workflow = Workflow;
        }

        public WorkflowName Workflow { get; set; }

        public WorkflowStepName Name { get; set; }


        public override string ToString()
            => $"{Workflow}/{Name}";


    }

    public class StepReference<X, Y> : StepReference
    {
        public StepReference()
        {

        }

        public StepReference(WorkflowName Workflow, WorkflowStepName StepName)
            : base(Workflow, StepName)
        {
        }


        public override string ToString()
            => $"{Workflow}/{Name}: {typeof(X).Name} => {typeof(Y).Name}";

    }





}