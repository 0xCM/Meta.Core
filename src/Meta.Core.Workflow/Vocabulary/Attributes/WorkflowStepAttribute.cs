//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;
    using static metacore;

    public class WorkflowStepAttribute : Attribute
    {

        public WorkflowStepAttribute(string StepName = null, int Precedence = -1)
        {
            this.StepName = 
                isBlank(StepName) 
                ? none<WorkflowStepName>() 
                : some(new WorkflowStepName(StepName));

            this.Precedence =
                Precedence >= 0
                ? some(Precedence)
                : none<int>();
                
        }


        public Option<WorkflowStepName> StepName { get; }

        public Option<int> Precedence { get; }

        public override string ToString()
            => StepName.ToString();


    }
}