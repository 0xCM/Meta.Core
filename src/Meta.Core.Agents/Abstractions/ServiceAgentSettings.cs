//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class ServiceAgentSettings<T> : ProvidedConfiguration<T>
    where T : ServiceAgentSettings<T>
{

    readonly string AgentIdentifier;

    public ServiceAgentSettings(IConfigurationProvider configuration, string AgentIdentifier)
        : base(configuration)
    {

        this.AgentIdentifier = AgentIdentifier;
    }

    [ComponentSetting("The number of milliseconds between the terminanation of a work cycle and the beginning of another")]
    public virtual int SpinFrequency
        => GetThisSetting(5000, true);

    [ComponentSetting("The number of milliseconds to wait for an agent control operation to complete")]
    public virtual int ControlTimeout
        => GetThisSetting(30000, true);

    [ComponentSetting("The maximum number of tasks the agent will manage at any given instant")]
    public virtual int BatchSize
        => GetThisSetting(20, true);

    [ComponentSetting("Determines whether tasks within a cycle will be executed concurrently")]
    public virtual bool ConcurrentExecution
        => GetThisSetting(false, true);

    protected override string SubComponentName
        => "Agents";

    protected override string AlternateGroupName
        => AgentIdentifier;
}
