//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using SqlT.Core;

    public interface ISqlWorkflowTable
    {
        ISqlTabularProxy Subject { get; }

        SqlWorkflowState State { get; }

        IAppMessage Description { get; }

        bool OperationSucceeded { get; }

    }

    public interface ISqlWorkflowTable<out P> : ISqlWorkflowTable
    {
        new P Subject { get; }


    }

}
