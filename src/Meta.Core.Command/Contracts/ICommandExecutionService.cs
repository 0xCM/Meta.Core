//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines contract for minimally typed command services and a central figure
/// in the command orchestration drama
/// </summary>
public interface ICommandExecutionService
{
    /// <summary>
    /// Provides weakly-typed access to the submission queue
    /// </summary>
    ICommandQueue Queue { get; }

    /// <summary>
    /// Specifies the component that will supply the requisite ceremony precedent and antecedent
    /// to handler invocation
    /// </summary>
    ICommandExecutor Executor { get; }

    ///<summary>
    /// Specifies the name of the command
    ///</summary>    
    CommandName CommandName { get; }

    /// <summary>
    /// The CLR type to which the command specification is bound
    /// </summary>
    Type SpecType { get; }

    /// <summary>
    /// The CLR type to which the payload type is bound
    /// </summary>
    Type PayloadType { get; }

    /// <summary>
    /// Executes a command specification
    /// </summary>
    /// <param name="spec">The command to execute</param>
    /// <returns></returns>
    IOption TryExecute(ICommandSpec spec);

    /// <summary>
    /// Executes a command specification while supplying contextual information 
    /// specific to the command instance
    /// </summary>
    /// <param name="spec">The command to execute</param>
    /// <param name="ec">The execution context</param>
    /// <returns></returns>
    IOption TryExecute(ICommandSpec spec, CommandExecutionContext ec);

}

/// <summary>
/// Defines contract for command services that have strongly-typed specifications but weakly-typed results
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
public interface ICommandExecutionService<TSpec> : ICommandExecutionService
    where TSpec : CommandSpec<TSpec>, new()
{
    /// <summary>
    /// Provides strongly-typed access to the submission queue
    /// </summary>
    new ICommandQueue<TSpec> Queue { get; }

    /// <summary>
    /// Specifies the component that will supply the requisite ceremony precedent and antecedent
    /// to handler invocation
    /// </summary>
    new ICommandExecutor<TSpec> Executor { get; }

    /// <summary>
    /// Specifies the factory method responsible for command calculation
    /// </summary>
    CommandFactory<TSpec> Factory { get; }

    /// <summary>
    /// Executes a submitted command
    /// </summary>
    /// <param name="submission">The specification to execute</param>
    /// <returns></returns>
    Option<object> TryExecute(CommandDispatch<TSpec> submission);

    /// <summary>
    /// Executes a command specification
    /// </summary>
    /// <param name="spec">The specification to execute</param>
    /// <returns></returns>
    Option<object> TryExecute(TSpec spec);

    /// <summary>
    /// Executes a command specification while supplying contextual information 
    /// specific to the command instance
    /// </summary>
    /// <param name="spec">The command to execute</param>
    /// <param name="ec">The execution context</param>
    /// <returns></returns>
    Option<object> TryExecute(TSpec spec, CommandExecutionContext ec);

}

/// <summary>
/// Defines contract for fully-typed command pattern access
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
/// <typeparam name="TPayload">The command specification type</typeparam>
public interface ICommandExecutionService<TSpec, TPayload> : ICommandExecutionService<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{

    /// <summary>
    /// Specifies the component that will supply the requisite ceremony precedent and antecedent
    /// to handler invocation
    /// </summary>
    new ICommandExecutor<TSpec, TPayload> Executor { get; }

    /// <summary>
    /// Executes a command specification
    /// </summary>
    /// <param name="spec">The specification to execute</param>
    /// <returns></returns>
    new Option<TPayload> TryExecute(TSpec spec);

    /// <summary>
    /// Executes a command specification while supplying contextual information 
    /// specific to the command instance
    /// </summary>
    /// <param name="spec">The command to execute</param>
    /// <param name="ec">The execution context</param>
    /// <returns></returns>
    new Option<TPayload> TryExecute(TSpec spec, CommandExecutionContext ec);

    /// <summary>
    /// Executes a submitted command
    /// </summary>
    /// <param name="submission">The specification to execute</param>
    /// <returns></returns>
    new Option<TPayload> TryExecute(CommandDispatch<TSpec> submission);

}
