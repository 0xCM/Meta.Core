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
    
    public class WorkflowAttribute : Attribute
    {

        public WorkflowAttribute(string WorkflowName = null)
        {
            this.WorkflowName 
                = isBlank(WorkflowName) 
                ? none<WorkflowName>() 
                : some(new WorkflowName(WorkflowName));

        }


        public Option<WorkflowName> WorkflowName { get; }

        public override string ToString()
            => WorkflowName.ToString();

    }
}