//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

#if NetFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

class GoAwayDesigner { }

/// <summary>
/// Defines based <see cref="IServiceAgent"/> management capabilities that execute
/// in the context of windows service
/// </summary>
public sealed class ServiceAgentApp : ServiceBase
{
    private readonly IReadOnlyList<IServiceAgent> agents;

    /// <summary>
    /// Initializes a new service agent application instance
    /// </summary>
    /// <param name="agents">The agents available to the application</param>
    public ServiceAgentApp(IEnumerable<IServiceAgent> agents)
    {
        this.agents = agents.ToList();            
    }

    /// <summary>
    /// Invoked when a start command is received for the service
    /// </summary>
    /// <param name="args"></param>
    protected override void OnStart(string[] args)
    {
        foreach (var agent in agents)
            agent.Start();
    }

    /// <summary>
    /// Invoked when a stop command is received for the service
    /// </summary>
    protected override void OnStop()
    {
        foreach (var agent in agents)
            agent.Stop();
    }

    /// <summary>
    /// Begins the application run loop
    /// </summary>
    public void Run()
    {
        ServiceBase.Run(new ServiceBase[] { this });
    }
}

#endif