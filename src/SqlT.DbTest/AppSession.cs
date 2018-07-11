//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Tool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    using static metacore;
    using static ClrStructureSpec;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;
 

    using Meta.Core;
    using Meta.Core.Workflow;


    class AppSession : NodeSession<AppSession>
    {
        public AppSession(INodeContext C)
            : base(C)
        {

            Test();
        }


        public void Test()
        {
            iter(C.WorkflowExecution().ExecuteWorkflows(GetType().Assembly), result => { });

        }

    }

}