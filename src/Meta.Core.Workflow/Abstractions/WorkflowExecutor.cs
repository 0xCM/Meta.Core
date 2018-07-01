//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;

    public abstract class WorkflowExecutor : IWorkflowExecutor
    {
        protected WorkflowExecutor(string Label = null)
        {
            this.Label = Label ?? string.Empty;
        }

        public string Label { get; }

        public override string ToString()
            => Label;
    }

    public abstract class WorkflowExecutor<W> : WorkflowExecutor, IWorkflowExecutor<W>
    {
        protected WorkflowExecutor(string Label = null)
            : base(Label)
        {

        }



    }

}
