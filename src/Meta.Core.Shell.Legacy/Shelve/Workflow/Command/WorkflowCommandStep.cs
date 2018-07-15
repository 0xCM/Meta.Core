//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;


    public sealed class WorkflowCommandStep : IWorkflowCommandStep
    {

        public WorkflowCommandStep()
        {

        }

        public WorkflowCommandStep(string SpecName)
        {
            this.SpecName = SpecName;
        }

        public string SpecName { get; }

        public string Format()
            => $"ExecuteCommand({SpecName})";

        public override string ToString()
            => Format();

    }


}