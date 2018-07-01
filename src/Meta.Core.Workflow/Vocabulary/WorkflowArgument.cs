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

    /// <summary>
    /// Defines a workflow argument
    /// </summary>
    public sealed class WorkflowArgument 
    {
        public WorkflowArgument(string Name, object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        /// <summary>
        /// The argument name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The argument value
        /// </summary>
        public object Value { get; }

        public override string ToString()
            => $"{Name}:={Value}";
    }
}