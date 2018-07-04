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
/// Implements a command queue via the <see cref="ICommandExecStore"/> service
/// </summary>
/// <typeparam name="TSpec"></typeparam>
public sealed class CommandQueue<TSpec> : ApplicationService<CommandQueue<TSpec>, ICommandQueue<TSpec>>, ICommandQueue<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    public CommandQueue(IApplicationContext context)
        : base(context)
    {
        this.ExecStore = C.CommandExecStore();
    }

    ICommandExecStore ExecStore { get; }
            

    Option<ReadOnlyList<CommandSubmission>> ICommandQueue.Enqueue(IEnumerable<ICommandSpec> commands, SystemNode target, CorrelationToken? ct)
        => Enqueue(commands.Cast<TSpec>(), target,  ct)
                .Map(x => 
                        x.Map(y => new CommandSubmission(y.Spec, y.SubmissionId, y.CommandJson, y.CorrelationToken, y.EnqueuedTime)));

    Option<CommandSubmission> ICommandQueue.Enqueue(ICommandSpec command, SystemNode target, CorrelationToken? ct)
        => Enqueue((TSpec)command, target, ct);

    public Option<ReadOnlyList<CommandSubmission<TSpec>>> Enqueue(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct)
        => ExecStore.Submit(commands, target, ct);

    public Option<CommandSubmission> Enqueue(TSpec command, SystemNode target, CorrelationToken? ct)
        => from result in ExecStore.Submit(roitems(command), target, ct)
           from item in result.TryGetFirst()
           select new CommandSubmission(command, item.SubmissionId, item.CommandJson, ct, item.EnqueuedTime);

    Option<CommandDispatch> ICommandQueue.Dispatch()
        => from d  in Dispatch()
           select new CommandDispatch(
            new CommandSubmission(d.Spec, d.SubmissionId, d.CommandJson, d.CorrelationToken, d.EnqueuedTime));

    ReadOnlyList <CommandDispatch> ICommandQueue.Dispatch(int count)
        => Dispatch(count).Map(d => 
            new CommandDispatch(
                new CommandSubmission(d.Spec, d.SubmissionId, d.CommandJson, d.CorrelationToken, d.EnqueuedTime)));

    public void Empty() 
        => ExecStore.PurgeSubmissions(none<CommandName>());

    public Type SpecType
        => typeof(TSpec);

    public CommandName CommandName
        => CommandSpec<TSpec>.Descriptor.CommandName;

    public bool IsEmpty()
        => ExecStore.GetCurrentSubmissionCount() == 0;

    public ReadOnlyList<CommandDispatch<TSpec>> Dispatch(int count)
        =>  ExecStore.Dispatch<TSpec>(count).Items(e => Notify(e));

    public Option<CommandDispatch<TSpec>> Dispatch()
        => ExecStore.Dispatch<TSpec>();
 
    Option<ReadOnlyList<CommandSubmission<TSpec>>> ICommandQueue<TSpec>.Enqueue(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct)
        => Enqueue(commands, target, ct)
                .Map(x => x.Map(y => CommandSubmission.Create(y.Spec, y.SubmissionId, y.CommandJson, y.CorrelationToken, y.EnqueuedTime)));

    Option<CommandSubmission<TSpec>> ICommandQueue<TSpec>.Enqueue(TSpec command, SystemNode target, CorrelationToken? ct)
      => from submissions in ExecStore.Submit(stream(command), target, ct)
         select submissions.SingleOrDefault();
}
