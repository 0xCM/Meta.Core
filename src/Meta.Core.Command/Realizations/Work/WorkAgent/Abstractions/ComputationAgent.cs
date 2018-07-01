//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class ComputationAgent<T, S, P> : ServiceAgent<T, S>, IComputationAgent<P>
    where T : ComputationAgent<T, S, P>
    where S : ServiceAgentSettings<S>

{
    protected ComputationAgent(IApplicationContext context)
        : base(context)
    {
    }

    protected abstract IEnumerable<P> Compute();

    IEnumerable<IAgentComputationResult> IComputationAgent.Compute()
    {
        foreach (var computation in Compute())
            yield return AgentComputationResult.Create(AgentIdentifier, computation);
    }

    IEnumerable<IAgentComputationResult<P>> IComputationAgent<P>.Compute()
    {
        foreach (var computation in Compute())
            yield return AgentComputationResult.Create(AgentIdentifier, computation);
    }
}


