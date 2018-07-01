//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using static CommandStatusMessage;
using static metacore;

/// <summary>
/// Provides capability to execute a command in-process and in-line, bypassing mediation
/// </summary>
class ImmediateExecutor : ApplicationService<ImmediateExecutor, IImmediateCommandExecutor>, IImmediateCommandExecutor
{

    IReadOnlyDictionary<CommandName, ICommandExecutionService> patterns { get; }

    long cmdid;

    ICommandSpecSerializer Serializer 
        => Service<ICommandSpecSerializer>();

    ICommandPatternLibrary PatternLibrary
        => Service<ICommandPatternLibrary>();

    public ImmediateExecutor(IApplicationContext context)
        : base(context)
            => this.patterns = PatternLibrary.Patterns().ToDictionary(x => x.CommandName);

    public bool PatternExists(CommandName CommandName)
        => patterns.ContainsKey(CommandName);

    CommandResult DoExecute(CommandDispatch dispatch)
    {
        var command = dispatch.Spec;
        if (!PatternExists(command.CommandName))
            return CommandResult.Failure(command, error($"Handler for command {command.CommandName} not found"));

        var exec = patterns[command.CommandName].TryExecute(command);
        return new CommandResult(command, exec.Value, exec.IsSome,
            exec.Message, dispatch.SubmissionId, dispatch.CorrelationToken);    
    }

    public CommandResult Execute(CommandDispatch dispatch)
        => Try(() => DoExecute(dispatch)).
                MapValueOrElse(x => x, 
                    message => CommandResult.Failure(dispatch.Spec, message));

    public IReadOnlyList<CommandResult> Execute(IEnumerable<CommandDispatch> commands, bool concurrent)
        => concurrent 
        ? commands.AsParallel().Select(Execute).ToList()
        : commands.Select(Execute).ToList();

    public IReadOnlyList<CommandResult> Execute(IEnumerable<ICommandSpec> commands,bool concurrent)
        => concurrent 
        ? commands.AsParallel().Select(Execute).ToList()
        : commands.Select(Execute).ToList();    

    public CommandResult Execute(ICommandSpec command)
    {
        var json = Serializer.Encode(command);
        var submission = new CommandSubmission(command, increment(ref cmdid), json);
        var dispatch = new CommandDispatch(submission);
        return Execute(dispatch);
    }

}
