//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{

    using System;
    using static metacore;

    using System.Collections.Generic;


    public class WorkflowSpec
    {

        List<StepReference> _Steps { get; }

        public WorkflowSpec()
        {
            _Steps = new List<StepReference>();
        }

        public WorkflowSpec(WorkflowName Name)
            : this()
        {
            this.WorkflowName = Name;
        }

        public WorkflowName WorkflowName { get; set; }

        public IReadOnlyList<StepReference> Steps
            => _Steps;

        
        internal WorkflowSpec AddStep<X,Y>(StepReference<X,Y> step)
        {
            _Steps.Add(step);
            return this;
        }

        public override string ToString()
            => WorkflowName;

    }



}
