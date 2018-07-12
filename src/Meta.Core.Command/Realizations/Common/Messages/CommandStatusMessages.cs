//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;
using System.Diagnostics.Tracing;

using static metacore;

public static class CommandStatusMessages
{    
    static CommandStatusMessage CommandStatus(ICommandSpec spec, string template, CorrelationToken? ct = null,
        [CallerMemberName] string messageType = null)
        => new CommandStatusMessage(spec, null, EventLevel.Informational, template, ct, messageType);

    public static IAppMessage Completed(ICommandSpec spec, string Template = null)
        => CommandStatus(spec, Template ?? "The @CommandName command completed");

    public static IAppMessage SpecNotFound(string SpecName)
        => inform("The specification @SpecName could not be found", 
            new
            {
                SpecName
            });

    public static IAppMessage CommandResultComputed(ICommandResult result)
       => result.Succeeded
        ? inform("Successfully completed execution of the @CommandName with submission id @SubmissionId", new
        {
            result.Spec.CommandName,
            result.SubmissionId
        })
        : result.Message;

    public static IAppMessage CompletedCommand(ICommandCompletion completion)
       => completion.Succeeded ?
          inform($"Finished executing {completion.CommandName} command: {completion.CompleteMessage}")
        : error ($"Finished executing {completion.CommandName} command: {completion.CompleteMessage}");

    public static IAppMessage Error(this ICommandSpec spec, Exception e)
        => error("An occurred during execution of the @CommandName - @ErrorDescription: @ErrorDetail", 
            new
            {
                spec.CommandName,
                ErrorDescription = e.Message,
                ErrorDetail = e.ToString()
            });

    public static IAppMessage ExecutingCommand(ICommandSpec spec)
        => inform("Executing the @SpecName specification of the @CommandName command", new
        {
            spec.CommandName,
            spec.SpecName
        });

    public static IAppMessage CompletedCommandExecution(ICommandSpec spec, object payload = null)
        => inform($"Executed @SpecName", new
        {
            spec.CommandName,
            spec.SpecName,
            Description =  spec.ToString()
        });

    public static IAppMessage ExecutorNotFound(CommandName CommandName)
        => error("No executor for @CommandName was found",
                new
                {
                    CommandName
                });

    public static IAppMessage UnhandledExecutionError(ICommandSpec spec, Exception e)
        => error("Error executing command @CommandName: @ErrorDetail",
            new
            {
                CommandName = spec.CommandName,
                ErrorDetail = e.ToString()
            });

    public static IAppMessage EmptyCommandResult(ICommandSpec command)
        => inform($"No result available for the @CommandName command", new
        {
            CommandName = command.CommandName,
            Detail = command.ToString()
        });

    public static IAppMessage OrchestrationStartError(string CommandName, Exception e)
        => error("Could not start @CommandName orchestration, @Message - @ErrorDetails", new
        {
            CommandName,
            e.Message,
            ErrorDetails = e.ToString()
        });

    public static IAppMessage CancelingOrchestration(CommandSpecDescriptor d)
        => inform("Command orchestration for @CommandName was cancelled", new
        {
            d.CommandName
        });

    public static IAppMessage CancelledOrchestration(CommandSpecDescriptor d)
        => inform("Command orchestration for @CommandName was cancelled", new
        {
            d.CommandName
        });

    public static IAppMessage OrchestratedTasksStillExecuting(CommandSpecDescriptor d)
        => AppMessage.Warn("@CommandName commands are still executing", new
        {
            d.CommandName
        });

    public static IAppMessage EnqueuedNewCommands(CommandSpecDescriptor d, int Count)
        => AppMessage.Warn("Enqueued @Count new @CommandName commands", new
        {           
            d.CommandName,
            Count
        });

    public static IAppMessage NoCommandsAvailable(string CommandName)
        => inform("No @CommandName commands are available for scheduling", new
        {
            CommandName
        });

