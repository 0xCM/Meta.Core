//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;


    [CommandSpec("workflow/exec")]
    public sealed class WorkflowCommandSpec : CommandSpec<WorkflowCommandSpec, WorkflowCommandResult>
    {

        public WorkflowCommandSpec()
        { }

        public WorkflowCommandSpec(string WorkflowName, IEnumerable<WorkflowCommandStep> steps)
        {
            this.WorkflowName = WorkflowName;
            this.Steps = steps.ToReadOnlyList();
        }

        [CommandParameter]
        public IReadOnlyList<WorkflowCommandStep> Steps { get; set; }

        [CommandParameter]
        public string WorkflowName { get; set; }

    }

}
