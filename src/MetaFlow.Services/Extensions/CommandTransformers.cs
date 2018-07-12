//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;
    
    using static metacore;    

    static class CommandTransformers
    {
        static CommandSubmission DeriveSubmission(this SystemTask task, ICommandSpec spec)
            => new CommandSubmission(spec, task.TaskId, task.CommandBody, task.CorrelationToken, task.SubmittedTS);

        static CommandSubmission DeriveSubmission(this SystemTaskState state, ICommandSpec spec)
            => new CommandSubmission(spec, state.TaskId, state.CommandBody, state.CorrelationToken, state.SubmittedTS);

        static CommandSubmission<TSpec> DeriveSubmission<TSpec>(this SystemTask task, TSpec spec)
            where TSpec : CommandSpec<TSpec>, new()
            => new CommandSubmission<TSpec>(spec, task.TaskId, task.CommandBody, task.CorrelationToken, task.SubmittedTS);

        static CommandSubmission<TSpec> DeriveSubmission<TSpec>(this SystemTaskState state, TSpec spec)
            where TSpec : CommandSpec<TSpec>, new()
            => new CommandSubmission<TSpec>(spec, state.TaskId, state.CommandBody, state.CorrelationToken, state.SubmittedTS);

        static CommandDispatch DeriveDispatch(this SystemTask task, ICommandSpec spec)
            => new CommandDispatch(task.DeriveSubmission(spec), task.DispatchTS);

        public static CommandDispatch DeriveDispatch(this SystemTaskState state, ICommandSpec spec)
            => new CommandDispatch(state.DeriveSubmission(spec), state.DispatchTS);

        static CommandDispatch<TSpec> DeriveDispatch<TSpec>(this SystemTask task, TSpec spec)
            where TSpec : CommandSpec<TSpec>, new()
            => new CommandDispatch<TSpec>(task.DeriveSubmission(spec), task.DispatchTS);

        static CommandDispatch<TSpec> DeriveDispatch<TSpec>(this SystemTaskState state, TSpec spec)
            where TSpec : CommandSpec<TSpec>, new()
            => new CommandDispatch<TSpec>(state.DeriveSubmission(spec), state.DispatchTS);

        public static CommandCompletion DeriveCompletion(this SystemTaskState taskResult, ICommandSpec spec, ICommandResult result)
            => new CommandCompletion(taskResult.DeriveDispatch(spec), result, taskResult.CompleteTS);

        static CommandCompletion<TSpec, TPayload> DeriveCompletion<TSpec, TPayload>(this SystemTaskState summary, TSpec spec,
            CommandResult<TSpec, TPayload> result) where TSpec : CommandSpec<TSpec, TPayload>, new()
            => new CommandCompletion<TSpec, TPayload>(summary.DeriveDispatch(spec), result, summary.CompleteTS);
    }
}
