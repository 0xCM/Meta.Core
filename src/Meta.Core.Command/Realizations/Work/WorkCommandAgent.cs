//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;


    public sealed class WorkCommandAgent<TSpec> : WorkAgent<WorkCommand<TSpec>>
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommandAgent(WorkCommandAgentConfiguration<TSpec> AgentConfiguration)
            : base(AgentConfiguration)
        { }

    }
}