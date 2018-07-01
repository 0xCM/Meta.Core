//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    class WorkflowExecutionService : NodeService<WorkflowExecutionService, IWorkflowExeuctionService>, IWorkflowExeuctionService
    {
        public WorkflowExecutionService(INodeContext C)
            : base(C)
        {


        }

        IWorkflowDiscoveryService WorkflowDiscovery
            => C.WorkflowDiscovery();


        public IEnumerable<IWorkFlowed> ExecuteWorkflows(ClrAssembly DefiningAssembly)
            => WorkflowDiscovery.DiscoverNodes(DefiningAssembly).Select(ExecuteWorkflow);
               
        public IWorkFlowed ExecuteWorkflow(IWorkflowNode WfNode)
            => WfNode.Evaluate();

        public IEnumerable<IWorkFlowed> ExecuteWorkflows(IEnumerable<IWorkflowNode> WfNodes)
            => WfNodes.Select(ExecuteWorkflow);
    }


}