//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Test
{
    using Meta.Core;
    using Meta.Core.Workflow;


    class AppSession : NodeSession<AppSession>
    {


        public AppSession(INodeContext C)
            : base(C)
        {
            
            Results = C.WorkflowExecution().ExecuteWorkflows(GetType().Assembly).ToReadOnlyList();
        }

       ReadOnlyList<IWorkFlowed> Results { get; }

    }

}