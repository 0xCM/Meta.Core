//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Meta.Core;

using static metacore;


public static class CommandX
{
    public static CommandArguments ExpandVariables(this CommandArguments src)
    {
        var args = MutableList.Create<CommandArgument>();
        iter(src, arg =>
        {
            if ((arg.Value as string) != null)
            {
                var argExpansion = Script.SpecifyEnvironmentParameters((string)arg.Value);
                args.Add(new CommandArgument(arg.Name, argExpansion));
            }
        });
        return new CommandArguments(args);
    }

    public static T CreateCommand<T>(this IEnumerable<CommandArgument> args)
        where T : CommandSpec<T>, new()
    {
        var command = new T();
        command.AssignArgs(args.ToArray());
        return command;
    }

    public static ICommandSpec CreateCommand(this IEnumerable<CommandArgument> args, Type CommandType)
    {
        var command = (ICommandSpec)Activator.CreateInstance(CommandType);
        command.AssignArgs(args.ToArray());
        return command;
    }

    public static IReadOnlyList<CommandSpecDescriptor> DescribeCommands(this Assembly a)
        => rolist((from t in a.GetTypes()
                 let descriptor = CommandSpecDescriptor.TryGetFromType(t)
                 where descriptor.IsSome()
                 select descriptor.Require()));

    public static IReadOnlyList<CommandExecDescriptor> DescribeExecutors(this Assembly a)
    {
        var q = from t in a.GetTypes()
                where Attribute.IsDefined(t, typeof(CommandPatternAttribute))
                && t.BaseType.IsGenericType && !t.IsAbstract
                let typeArgs = t.BaseType.GetGenericArguments()
                where typeArgs.Length >= 2
                let specType = typeArgs[1]
                select new CommandExecDescriptor
                {
                    PatternType = t,
                    SpecType = specType,
                    CommandName = CommandSpecDescriptor.FromSpecType(specType).CommandName
                };
        return q.ToList();
    }

    public static Option<int> SaveSpecs(this ICommandPatternSystem CPS, IEnumerable<ICommandSpec> Commands)
        => CPS.SaveSpecs(Commands.ToArray());

    public static Option<CommandSubmission<TSpec>> Submit<TSpec>(this ICommandPatternSystem CPS, TSpec Command, SystemNode DstNode, CorrelationToken? ct)
        where TSpec : CommandSpec<TSpec>, new()
        => CPS.Submit(array(Command), DstNode, ct).Map(x => x.FirstOrDefault());

    public static Option<CommandSubmission> Submit(this ICommandPatternSystem CPS, ICommandSpec Command, SystemNode DstNode, CorrelationToken? ct)
        => CPS.Submit(array(Command),DstNode, ct).Map(x => x.FirstOrDefault());

    /// <summary>
    /// Executes an arbitrary number of commands
    /// </summary>
    /// <param name="CPS">The command system</param>
    /// <param name="Commands">The command specifications to execute</param>
    /// <returns></returns>
    public static IEnumerable<IOption> ExecuteCommands(this ICommandPatternSystem CPS, params ICommandSpec[] Commands)
        => map(Commands, spec => CPS.ExecuteCommand(spec));

    static IConversionSuite Parsers
        = PrimitiveParsers.Projectors();

    public static CommandResult ToCommandResult<TSpec, TResult>(this Option<TResult> result, TSpec spec)
        where TSpec : CommandSpec<TSpec>, new()
        => CommandResult.FromOption(spec, result);

    public static ICommandSpec AssignArgs(this ICommandSpec command, CommandArguments args, bool defineSpecName = true)
    {
        var propIndex = command.GetType().GetPublicProperties(true, true).ToDictionary(x => x.Name.ToLower());
        foreach (var arg in args)
        {
            if (propIndex.TryGetValue(arg.Name.ToLower(), out PropertyInfo prop))
            {
                var typedVal = Parsers.Convert(prop.PropertyType, arg.Value);
                prop.SetValue(command, typedVal);
            }
        }
        if (defineSpecName)
        {
            var specNameProp = nameof(ICommandSpec.SpecName).ToLower();
            var argHash = string.Join(",", args.Select(a => $"{a.Name}:={a.Value}")).GetHashCode();
            propIndex[specNameProp].SetValue(command, $"{command.CommandName}/{argHash}");
        }
        return command;

    }

