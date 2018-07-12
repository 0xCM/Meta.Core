using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;



using Meta.Core;

using static metacore;

public static class CommandExectStoreType
{
    public const string Persistent = "Default";
    public const string Transient = "Transient";
    
}

[ApplicationService(CommandExectStoreType.Transient)]
public class TransientCommandExecStore : ApplicationService<TransientCommandExecStore, ICommandExecStore>, ICommandExecStore
{
    long _instanceId = 0;

    long NextSubmissionId() =>
        Interlocked.Increment(ref _instanceId);


    ConcurrentQueue<ICommandSubmission> SubmissionQueue
        = new ConcurrentQueue<ICommandSubmission>();

    ConcurrentDictionary<long, ICommandDispatch> Dispatches
        = new ConcurrentDictionary<long, ICommandDispatch>();

    ConcurrentDictionary<long, ICommandCompletion> Completions
        = new ConcurrentDictionary<long, ICommandCompletion>();

    public TransientCommandExecStore(IApplicationContext C)
        : base(C)
    {

    }
    public CommandSubmission Submit(ICommandSpec command, CorrelationToken? ct)
    {
        var submission = new CommandSubmission(command, NextSubmissionId(), 
            C.Service<IJsonSerializer>().ObjectToJson(command), ct, now());
        SubmissionQueue.Enqueue(submission);
        return submission;

    }

    Option<CommandSubmission> ICommandSubmitter.Submit(ICommandSpec command, SystemNode target, CorrelationToken? ct)
        => Submit(command, ct);


    Option<ReadOnlyList<CommandSubmission>> ICommandSubmitter.Submit(IEnumerable<ICommandSpec> commands, SystemNode target, CorrelationToken? ct)
    {
        var submissions = MutableList.Create<CommandSubmission>();
        foreach (var command in commands)
        {
            var submission = Submit(command, ct);
            SubmissionQueue.Enqueue(submission);
            submissions.Add(submission);
        }
        return ReadOnlyList.Create(submissions);
    }

    Option<ReadOnlyList<CommandSubmission<TSpec>>> ICommandSubmitter.Submit<TSpec>(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct)     
    {
        var submissions = MutableList.Create<CommandSubmission<TSpec>>();
        foreach (var command in commands)
        {
            var submission = CommandSubmission.Create(command, NextSubmissionId(), C.Service<IJsonSerializer>().ObjectToJson(command), ct, now());
            SubmissionQueue.Enqueue(submission);
            submissions.Add(submission);
        }
        return ReadOnlyList.Create(submissions);
    }

    Option<ICommandSubmission> TryDequeueSubmission()
    {
        if (SubmissionQueue.TryDequeue(out ICommandSubmission submission))
            return some(submission);
        else
            return none<ICommandSubmission>();
    }

    Option<D> TryAddDispatch<D>(D d)
        where D : ICommandDispatch
    {
        if (Dispatches.TryAdd(d.SubmissionId, d))
            return some(d);
        else
            return none<D>(AppMessage.Error("Can't add submission to dispatch queue"));
    }

    Option<ICommandDispatch> Dispatch()
     => from s in TryDequeueSubmission()
        let d = new CommandDispatch(s, now())
        from a in TryAddDispatch<ICommandDispatch>(d)
        select a;

    public Option<CommandDispatch<TSpec>> Dispatch<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => from s in TryDequeueSubmission()
           let d = new CommandDispatch<TSpec>((CommandSubmission<TSpec>)s, now())
           from a in TryAddDispatch(d)
           select a;

    ReadOnlyList<ICommandDispatch> Dispatch(int MaxCount)
    {
        var dispatched = MutableList.Create<ICommandDispatch>();
        while (dispatched.Count < MaxCount)
        {
            if (!Dispatch().OnSome(d => dispatched.Add(d)))
                break;            
        }
        return ReadOnlyList.Create(dispatched);
    }

    Option<ReadOnlyList<CommandDispatch<TSpec>>> ICommandExecStore.Dispatch<TSpec>(int MaxCount)
    {
        var dispatched = MutableList.Create<CommandDispatch<TSpec>>();
        while (dispatched.Count < MaxCount)
        {
            if (!Dispatch<TSpec>().OnSome(d => dispatched.Add(d)))
                break;
        }
        return dispatched.ToReadOnlyList();
    }
    
