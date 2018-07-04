//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    public class SqlWorkflowState
    {
        internal SqlWorkflowState()
        {

        }

        public bool IsPopulated
            => this == SqlWorkflowStates.Populated;

        public bool IsUnpopulated
            => this == SqlWorkflowStates.Unpopulated;
    }

    public class SqlWorkflowStates
    {
        public static readonly SqlWorkflowState Unpopulated = new SqlWorkflowState();
        public static readonly SqlWorkflowState Populated = new SqlWorkflowState();
    }
}
