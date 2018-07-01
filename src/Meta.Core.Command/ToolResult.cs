//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Describes the outcome of executing a tool (typically a command-line tool)
    /// </summary>
    public class ToolResult
    {
        public ToolResult(bool succeeded, IEnumerable<string> Messages)
        {
            this.Succeeded = Succeeded;
            this.Messages = rolist(Messages);

        }

        /// <summary>
        /// Specifies whether the tool executed successfully
        /// </summary>
        public bool Succeeded { get; }

        /// <summary>
        /// The list of messages emitted by the tool during execution
        /// </summary>
        public IReadOnlyList<string> Messages { get; }

        public override string ToString()
            => Succeeded ? "Succeeded" : "Failed";
    }

}