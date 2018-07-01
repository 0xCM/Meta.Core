//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [CommandSpec(CommandDescription: "Defines a list of commands intended to be executed sequentially in the supplied order")]
    public class ExecuteCommandSequence : CommandSpec<ExecuteCommandSequence, int>
    {
        public ExecuteCommandSequence()
        {
            SpecNames = new List<string>();
        }


        public ExecuteCommandSequence(string BatchName, params string[] SpecNames)
        {
            this.BatchName = BatchName;
            this.SpecNames = SpecNames.ToReadOnlyList();
            this.SpecName = BatchName;
        }

        [CommandParameter]
        public string BatchName { get; set; }


        [CommandParameter]
        public IReadOnlyList<string> SpecNames { get; set; }


    }
}