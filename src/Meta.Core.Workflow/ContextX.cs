//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using Meta.Core.Workflow;

    using static metacore;
    using System;
    using System.Collections.Generic;

    using WF = Meta.Core.Workflow;

    public static partial class ContextX
    {

        public static IWorkflowContext<R> WorkflowContext<R>(this INodeContext C)
            => WF.WorkflowContext.Define<R>(C);

        public static IWorkflowContext WorkflowContext(this INodeContext C)
            => WF.WorkflowContext.Define(C);

        public static IWorkflowDiscoveryService WorkflowDiscovery(this INodeContext C)
            => C.Service<IWorkflowDiscoveryService>();

        public static IWorkflowExeuctionService WorkflowExecution(this INodeContext C)
            => C.Service<IWorkflowExeuctionService>();

    }
}