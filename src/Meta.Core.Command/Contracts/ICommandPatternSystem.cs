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
/// All the marbles
/// </summary>
public interface ICommandPatternSystem 
{

    /// <summary>
    /// Finds the pattern that supports the supplied specification
    /// </summary>
    /// <param name="spec">The command specification</param>
    /// <returns></returns>
    Option<ICommandExecutionService> Pattern(ICommandSpec spec);

    /// <summary>
    /// Retrieves the identified pattern, if found
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService> Pattern(Type SpecType);

    /// <summary>
    /// Retrieves the identified pattern
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService<TSpec>> Pattern<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Retrieves the identified pattern
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService<TSpec, TPayload>> Pattern<TSpec, TPayload>()
        where TSpec : CommandSpec<TSpec,TPayload>, new();

    /// <summary>
    /// Retrieves the identified executor
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <returns></returns>
    Option<ICommandExecutor<TSpec>> Executor<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Retrieves all patterns known the the provider
    /// </summary>
    /// <returns></returns>
    IEnumerable<ICommandExecutionService> Patterns();

    /// <summary>
    /// Retrieves the specifications that are maintained in the configured store
    /// </summary>
    /// <returns></returns>
    ReadOnlyList<ICommandSpec> StoredSpecs();

    /// <summary>
    /// Retrieves the identified specification from the store if it exists
    /// </summary>
    /// <param name="SpecName">The name of the specification to retrieve</param>
    /// <returns></returns>
    Option<ICommandSpec> StoredSpec(string SpecName);


    /// <summary>
    /// Retrieves the specifications that are supplied with their default values
    /// </summary>
    /// <returns></returns>
    ReadOnlyList<ICommandSpec> AvailableCommands();

    /// <summary>
    /// Saves the specifications to the configured store
    /// </summary>
    /// <param name="specs">The specifications to persist</param>
    Option<int> SaveSpecs(params ICommandSpec[] specs);

    /// <summary>
    /// Submits the specified commands to the identified queue
    /// </summary>
    /// <typeparam name="TSpec">The command specification type</typeparam>
    /// <param name="commands">The commands to submit</param>
    Option<ReadOnlyList<CommandSubmission<TSpec>>> Submit<TSpec>(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct)
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Submits each command to the appropriate queue
    /// </summary>
    /// <param name="commands">The commands to submit</param>
    Option<ReadOnlyList<CommandSubmission>> Submit(IEnumerable<ICommandSpec> commands, SystemNode target, CorrelationToken? ct);

    /// <summary>
    /// Executes all commands in the identified queue
    /// </summary>
    void ExecuteQueue<TSpec,TPayload>()
        where TSpec : CommandSpec<TSpec,TPayload>, new();

    /// <summary>
    /// Executes all commands in the identified queue
    /// </summary>
    /// <typeparam name="TSpec">Identifies the queue</typeparam>
    void ExecuteQueue<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Executes the specified command
    /// </summary>
    /// <param name="command">The command to execute</param>
    /// <param name="save">Whether the command instance should be saved to the specification store</param>
    /// <returns></returns>
    IOption ExecuteCommand(ICommandSpec command, bool save = false);

    /// <summary>
    /// Executes the specified command
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <param name="command">The command to execute</param>
    /// <param name="save">Whether the command instance should be saved to the specification store</param>
    /// <returns></returns>
    IOption ExecuteCommand<TSpec>(TSpec command, bool save = false)
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Executes the specified command
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <typeparam name="TResult">The type of value produced by a successfully executed command</typeparam>
    /// <param name="command">The command to execute</param>
    /// <param name="save">Whether the command instance should be saved to the specification store</param>
    /// <returns></returns>
    TResult ExecuteCommand<TSpec,TResult>(TSpec command, bool save = false)
        where TSpec : CommandSpec<TSpec,TResult>, new();


    /// <summary>
    /// Executes the specified command
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <typeparam name="TResult">The type of value produced by a successfully executed command</typeparam>
    /// <param name="command">The command to execute</param>
    /// <param name="save">Whether the command instance should be saved to the specification store</param>
    /// <returns></returns>
    Option<TResult> Execute<TSpec, TResult>(CommandSpec<TSpec, TResult> command, bool save = false)
        where TSpec : CommandSpec<TSpec, TResult>, new();

    /// <summary>
    /// Returns a list of all commands that are in scope
    /// </summary>
    /// <returns></returns>
    ReadOnlyList<CommandSpecDescriptor> DescribeCommands();

    /// <summary>
    /// Provides access to database command store
    /// </summary>
    ICommandStore DbCommandStore { get; }

    /// <summary>
    /// Provides access to file-based command store
    /// </summary>
    ICommandStore FileCommandStore { get; }
    
    /// <summary>
    /// Provides direct access to the command execution store
    /// </summary>
    ICommandExecStore ExecStore { get; }

    /// <summary>
    /// Attempts to retrieve the descriptor for a named command
    /// </summary>
    /// <param name="CommandName">The name of the command to describe</param>
    /// <returns></returns>
    Option<CommandSpecDescriptor> DescribeCommand(CommandName CommandName);

    /// <summary>
    /// Invokes available command factories to compute specifications
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <returns></returns>
    IEnumerable<TSpec> BuildCommands<TSpec>() 
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Retrieves a fully-typed command orchestrator
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <typeparam name="TPayload">The result type</typeparam>
    /// <param name="start"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    Option<ICommandOrchestrator<TSpec,TPayload>> Orchestrator<TSpec,TPayload>(bool start, CommandOrchestrationSettings settings)
        where TSpec : CommandSpec<TSpec,TPayload>, new();

    Option<ICommandOrchestrator> Orchestrator(Type spec, bool start, CommandOrchestrationSettings settings);

    Option<ICommandOrchestrator> Orchestrator(ICommandExecutionService pattern, bool start, CommandOrchestrationSettings settings);


    /// <summary>
    /// Retrieves the identified queue
    /// </summary>
    /// <typeparam name="TSpec">The specification type</typeparam>
    /// <returns></returns>
    ICommandQueue<TSpec> Queue<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Retrieves the identified queue
    /// </summary>
    /// <param name="CommandName">The name of the queue, eponymous with that of the command</param>
    /// <returns></returns>
    Option<ICommandQueue> Queue(CommandName CommandName);
    
    /// <summary>
    /// Removes all data from all command incoming, dispatch and history queues
    /// </summary>
    /// <remarks>
    /// Do you really want to do this?
    /// </remarks>
    Option<int> PurgeQueues();

    /// <summary>
    /// Removes all data from the identified command incoming, dispatch and history queues
    /// </summary>
    /// <remarks>
    /// Do you really want to do this?
    /// </remarks>
    Option<int> PurgeQueues<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Saves the command descriptors that are currently in scope to the store
    /// </summary>
    void UpdateCommandDescriptors();
}

