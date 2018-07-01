//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using static metacore;

    public static class WorkflowMessages
    {
        public static IApplicationMessage PublicationSucceeded<TSrc, TDst>(int RecordCount, int TotalCount)
            => inform("Published @RecordCount @DstTypeName target records from @SrcTypeName for a total of @TotalCount so far",
                    new
                    {
                        RecordCount,
                        TotalCount,
                        SrcTypeName = typeof(TSrc).Name,
                        DstTypeName = typeof(TDst).Name
                    }
                );
        internal static IApplicationMessage ExecutingWorkflow(string WorkflowName)
            => inform("Executing @WorkflowName workflow",
                new
                {
                    WorkflowName
                });

        internal static IApplicationMessage InvokedEmission(Option<int> EmissionResult, string TargetTypeName)
             => EmissionResult ? inform(EmissionResult.Value() != 0
                     ? "Emitted @RecordCount @TargetTypeName records"
                     : "No @TargetTypeName Records to emit", new
                     {
                         TargetTypeName,
                         RecordCount = EmissionResult.Value()
                     })
            : !EmissionResult.Message.IsEmpty
            ? EmissionResult.Message
            : error("Emission to @TargetTypeName failed with unspecified Message", new
            {
                TargetTypeName
            });

    }
}
