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

    public class WorkflowArgument<V> : IWorkflowArgument<V>
    {
        public static implicit operator V(WorkflowArgument<V> Arg)
            => Arg.Value;

        public static implicit operator WorkflowArgument<V>(V Value)
            => new WorkflowArgument<V>(string.Empty, Value);

        public static implicit operator WorkflowArgument(WorkflowArgument<V> arg)
            => new WorkflowArgument(arg.Name, arg.Value);

        public WorkflowArgument(string Name, V Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public string Name { get; }

        public V Value { get; }

        object IWorkflowArgument.Value
            => Value;

        public override string ToString()
            => $"{Name}:={Value}";

    }
}