//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using static metacore;

/// <summary>
/// Associates an agent with the system task in which the agent run loop executes
/// </summary>
public class AgentControlTask : ApplicationComponent, IDisposable
{

    public static AgentControlTask Start(IApplicationContext C, IServiceAgent Agent)
    {
        var systemTask = task(() =>
        {
            try
            {
                Agent.Start();
            }
            catch (Exception e)
            {
                var message = AppMessage.Error(e);
                C.Notify(message);
                return message;
            }

            return inform("Complete");
        });
        return new AgentControlTask(C, Agent, systemTask);

    }

    public AgentControlTask(IApplicationContext C, IServiceAgent ControlledAgent, Task<IAppMessage> SystemTask)
        : base(C)
    {
        this.ControlledAgent = ControlledAgent;
        this.SystemTask = SystemTask;
    }

    public IServiceAgent ControlledAgent { get; }

    public Task<IAppMessage> SystemTask { get; }

    public bool WaitForCompletion(int timeout = 0)
    {
        if(timeout == 0)
        {
            SystemTask.Wait();
            return true;
        }
        else
        {
            return SystemTask.Wait(timeout);
        }
    }

    public AgentIdentifier AgentIdentifier
        => ControlledAgent.AgentName;
            

    public void Dispose()
        => ControlledAgent.Dispose();
}