    public static IAppMessage CommandQueueIsEmpty(string CommandName)
        => AppMessage.Babble("The @CommandName queue is empty", new
        {
            CommandName
        });

    public static IAppMessage DispatchedCommands(string CommandName, int Count)
        => inform("Dispatched @Count @CommandName commands", new
        {
            CommandName,
            Count
        });

    public static IAppMessage OrchestrationDisabled(string CommandName)
        => inform("Orchestration for @CommandName commands is disabled", new
        {
            CommandName
        });

    public static IAppMessage CalculatingNewCommands(string CommandName)
        => inform("Calculating new @CommandName commands", new
        {
            CommandName
        });

    public static IAppMessage OrchestrationStarted(string CommandName)
        => inform("Orchestration started for @CommandName commands", new
        {
            CommandName
        });

    public static IAppMessage OrchestratorAlreadyRunning(CommandName CommandName)
        => inform("Orchestration for the @CommandName command is already underway",
            new
            {
                CommandName
            });

    public static IAppMessage StartingOrchestration(CommandName CommandName)
        => inform("Starting @CommandName command orchestration",
            new
            {
                CommandName
            });

    public static IAppMessage OrchestrationCompleted(string CommandName)
        => inform("Orchestration completed for @CommandName commands", new
        {
            CommandName
        });

    public static IAppMessage OrchestrationPausing(string CommandName, int Duration)
        => AppMessage.Babble("Orchestration for @CommandName commands pausing for @Duration ms", new
        {
            CommandName,
            Duration
        });

    public static IAppMessage OrchestrationCancellationRequestReceived(string CommandName)
        => inform("Orchestration cancellation request received for @CommandName", new
        {
            CommandName,
        });

    public static IAppMessage OrchestrationManagerCreated(string CommandName)
        => inform("Orchestration manager for @CommandName commands created", new
        {
            CommandName
        });

    public static IAppMessage CommandSucceeded(ICommandResult result)
        => inform("Executing the @SpecName specification of the @CommandName command succeeded", new
        {
            result.Spec.CommandName,
            result.Spec.SpecName
        });

    public static IAppMessage CommandFailed(ICommandResult result)
        => error("Executing the @SpecName specification of the @CommandName command failed", new
        {
            result.Spec.CommandName,
            result.Spec.SpecName
        });
   
    public static IAppMessage CommandCompletionError(ICommandResult result, IAppMessage CompletionMessage)
        => error("Successfully executed the @CommandName command but was unable to complete it: @CompletionError",
                new
                {
                    result.Spec.CommandName,
                    CompletionError = CompletionMessage.Format()
                });

    public static IAppMessage CommandExecutionAndCompletionError(ICommandResult result, IAppMessage CompletionMessage)
        => error("An error occurred while executing the @CommandName command and also unabled to complete it: Execution Error - @ExecutionError; Completion Error = @CompletionError",
            new
            {
                result.Spec.CommandName,
                ExecutionError = result.Message.Format(),
                CompletionError = CompletionMessage.Format()
            });

    public static IAppMessage PatternNotFound(ICommandSpec spec)
        => error("The pattern for the @CommandName as specified by the @SpecName spec could not be found", new
        {
            spec.CommandName,
            spec.SpecName
        });

    public static IAppMessage PatternNotFound(Type specType)
        => error("The pattern for the the specification type @SpecTypeName could not be found", new
        {
            SpecTypeName = specType
        });

    public static IAppMessage PatternNotFound(CommandName name)
        => error("The pattern for the the @CommandName command could not be found", new
        {
            CommandName = name
        });

    public static IAppMessage HandlerNotFound(string CommandName)
        => error("No handler could be found for the @CommandName command",
            new
            {
                CommandName
            });


    public static IAppMessage CapabilityNotImplemented(string CapabilityDescription)
        => error("Capability not implemented: @CapabilityDescription", new
        {
            CapabilityDescription
        });

}
