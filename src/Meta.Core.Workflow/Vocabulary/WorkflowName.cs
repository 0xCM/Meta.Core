//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    public class WorkflowName : SemanticIdentifier<WorkflowName, string>
    {
        public static implicit operator WorkflowName(string x)
            => new WorkflowName(x);

        protected override WorkflowName New(string IdentifierText)
            => new WorkflowName(IdentifierText);

        WorkflowName()
            : base(string.Empty)
        {

        }

        public WorkflowName(string name)
            : base(name)
        {

        }

    }


}