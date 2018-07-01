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
    using System.Reflection;


    class WorkflowDiscoveryService : NodeService<WorkflowDiscoveryService, IWorkflowDiscoveryService>, IWorkflowDiscoveryService
    {

        public WorkflowDiscoveryService(INodeContext C)
            : base(C)
        {

            this.WorkflowContext = C.WorkflowContext();
        }

        IWorkflowContext WorkflowContext { get; }


        public IEnumerable<IWorkflowNode> DiscoverNodes(ClrAssembly WorkflowAssembly)
            => from nodeType in WorkflowAssembly.TypeAttributions<WorkflowNodeAttribute>().Keys
               let node = nodeType.CreateInstance<IWorkflowNode>(WorkflowContext)
               select node;
    
    }




}