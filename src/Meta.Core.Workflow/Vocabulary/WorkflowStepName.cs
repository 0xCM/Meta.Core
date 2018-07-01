//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    public class WorkflowStepName : SemanticIdentifier<WorkflowStepName, string>
    {
        public static implicit operator WorkflowStepName(string x)
            => new WorkflowStepName(x);


        protected override WorkflowStepName New(string IdentifierText)
            => new WorkflowStepName(IdentifierText);

        WorkflowStepName()
            : base(string.Empty)
        {

        }

        public WorkflowStepName(string name)
            : base(name)
        {

        }

    }


}