    Option<ReadOnlyList<ICommandDispatch>> ICommandExecStore.Dispatch(int MaxCount)
        => Dispatch(MaxCount);

    public Option<int> GetCurrentSubmissionCount()
        => SubmissionQueue.Count;

    public Option<ReadOnlyList<ICommandCompletion>> Complete(IEnumerable<ICommandResult> results)
    {
        var completions = MutableList.Create<ICommandCompletion>();
        foreach (var result in results)
        {
            if (Dispatches.TryGetValue(result.SubmissionId, out ICommandDispatch dispatched))
            {
                var completion = new CommandCompletion(dispatched, result, now());
                if (!Completions.TryAdd(result.SubmissionId, completion))
                    throw new Exception("Can't add task to the memory completion index");
                completions.Add(completion);
            }
        }

        return ReadOnlyList.Create(completions);
    }

    public Option<CommandCompletion<TSpec, TPayload>> Complete<TSpec, TPayload>(CommandResult<TSpec, TPayload> result)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
    {
        if (Dispatches.TryGetValue(result.SubmissionId, out ICommandDispatch dispatched))
        {
            var completion = CommandCompletion.Create((CommandDispatch<TSpec>)dispatched, result, now());
            if (!Completions.TryAdd(result.SubmissionId, completion))
                throw new Exception("Can't add task to the memory completion index");
            else
                return completion;
        }

        return none<CommandCompletion<TSpec, TPayload>>();
    }

    public Option<CommandCompletion<TSpec>> Complete<TSpec>(CommandResult<TSpec> result)
        where TSpec : CommandSpec<TSpec>, new()
    {
        if (Dispatches.TryGetValue(result.SubmissionId, out ICommandDispatch dispatched))
        {
            var completion = CommandCompletion.Create((CommandDispatch<TSpec>)dispatched, result, now());
            if (!Completions.TryAdd(result.SubmissionId, completion))
                throw new Exception("Can't add task to the memory completion index");
            else
                return completion;
        }

        return none<CommandCompletion<TSpec>>();
    }

    public Option<ReadOnlyList<CommandCompletion<TSpec, TPayload>>> Complete<TSpec, TPayload>(IEnumerable<CommandResult<TSpec, TPayload>> results)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
            => map(results, result => ~Complete(result));

    public Option<ICommandCompletion> Complete(ICommandResult result)
        => Complete(stream(result)).Map(x => x.FirstOrDefault());

    public Option<int> PurgeDispatches(Option<CommandName> CommandName)
    {
        var prior = Dispatches.Count;
        Dispatches = CommandName.Map(
            name => new ConcurrentDictionary<long, ICommandDispatch>
                (
                    from k in Dispatches.Keys
                    let v = Dispatches[k]
                    where v.CommandName != name
                    select new KeyValuePair<long, ICommandDispatch>(k, v)
                ),
            () => new ConcurrentDictionary<long, ICommandDispatch>());

        var current = Dispatches.Count;
        return prior - current;
    }

    public Option<int> PurgeSubmissions(Option<CommandName> CommandName)
    {
        var prior = SubmissionQueue.Count;
        SubmissionQueue = CommandName.Map(
            name
                => new ConcurrentQueue<ICommandSubmission>(SubmissionQueue.Where(x => x.CommandName != name)),
            ()
                => new ConcurrentQueue<ICommandSubmission>());

        var current = SubmissionQueue.Count;
        return prior - current;
    }

    public Option<int> PurgeCompletions(Option<CommandName> CommandName)
    {
        var prior = Completions.Count;
        Completions = CommandName.Map(
            name => new ConcurrentDictionary<long, ICommandCompletion>
                (
                    from k in Completions.Keys
                    let v = Completions[k]
                    where v.CommandName != name
                    select new KeyValuePair<long, ICommandCompletion>(k, v)
                ),
            () => new ConcurrentDictionary<long, ICommandCompletion>());

        var current = Completions.Count;
        return prior - current;
    }

    public Option<int> PurgeQueues(Option<CommandName> CommandName)
        => from x in PurgeDispatches(CommandName)
           from y in PurgeSubmissions(CommandName)
           from z in PurgeCompletions(CommandName)
           select x + y + z;
}


