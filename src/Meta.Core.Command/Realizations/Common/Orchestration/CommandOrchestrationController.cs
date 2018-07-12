//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;


class CommandOrchestrationController : ApplicationService<CommandOrchestrationController, ICommandOrchestrationController>, ICommandOrchestrationController
{
    static IAppMessage OrchestrationStartError(Type SpecType, Exception e)
        => AppMessage.Error("@CommandName orchestration start error: @ErrorDetail", new
        {
            CommandName = CommandSpecDescriptor.FromSpecType(SpecType).CommandName,
            ErrorDetail = e.ToString()
        });

    static IAppMessage ControllerStarting()
        => AppMessage.Inform("Starting controller and subject orchestrations", new
        {

        });


    bool Running = false;
    readonly ConcurrentDictionary<Type, ICommandOrchestrator> Orchestrators
        = new ConcurrentDictionary<Type, ICommandOrchestrator>();


    readonly CommandOrchestrationSettings DefaultCommandSettings;

    public CommandOrchestrationController(IApplicationContext context)
        : base(context)
    {
        DefaultCommandSettings = context.Settings<CommandOrchestrationSettings>();

    }

    public bool IsRunning()
        => Running;

    public bool IsRunning(Type SpecType)
        => Orchestrators.TryFind(SpecType).MapValueOrDefault(o => o.IsRunning, false);

    ICommandOrchestrator GetOrchestrator(ICommandExecutionService pattern, CommandOrchestrationSettings Settings)
    {
        var orchestrator = C.CPS().Orchestrator(pattern, true, Settings);
        return orchestrator.Require(); ;
    }

    ICommandOrchestrator GetOrchestrator(Type SpecType, CommandOrchestrationSettings Settings)
    {
        var orchestrator = C.CPS().Orchestrator(SpecType, true, Settings);
        return orchestrator.Require(); ;
    }


    public void Start(ICommandExecutionService pattern, CommandOrchestrationSettings Settings)
    {
        try
        {
            Orchestrators.GetOrAdd(pattern.SpecType, _ => GetOrchestrator(pattern, Settings ?? DefaultCommandSettings));            
        }
        catch (Exception e)
        {
            Notify(OrchestrationStartError(pattern.SpecType, e));
        }

    }

    public void Start(Type SpecType, CommandOrchestrationSettings Settings)
    {
        try
        {
            
            Orchestrators.GetOrAdd(SpecType, t => GetOrchestrator(t, Settings ?? DefaultCommandSettings));
        }
        catch (Exception e)
        {
            Notify(OrchestrationStartError(SpecType, e));
        }

    }

    public bool Stop(Type SpecType, int timeout)
    {
        var orchestrator = Orchestrators.TryFind(SpecType).Require();
        return orchestrator.Stop(timeout);

    }

    public bool TryStop(Type SpecType, int timeout = -1)
    {
        var orchestrator = Orchestrators.TryFind(SpecType).Require();
        return orchestrator.TryStop(timeout);
    }


    public void Start()
    {
        Notify(ControllerStarting());

        Orchestrators.Values.Iterate(o => o.Start());
        Running = true;
    }

    public void Stop(int timeout)
    {
        Orchestrators.Values.AsParallel().ForAll(o => o.Stop(timeout));
        Running = false;
    }

    public void TryStop(int timeout)
    {
        Orchestrators.Values.AsParallel().ForAll(o => o.TryStop(timeout));
        Running = Orchestrators.Values.Any(o => o.IsRunning);
    }

    protected override void Dispose()
    {
        Orchestrators.Values.Iterate(o => o.Dispose());
        Orchestrators.Clear();
    }
    
}