    /// <summary>
    /// Obtains a reference the Command Pattern System service
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <returns></returns>
    public static ICommandPatternSystem CPS(this IApplicationContext C)
        => C.Service<ICommandPatternSystem>();

    /// <summary>
    /// Obtains weakly-typed command processor
    /// </summary>
    /// <param name="C"></param>
    /// <param name="batchSize"></param>
    /// <param name="concurrent"></param>
    /// <returns></returns>
    public static ICommandProcessor CommandProcessor(this IApplicationContext C, int? batchSize = null, bool? concurrent = null)
        => new global::CommandProcessor(C.CPS(), batchSize, concurrent);

    /// <summary>
    /// Obtains partially-typed command processor
    /// </summary>
    /// <typeparam name="TSpec"></typeparam>
    /// <param name="C"></param>
    /// <param name="batchSize"></param>
    /// <param name="concurrent"></param>
    /// <returns></returns>
    public static ICommandProcessor<TSpec> CommandProcessor<TSpec>(this IApplicationContext C, int? batchSize = null, bool? concurrent = null)
        where TSpec : CommandSpec<TSpec>, new()
        => new global::CommandProcessor<TSpec>(C.CPS(), batchSize, concurrent);

    /// <summary>
    /// Obtains fully-typed command processor
    /// </summary>
    /// <typeparam name="TSpec"></typeparam>
    /// <typeparam name="TPayload"></typeparam>
    /// <param name="C"></param>
    /// <param name="batchSize"></param>
    /// <param name="concurrent"></param>
    /// <returns></returns>
    public static ICommandProcessor<TSpec, TPayload> CommandProcessor<TSpec, TPayload>(this IApplicationContext C, int? batchSize = null, bool? concurrent = null)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
        => new global::CommandProcessor<TSpec, TPayload>(C.CPS(), batchSize, concurrent);

    public static ICommandSpecSerializer CommandSerializer(this IApplicationContext C)
        => C.Service<ICommandSpecSerializer>();

    public static CommandSystemSettings GetCommandSystemSettings(this IApplicationContext C)
        => new CommandSystemSettings(C.ConfigurationProvider);

    public static ICommandExecStore CommandExecStore(this IApplicationContext C)
        => C.Service<ICommandExecStore>(CommandExectStoreType.Persistent)
        ?? C.Service<ICommandExecStore>(CommandExectStoreType.Transient);

    public static ICommandPatternLibrary CommandLibrary(this IApplicationContext C)
        => C.Service<ICommandPatternLibrary>();

    public static Option<ReadOnlyList<CommandSubmission<TSpec>>> Enqueue<TSpec, TPayload>(this IApplicationContext C, IEnumerable<TSpec> specs, SystemNode target)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
         => from p in C.CPS().Pattern<TSpec, TPayload>()
            from q in p.Queue.Enqueue(specs, target)
            select q;

    public static IEnumerable<CommandResult<TSpec, TPayload>> ExecuteQueue<TSpec, TPayload>(this IApplicationContext C, int MaxCount = 3, bool Concurrent = false)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
    {
        var executionService = C.CPS().Pattern<TSpec, TPayload>().Require();
        var dispatches = executionService.Queue.Dispatch(MaxCount);
        while (dispatches.Count != 0)
        {
            var results = executionService.Executor.Execute(dispatches, Concurrent);
            var completion = C.CPS().ExecStore.Complete(results).OnNone(message => C.Notify(message));
            if (completion)
            {
                foreach (var result in results)
                    yield return result;
            }
            dispatches = executionService.Queue.Dispatch(MaxCount);
        }
    }

    public static Option<ITaskAgent<P>> CreateTaskAgent<A, P>(this IApplicationContext C,
        A ComputationAgent,
        Action<P> PayloadObserver = null,
        Action<IAppMessage> MessageObserver = null)
            where A : IComputationAgent<P>
                => new TaskAgent<A, P>(ComputationAgent, PayloadObserver, MessageObserver);



}
