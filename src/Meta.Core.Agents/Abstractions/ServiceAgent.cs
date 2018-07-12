//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using Meta.Core;

using static metacore;
using static AgentNotifications;
using System.Diagnostics.Tracing;

public static class ServiceAgent
{

    /// <summary>
    /// Describes agents defined in a set of assemblies
    /// </summary>
    /// <param name="assemblies">The assemblies to search</param>
    /// <returns></returns>
    public static IEnumerable<AgentDescriptor> DiscoverAgents(IEnumerable<ClrAssembly> assemblies)
        => DiscoverAgents(from a in assemblies select a.ReflectedElement);

    /// <summary>
    /// Describes agents defined in a set of assemblies
    /// </summary>
    /// <param name="assemblies">The assemblies to search</param>
    /// <returns></returns>
    public static IEnumerable<AgentDescriptor> DiscoverAgents(IEnumerable<Assembly> assemblies)
        => from t in assemblies.SelectMany(a => a.GetTypes()).AsParallel()
           where t.HasAttribute<ServiceAgentAttribute>()
           let a = t.GetCustomAttribute<ServiceAgentAttribute>()
           select new AgentDescriptor(a.AgentIdentifier, t);
}

/// <summary>
/// Ultimate base type for service agents
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
/// <typeparam name="S">The agent setting type</typeparam>
/// <typeparam name="A">The agent contract</typeparam>
public abstract class ServiceAgent<T, S, A> : ApplicationService<T, A>, IServiceAgent
    where T : ServiceAgent<T, S, A>
    where S : ServiceAgentSettings<S>
    where A : IServiceAgent
{

    public static readonly AgentIdentifier AgentIdentifier
        = typeof(T).GetCustomAttribute<ServiceAgentAttribute>()?.AgentIdentifier
                ?? typeof(T).FullName;

    AgentNoficationChannel NotificationChannel {get;set;}

    protected ServiceAgent(IApplicationContext context)
        : base(context)
    {

        NotificationChannel = n => base.Notify(n.Message);
        Transition(ServiceAgentStates.Uninitialized);
       Notify(AgentCreated(AgentIdentifier));
        
    }

    Task AgentControlTask;

    MutableList<AgentStateTransition> Transitions = MutableList.Create<AgentStateTransition>();
    AutoResetEvent PausedEvent = new AutoResetEvent(false);
    AutoResetEvent RunningEvent = new AutoResetEvent(false);
    AutoResetEvent StoppedEvent = new AutoResetEvent(false);
    AutoResetEvent ErrorEvent = new AutoResetEvent(false);
    AutoResetEvent InitializedEvent = new AutoResetEvent(false);


    protected object[] InitParams { get; private set; }

    bool _babble = true;

    bool NoBabble
    {
        get{return not(_babble);}
        set{_babble = not(value);}
    }

    bool Babble
    {
        get{return _babble;}
        set {_babble = value;}
    }

    protected override EventLevel NotificationEventLevel
        => Babble 
        ? EventLevel.Verbose 
        : EventLevel.Informational;

    ServiceAgentState AgentState
        => Transitions.LastOrDefault()?.TargetState 
            ?? ServiceAgentStates.None;


    protected virtual int SpinFrequency
        => 5000;

    protected virtual int ControlTimeout
        => 30000;


    protected virtual int BatchSize
        => 5000;

    protected virtual bool DiagnosticMode
        => false;

    protected void AgentNotify(IAppMessage Message)
        => NotificationChannel(new AgentNotification(Host, System, AgentName, AgentState, Message));

    protected new void Notify(IAppMessage Message)
        => AgentNotify(Message);


    protected virtual SystemIdentifier System { get; }
        = SystemIdentifier.Empty;

    protected virtual SystemNodeIdentifier Host { get; }
        = SystemNode.Local.NodeIdentifier;


    /// <summary>
    /// Invoked prior to execution cycle delay
    /// </summary>
    protected virtual void BeforeYield() { }


    /// <summary>
    /// Invoked following execution cycle delay
    /// </summary>
    protected virtual void AfterYield() { }

    /// <summary>
    /// Suspends execution for a configurable period at the completion of each
    /// execution cycle
    /// </summary>
    /// <param name="frequency"></param>
    void Yield(int? frequency = null)
    {
        var pause = frequency ?? SpinFrequency;
        BeforeYield();
        Task.Delay(pause).Wait();
        AfterYield();

    }


    void SignalStateChange()
    {
        if (AgentState.IsError)
            ErrorEvent.Set();
        if (AgentState.IsPaused)
            PausedEvent.Set();
        else if (AgentState.IsRunning)
            RunningEvent.Set();
        else if (AgentState.IsStopped)
            StoppedEvent.Set();
        else if (AgentState.IsInitalized)
            InitializedEvent.Set();
    }

    /// <summary>
    /// Transitions the agent to a target state
    /// </summary>
    /// <param name="transition">The target state</param>
    void Transition(AgentStateTransition transition)
    {
        Transitions.Add(transition);
        Notify(StateTransitioned(AgentName, transition));
        SignalStateChange();
    }

   
    void Transition<D>(ServiceAgentState target)
        => Transition(new AgentStateTransition<D>(AgentState, target));

    void Transition(ServiceAgentState target)
        => Transition(new AgentStateTransition(AgentState, target));

    protected virtual void BeforeRun() { }

    protected abstract Option<int> DoWork();
   
    int Work()
    {

        Try(() => DoWork().OnMessage(Notify));

        if (AgentState.IsStopping)
            StoppedEvent.Set();

        return SpinFrequency;
    }


    /// <summary>
    /// Transitions agent to <see cref="ServiceAgentStates.Running"/> state
    /// </summary>
    /// <returns></returns>
    int StartRun()
    {
        BeforeRun();

        Transition(ServiceAgentStates.Running);

        return 1;
    }

    /// <summary>
    /// Transitions agent to <see cref="ServiceAgentStates.Pausing"/> state 
    /// and subsequently to the state specified by the <see cref="HandlePause"/> 
    /// operation
    /// </summary>
    /// <returns></returns>
    int DoPause()
    {
        Transition(ServiceAgentStates.Pausing);
        Transition(HandlePause());
        return SpinFrequency;
    }


    /// <summary>
    /// Transitions agent to <see cref="ServiceAgentStates.Resuming"/> state 
    /// and subsequently to the state specified by the <see cref="HandleResume"/> 
    /// operation
    /// </summary>
    /// <returns></returns>
    int DoResume()
    {
        Transition(ServiceAgentStates.Resuming);
        Transition(HandleResume());
        return SpinFrequency;
    }

    /// <summary>
    /// Transitions agent to <see cref="ServiceAgentStates.Stopping"/> state 
    /// and subsequently to the state specified by the <see cref="HandleStopping"/> 
    /// operation
    /// </summary>
    /// <returns></returns>
    int DoStop()
    {
        Transition(ServiceAgentStates.Stopping);
        Transition(HandleStopping());
        return SpinFrequency;
    }

    /// <summary>
    /// Transitions agent to <see cref="ServiceAgentStates.Initializing"/> state 
    /// and subsequently to the state specified by the <see cref="HandleInitialize"/> 
    /// operation
    /// </summary>
    /// <returns></returns>
    int DoInitialize()
    {
        Transition(ServiceAgentStates.Initializing);
        Transition(HandleInitialize());
        return 1;
    }

    /// <summary>
    /// Implements the agent control loop
    /// </summary>
    void Spin()
    {
        try
        {
            while (not(AgentState.IsTerminal))
            {
                var frequency = SpinFrequency;

                if (AgentState.IsUnitialized)
                    frequency = DoInitialize();

                if (AgentState.IsInitalized)
                    frequency = StartRun();
                     
                if (AgentState.IsRunning)
                    frequency = Work();

                if (AgentState.IsPausing)
                    frequency = DoPause();

                if (AgentState.IsResuming)
                    frequency = DoResume();

                if (AgentState.IsStopping)
                    frequency = DoStop();    

                Yield(frequency);
            }
        }
        catch (Exception e)
        {
            Notify(AppMessage.Error(e));
        }
        finally
        {
            AgentControlTask = null;
        }

    }

    /// <summary>
    /// Specifies the agent's name/identity
    /// </summary>
    protected virtual string AgentName
        => AgentIdentifier;

    /// <summary>
    /// Executes preconditions for a transition to the <see cref="ServiceAgentStates.Paused"/> state
    /// </summary>
    /// <returns></returns>
    protected virtual ServiceAgentState HandlePause()
        => ServiceAgentStates.Paused;

    /// <summary>
    /// Executes preconditions for a transition to the <see cref="ServiceAgentStates.Running"/> state
    /// from the <see cref="ServiceAgentStates.Paused"/> state
    /// </summary>
    /// <returns></returns>
    protected virtual ServiceAgentState HandleResume()
        => ServiceAgentStates.Running;

    /// <summary>
    /// Executes preconditions for a transition to the <see cref="ServiceAgentStates.Stopped"/> state
    /// from the <see cref="ServiceAgentStates.Running"/> state
    /// </summary>
    /// <returns></returns>
    protected virtual ServiceAgentState HandleStopping()
        => ServiceAgentStates.Stopped;

    /// <summary>
    /// Executes preconditions for a transition to the <see cref="ServiceAgentStates.Initialized"/> state
    /// </summary>
    /// <returns></returns>
    protected virtual ServiceAgentState HandleInitialize()
        => ServiceAgentStates.Initialized;

    string IServiceAgent.AgentName
        => AgentName;

    string IServiceAgent.AgentStateName
        => AgentState.StateName;

    ServiceAgentState IServiceAgent.AgentState
        => AgentState;

    void IServiceAgent.Initialize(params object[] initparams)
    {
        if (AgentState.IsUnitialized)
        {
            this.InitParams = initparams;
            Transition(ServiceAgentStates.Initializing);
            WaitHandle.WaitAny(array(InitializedEvent, ErrorEvent), ControlTimeout);
        }
    }

    void IServiceAgent.Pause()
    {
        if (AgentState.IsRunning)
        {
            Transition(ServiceAgentStates.Pausing);
            WaitHandle.WaitAny(array(PausedEvent, ErrorEvent), ControlTimeout);
        }

    }

    void IServiceAgent.Resume()
    {
        if (AgentState.IsPaused)
        {
            Transition(ServiceAgentStates.Resuming);
            WaitHandle.WaitAny(array(RunningEvent, ErrorEvent), ControlTimeout);
        }
    }

    void IServiceAgent.Start()
    {
        if (AgentState.IsUnitialized || AgentState.IsTerminal)
        {
            if (AgentControlTask != null)
                Notify(ControlTaskNotNull(AgentName));
            else
            {
                AgentControlTask = Task.Factory.StartNew(Spin, TaskCreationOptions.LongRunning);
                WaitHandle.WaitAny(array(RunningEvent, ErrorEvent), ControlTimeout);
            }
        }
        else
        {
            Notify(InvalidStartState(AgentName, AgentState));
        }
    }

    void IServiceAgent.Stop()
    {
        if (AgentState.IsRunning)
        {
            Transition(ServiceAgentStates.Stopping);
            WaitHandle.WaitAny(array(StoppedEvent, ErrorEvent), ControlTimeout);
        }
    }

    void IServiceAgent.UseChannel(AgentNoficationChannel channel)
        => NotificationChannel = channel;

    void IServiceAgent.NoBabble()
    {
        NoBabble = true;
        Notify(inform($"Hush!"));
    }

    void IServiceAgent.Babble()
    {
        NoBabble = false;
        Notify(babble("My yammering has begun"));
    }
}

public abstract class ServiceAgent<T,S> : ServiceAgent<T, S, IServiceAgent>
    where T : ServiceAgent<T,S>
    where S : ServiceAgentSettings<S>
{

    protected ServiceAgent(IApplicationContext context)
        : base(context)
    {
    }               
}
