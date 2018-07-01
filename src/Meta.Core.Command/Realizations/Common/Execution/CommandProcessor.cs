//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;



/// <summary>
/// Implements a minimalistic, weakly-typed command processor capable of handling heterogeneous specification sets
/// </summary>
public class CommandProcessor : ICommandProcessor
{

    public static ICommandProcessor Create(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
        => new CommandProcessor(CPS, BatchSize, Concurrent);

    public static ICommandProcessor<TSpec> Create<TSpec>(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
            where TSpec : CommandSpec<TSpec>, new()
        => new CommandProcessor<TSpec>(CPS, BatchSize, Concurrent);

    public static ICommandProcessor<TSpec, TPayload> Create<TSpec, TPayload>(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
            where TSpec : CommandSpec<TSpec, TPayload>, new()
        => new CommandProcessor<TSpec, TPayload>(CPS, BatchSize, Concurrent);


    public CommandProcessor(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
    {
        this.CPS = CPS;
        this.Concurrent = Concurrent ?? false;
        this.BatchSize = BatchSize ?? 1;
    }

    protected ICommandPatternSystem CPS { get; }
    protected bool Concurrent { get; }
    protected int BatchSize { get; }


    /// <summary>
    /// Synchronously processes a single command
    /// </summary>
    /// <param name="command">The command to process</param>
    /// <returns></returns>
    public CommandResult ProcessCommand(ICommandSpec command)
    {
        var completion =
            from p in CPS.Pattern(command)
            let q = p.Queue
            let x = p.Executor
            from s in q.Enqueue(command, SystemNode.Local)
            from d in q.Dispatch()
            let r = x.Execute(d)
            from c in CPS.ExecStore.Complete(r)
            select r;
        return completion.ValueOrElse(() =>
           new CommandResult(command, null, false, completion.Message, 0));

    }


    /// <summary>
    /// Synchronously (but perhaps concurrently as specified by configuration options) processes 
    /// heterogeneous command sequence
    /// </summary>
    /// <param name="commands">The command sequence to process</param>
    /// <returns></returns>
    public IEnumerable<CommandResult> ProcessCommands(IEnumerable<ICommandSpec> commands)
    {
        if (Concurrent)
            foreach (var partition in commands.Partition(BatchSize))
                foreach (var command in partition.AsParallel())
                    yield return ProcessCommand(command);
        else
            foreach (var partition in commands.Partition(BatchSize))
                foreach (var command in partition)
                    yield return ProcessCommand(command);
    }
}



/// <summary>
/// Implements a minimalistic, strongly-typed command processor that yields a weakly-typed payload
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
public class CommandProcessor<TSpec> : CommandProcessor, ICommandProcessor<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    public CommandProcessor(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
        : base(CPS, BatchSize, Concurrent)
    {
    }

    /// <summary>
    /// Synchronously processes a single command
    /// </summary>
    /// <param name="command">The command to process</param>
    /// <returns></returns>
    public CommandResult<TSpec> ProcessCommand(TSpec command)
    {
        var p = CPS.Pattern<TSpec>().Require();
        var q = p.Queue;
        var x = p.Executor;
        var completion = from s in q.Enqueue(command, SystemNode.Local)
               from d in q.Dispatch()
               let r = x.Execute(d)
               from c in CPS.ExecStore.Complete(r)
               select r;
        return completion.ValueOrElse( () =>
            new CommandResult<TSpec>(command, null, false, completion.Message, 0));
    }

    /// <summary>
    /// Synchronously (but perhaps concurrently as specified by configuration options) processes a 
    /// homogeneous command sequence
    /// </summary>
    /// <param name="commands">The command sequence to process</param>
    /// <returns></returns>
    public IEnumerable<CommandResult<TSpec>> ProcessCommands(IEnumerable<TSpec> commands)
    {
        var p = CPS.Pattern<TSpec>().Require();
        var q = p.Queue;
        var x = p.Executor;
        var s = q.Enqueue(commands,SystemNode.Local).Require();
        var d = q.Dispatch(BatchSize);
        while (d.Count != 0)
        {
            var r = x.Execute(d, Concurrent);
            var c = CPS.ExecStore.Complete(r).Require();
            foreach (var result in r)
                yield return result;
            d = q.Dispatch(BatchSize);
        }
    }

}


/// <summary>
/// Implements a minimalistic, fully-generica command processor
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
/// <typeparam name="TPayload">The type of value computed by a successfully executed command</typeparam>
public class CommandProcessor<TSpec, TPayload> : CommandProcessor<TSpec>, ICommandProcessor<TSpec, TPayload>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    
    public CommandProcessor(ICommandPatternSystem CPS, int? BatchSize = null, bool? Concurrent = null)
        : base(CPS, BatchSize, Concurrent)
    {
        
    }

    /// <summary>
    /// Synchronously processes a single command
    /// </summary>
    /// <param name="command">The command to process</param>
    /// <returns></returns>
    public new CommandResult<TSpec, TPayload> ProcessCommand(TSpec command)
    {
        var p = CPS.Pattern<TSpec, TPayload>().Require();
        var q = p.Queue;
        var x = p.Executor;
        var completion = from s in q.Enqueue(command, SystemNode.Local)
                         from d in q.Dispatch()
                         let r = x.Execute(d)
                         from c in CPS.ExecStore.Complete(r)
                         select r;
        return completion.ValueOrElse(() =>
           new CommandResult<TSpec, TPayload>(command, default(TPayload), false, completion.Message, 0));
    }


    IEnumerable<CommandResult<TSpec, TPayload>> ProcessCommandBatch(IEnumerable<TSpec> commands)
    {
        var results = (from p in CPS.Pattern<TSpec, TPayload>()
                       let q = p.Queue
                       let x = p.Executor
                       from s in q.Enqueue(commands, SystemNode.Local)
                       let d = q.Dispatch(BatchSize)
                       let r = map(d, _d => x.Execute(_d))
                       let c = map(r, _r => CPS.ExecStore.Complete(_r).Require())
                       select r).Require();
        foreach (var result in results)
            yield return result;

    }

    /// <summary>
    /// Synchronously (but perhaps concurrently as specified by configuration options) processes a 
    /// homogeneous command sequence
    /// </summary>
    /// <param name="commands">The command sequence to process</param>
    /// <returns></returns>
    public new IEnumerable<CommandResult<TSpec, TPayload>> ProcessCommands(IEnumerable<TSpec> commands)
    {

        var results = rolist(ProcessCommandBatch(commands));
        foreach (var result in results)
            yield return result;

        while (results.Count != 0)
            ProcessCommandBatch(commands);
    }
}