//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

using static metacore;
using static CommandStatusMessages;

public class CommandPatternSystem : ApplicationService<CommandPatternSystem,ICommandPatternSystem>, ICommandPatternSystem
{
    ICommandPatternLibrary PatternLibrary
        => Context.Service<ICommandPatternLibrary>();

    public ICommandStore DbCommandStore
        => Context.Service<ICommandStore>(CommandStoreType.DbStore);

    public ICommandStore FileCommandStore
        => Context.Service<ICommandStore>(CommandStoreType.FileStore);

    ICommandStore CommandStore
        => DbCommandStore ?? FileCommandStore;

    public ICommandExecStore ExecStore
        => C.CommandExecStore();

    ICommandQueueExecutor<TSpec,TPayload> QueueExecutor<TSpec,TPayload>(ICommandExecutionService<TSpec,TPayload> pattern)
        where TSpec : CommandSpec<TSpec,TPayload>, new()
        => new CommandQueueExecutor<TSpec,TPayload>(Context, pattern);
    
    ICommandQueueExecutor<TSpec> QueueExecutor<TSpec>(ICommandExecutionService<TSpec> pattern)
        where TSpec : CommandSpec<TSpec>, new()
        => new CommandQueueExecutor<TSpec>(Context, pattern);

    public Option<ICommandExecutionService<TSpec>> Pattern<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => PatternLibrary.Pattern<TSpec>();

    public Option<ICommandExecutionService<TSpec, TPayload>> Pattern<TSpec, TPayload>()
        where TSpec : CommandSpec<TSpec, TPayload>, new()
        => PatternLibrary.Pattern<TSpec, TPayload>();

    Option<ICommandExecutor<TSpec, TPayload>> Executor<TSpec, TPayload>()
        where TSpec : CommandSpec<TSpec, TPayload>, new()
        => from p in Pattern<TSpec, TPayload>()
           select p.Executor;

    public Option<ICommandExecutor<TSpec>> Executor<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => from p in Pattern<TSpec>()
           select p.Executor;

    public Option<ICommandExecutor> Executor(CommandName CommandName)
        => Pattern(CommandName).Map(x => x.Executor);

    public ICommandQueue<TSpec> Queue<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => (from p in Pattern<TSpec>()
            select p.Queue).Require();
    
    public Option<ICommandQueue> Queue(CommandName CommandName)
        => Pattern(CommandName).Map(p => p.Queue);

    ICommandOrchestrator<TSpec, TPayload> CreateOrchestration<TSpec, TPayload>
            (ICommandExecutionService<TSpec, TPayload> pattern, CommandOrchestrationSettings settings)
                where TSpec : CommandSpec<TSpec,TPayload>, new() 
                    => new CommandOrchestrator<TSpec,TPayload>(Context, pattern, settings);

    public CommandPatternSystem(IApplicationContext context)
        : base(context)
    {

    }

    public ReadOnlyList<ICommandSpec> StoredSpecs()
        => CommandStore?.FindSpecs() ?? ReadOnlyList.Create<ICommandSpec>();

    public void UpdateCommandDescriptors()
        => CommandStore?.SaveDefinitions(AvailableCommands());

    public ReadOnlyList<ICommandSpec> AvailableCommands()
        => PatternLibrary.SpecDescriptors().Values.Map(x
                => (ICommandSpec)Activator.CreateInstance(x.SpecType));

    public Option<ICommandSpec> StoredSpec(string SpecName)
        => Option.eval(StoredSpecs().FirstOrDefault(spec => spec.SpecName == SpecName));

    public IEnumerable<ICommandExecutionService> Patterns()
        => PatternLibrary.Patterns();

    public Option<ICommandExecutionService> Pattern(Type SpecType)
        => PatternLibrary.Pattern(SpecType);

    public Option<ICommandExecutionService> Pattern(CommandName Name)
        => PatternLibrary.Pattern(Name);

    public Option<ReadOnlyList<CommandSubmission<TSpec>>> Submit<TSpec>(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct)
        where TSpec : CommandSpec<TSpec>, new()
        => from p in Pattern<TSpec>()
           from submission in p.Queue.Enqueue(commands, target, ct)
           select submission;

    public Option<ReadOnlyList<CommandSubmission>> Submit(IEnumerable<ICommandSpec> commands, SystemNode target, CorrelationToken? ct)
    {
        var index = dict(commands.GroupBy(x => x.CommandName).Select(g => (g.Key, g.Select(y => y))));
        var all = MutableList.Create<CommandSubmission>();
        foreach(var commandName in index.Keys)
        {
            var sorted = index[commandName];
            var pattern = Pattern(commandName);
            if(!pattern)
                return pattern.ToNone<ReadOnlyList<CommandSubmission>>();

            var submissions = pattern.MapValueOrDefault(p => p.Queue.Enqueue(sorted, target, ct));
            if (!submissions)
                return submissions.ToNone<ReadOnlyList<CommandSubmission>>();

            all.AddRange(submissions.Items());
        }
        return all.ToReadOnlyList();
    }

