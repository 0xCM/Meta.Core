//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;

/// <summary>
/// Defines contract that is responsible for searching the set of known patterns and retrieving an
/// identified subset thereof
/// </summary>
public interface ICommandPatternLibrary
{
    /// <summary>
    /// Retrieves the identified <see cref="CommandExecDescriptor"/> if a match could be found
    /// </summary>
    /// <param name="CommandName">The name of the comand</param>
    /// <returns></returns>
    Option<CommandExecDescriptor> PatternDescriptor(CommandName CommandName);

    /// <summary>
    /// Attempts to retrieve the pattern descriptor for the identified command
    /// </summary>
    /// <returns></returns>
    Option<CommandExecDescriptor> PatternDescriptor(Type SpecType);

    /// <summary>
    /// Retrieves the descriptors of all known patterns
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<CommandExecDescriptor> PatternDescriptors();

    /// <summary>
    /// Retrieves the descriptors of all known specifications
    /// </summary>
    /// <returns></returns>
    IReadOnlyDictionary<CommandName, CommandSpecDescriptor> SpecDescriptors();


    /// <summary>
    /// Attempts to retrieve the specification descriptor for the identified command
    /// </summary>
    /// <returns></returns>
    Option<CommandSpecDescriptor> SpecDescriptor(CommandName CommandName);


    /// <summary>
    /// Attempts to retrieve the specification descriptor for the identified command
    /// </summary>
    /// <returns></returns>
    Option<CommandSpecDescriptor> SpecDescriptor(Type SpecType);

    /// <summary>
    /// Attempts to retrieve the specification descriptor for the identified command
    /// </summary>
    /// <returns></returns>
    Option<CommandSpecDescriptor> SpecDescriptor<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Attempts to locate the pattern related to the supplied specification type
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService> Pattern(Type SpecType);

    /// <summary>
    /// Attempts to locate the pattern for the identified command
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService> Pattern(CommandName Name);

    /// <summary>
    /// Retrieves the identified pattern
    /// </summary>
    /// <returns></returns>
    Option<ICommandExecutionService<TSpec>> Pattern<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    /// <summary>
    /// Retrieves the identifid pattern
    /// </summary>
    /// <typeparam name="TSpec">The command specification type</typeparam>
    /// <typeparam name="TPayload">The command result type</typeparam>
    /// <returns></returns>
    Option<ICommandExecutionService<TSpec, TPayload>> Pattern<TSpec, TPayload>()
        where TSpec : CommandSpec<TSpec, TPayload>, new();

    /// <summary>
    /// Retrieves all patterns known the the provider
    /// </summary>
    /// <returns></returns>
    IEnumerable<ICommandExecutionService> Patterns();

    /// <summary>
    /// Searches through the types in the suppiled assemblies for command pattern constituents
    /// and incorporates discovered elements into the library index
    /// </summary>
    /// <param name="assemblies"></param>
    void Absorb(IEnumerable<Assembly> assemblies);

    /// <summary>
    /// Searches through the supplied types for command pattern constituents
    /// and incorporates discovered elements into the library index
    /// </summary>
    /// <param name="types"></param>
    void Absorb(IEnumerable<Type> types);


}
