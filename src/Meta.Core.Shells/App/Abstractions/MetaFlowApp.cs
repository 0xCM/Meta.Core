//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    

    public abstract class MetaFlowApp<H, S> : MetaApp<H, OperationWorkflow, S>
        where H : MetaFlowApp<H, S>, new()
    {
        protected MetaFlowApp()
        {

        }

        protected Option<ClrMethodDescription> DescribeOperation(OperationExecSpec execSpec)
            => ServiceDescription.DescribeOperation(execSpec.OperationName);

        protected override Option<AppExec> Execute(OperationWorkflow workflow)
        {
            foreach (var result in workflow.Execute(Service))
            {
                HandleResult(result);
                if (result.IsNone)
                    return AppExec.Error;
            }
            return AppExec.OK;
        }

    }



}