    void ICommandPatternSystem.ExecuteQueue<TSpec, TPayload>()
        => QueueExecutor(Pattern<TSpec, TPayload>().Require()).ExecuteQueue();
             
   void ICommandPatternSystem.ExecuteQueue<TSpec>()
        => QueueExecutor(Pattern<TSpec>().Require()).ExecuteQueue();

    ReadOnlyList<CommandSpecDescriptor> ICommandPatternSystem.DescribeCommands()
        => PatternLibrary.SpecDescriptors().Values.ToReadOnlyList();

    Option<ICommandExecutionService> ICommandPatternSystem.Pattern(ICommandSpec spec)
        => Pattern(spec.CommandName);

    IOption ExecuteCommand(ICommandExecutionService pattern, ICommandSpec command, bool save)
    {
        Notify(ExecutingCommand(command));

        if (save)
        {
           var saved = CommandStore?.SaveSpec(command);
            if (!saved.HasValue)
                return saved;
            else if (!saved.Value)
                return saved;

        }

        var expansion = command.ExpandVariables();
        var option = pattern.TryExecute(expansion);
        if (option != null)
        {
            if (option.IsNone)
            {
                Notify(option.Message);
            }
            else
            {
                if (option.Message.IsEmpty)
                    Notify(CompletedCommandExecution(command, option.Value));
                else
                    Notify(option.Message);
            }
        }
        else
        {
            Notify(EmptyCommandResult(command));
        }
        return option;

    }

    public IOption ExecuteCommand(ICommandSpec command, bool save)
    {
        var pattern = Self.Pattern(command);
        if(pattern.IsNone())
            return pattern.WithMessage(ExecutorNotFound(command.CommandName));                        
     
        try
        {
            return ExecuteCommand(pattern.Require(), command, save);
        }
        catch (Exception e)
        {            
            return none<ICommandExecutionService>(UnhandledExecutionError(command, e));
        }        
    }

    IOption ExecuteCommand<TSpec>(TSpec command, bool save) where TSpec : CommandSpec<TSpec>, new()
        => ExecuteCommand((ICommandSpec)command, save);

    IOption ICommandPatternSystem.ExecuteCommand<TSpec>(TSpec command, bool save)
        => ExecuteCommand(command, save);

    TResult ICommandPatternSystem.ExecuteCommand<TSpec, TResult>(TSpec command, bool save)
        => (TResult)ExecuteCommand(command, save);

    Option<TResult> ICommandPatternSystem.Execute<TSpec, TResult>(CommandSpec<TSpec, TResult> command, bool save)
    {
        var result = ExecuteCommand((ICommandSpec)command, save);
        if (result.IsSome)
            return (TResult)result.Value;
        else
            return none<TResult>(result.Message);
    }

    IEnumerable<TSpec> ICommandPatternSystem.BuildCommands<TSpec>()
        => (from p in  Pattern<TSpec>()
           select p.Factory(Context)).Require();

    Option<ICommandOrchestrator<TSpec, TPayload>> ICommandPatternSystem.Orchestrator<TSpec, TPayload>(bool start, CommandOrchestrationSettings settings)
        => Try(() =>
               {
                   var orchestrator
                       = from p in Pattern<TSpec, TPayload>()
                         let s = settings ?? Context.Settings<CommandOrchestrationSettings>()
                         let manager = CreateOrchestration(p, settings)
                         select manager;
                   return start ?
                       orchestrator.OnSome(o => o.Start()) : orchestrator;
               });

    public Option<ICommandOrchestrator> Orchestrator(ICommandExecutionService pattern, bool start, CommandOrchestrationSettings settings)
        => Try(() =>
                {
                    var orcType = typeof(CommandOrchestrator<,>).MakeGenericType(pattern.SpecType, pattern.PayloadType);
                    return some((ICommandOrchestrator)Activator.CreateInstance(orcType, Context, pattern, settings)).OnSome(o =>
                     {
                         if (start)
                             o.Start();
                     });

                });

    public Option<ICommandOrchestrator> Orchestrator(Type SpecType, bool start, CommandOrchestrationSettings settings)
        => from p in Pattern(SpecType)
           from o in Orchestrator(p,start, settings)
           select o;

    public Option<int> PurgeQueues()
        => ExecStore.PurgeQueues(none<CommandName>());

    Option <int> ICommandPatternSystem.PurgeQueues<TSpec>()
        =>  from spec in PatternLibrary.SpecDescriptor<TSpec>()
            from count in ExecStore.PurgeQueues(spec.CommandName)
            select count;
    
    Option<CommandSpecDescriptor> ICommandPatternSystem.DescribeCommand(CommandName CommandName)
        => Self.DescribeCommands().FirstOrDefault(x => x.CommandName == CommandName);

    public Option<int> SaveSpecs(params ICommandSpec[] specs)
        => CommandStore?.SaveSpecs(specs) ?? none<int>();

}
