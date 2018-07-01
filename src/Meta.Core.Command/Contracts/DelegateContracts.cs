//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public delegate IEnumerable<ICommandSpec> CommandFactory(IApplicationContext context);

public delegate IEnumerable<TSpec> CommandFactory<out TSpec>(IApplicationContext context)
    where TSpec : CommandSpec<TSpec>, new();

public delegate IEnumerable<TSpec> CommandFactory<out TSpec, out TPayload>(IApplicationContext context)
    where TSpec : CommandSpec<TSpec, TPayload>, new();

public delegate void CommandSpecifiedObserver<TSpec>(TSpec spec)
    where TSpec : CommandSpec<TSpec>, new();

public delegate void CommandSubmissionObserver<TSpec>(ICommandSubmission<TSpec> submission)
    where TSpec : CommandSpec<TSpec>, new();

public delegate void CommandDispatchObserver<TSpec>(ICommandDispatch<TSpec> dispatch)
    where TSpec : CommandSpec<TSpec>, new();

public delegate void CommandExecutionObserver<TSpec>(ICommandResult<TSpec> result)
    where TSpec : CommandSpec<TSpec>, new();

public delegate void CommandExecutionObserver<TSpec, TPayload>(ICommandResult<TSpec, TPayload> result)
    where TSpec : CommandSpec<TSpec, TPayload>, new();

public delegate void CommandCompletionObserver<TSpec>(ICommandCompletion<TSpec> result)
    where TSpec : CommandSpec<TSpec>, new();
