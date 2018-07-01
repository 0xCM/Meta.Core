//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static metacore;
    
    public sealed class WorkflowArguments : TypedItemList<WorkflowArguments, WorkflowArgument>
    {
        public static implicit operator WorkflowArguments(WorkflowArgument[] args)
            => Create(args);

        public Option<WorkflowArgument> this[string Name]
            => this.FirstOrDefault(x => equals(x.Name,Name));

        public Option<WorkflowArgument> Arg([CallerMemberName] string Name = null)
            => this[Name];

        public Option<V> Arg<V>([CallerMemberName] string Name = null)
            => this[Name].Map(x => (V)x.Value);
    }
}