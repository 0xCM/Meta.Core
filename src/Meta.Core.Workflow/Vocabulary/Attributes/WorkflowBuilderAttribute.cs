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


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WorkflowBuilderAttribute : Attribute 
    {
        private readonly string _WorkflowName;
        private readonly IReadOnlyList<string> preconditions;

        public WorkflowBuilderAttribute()
        {
            _WorkflowName = String.Empty;
            preconditions = rolist<string>();
        }

        public WorkflowBuilderAttribute(string workflowName, params string[] preconditions)
        {
            this._WorkflowName = workflowName;
            this.preconditions = rolist(preconditions);
        }

        public IReadOnlyList<string> Preconditions 
            => preconditions;

        public string WorkflowName => _WorkflowName;


    }
}