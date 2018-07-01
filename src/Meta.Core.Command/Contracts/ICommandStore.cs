//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines contract for a command (specification) repository
/// </summary>
public interface ICommandStore
{

    /// <summary>
    /// Serches the store for the named specification, of which there can be at most 1
    /// </summary>
    /// <param name="specName">The name of the specification to find</param>
    /// <typeparam name="T">The specification type</typeparam>
    /// <returns></returns>
    Option<T> FindSpec<T>(string specName) where T : CommandSpec<T>, new();

    /// <summary>
    /// Serches the store for the named specification, of which there can be at most 1
    /// </summary>
    /// <param name="specName">The name of the specification to find</param>
    /// <returns></returns>
    Option<ICommandSpec> FindSpec(string specName);

    /// <summary>
    /// Retrieves all specifications in the store
    /// </summary>
    /// <returns></returns>
    ReadOnlyList<ICommandSpec> FindSpecs();

    /// <summary>
    /// Persists a single command specification to the configured store
    /// </summary>
    /// <param name="spec">The specification to save</param>
    /// <returns></returns>
    Option<int> SaveSpec(ICommandSpec spec, FileExtension extension = null, bool FlattenHierarchy = true);

    /// <summary>
    /// Persists a single command specification to the file system under a specified root
    /// </summary>
    /// <param name="spec">The specification to save</param>
    /// <returns></returns>
    Option<FilePath> ExportSpec(ICommandSpec spec, FolderPath root, FileExtension extension = null, bool FlattenHierarchy = true);

    /// <summary>
    /// Persists a collection of command specifications to the store
    /// </summary>
    /// <param name="specs">The specifications that will be persisted</param>
    /// <returns></returns>
    Option<int> SaveSpecs(IEnumerable<ICommandSpec> specs, FileExtension extension = null, bool FlattenHierarchy = true);

    /// <summary>
    /// Saves definitions derived from the specifications
    /// </summary>
    /// <param name="specs">The specifications for which definitions will be derived</param>
    /// <returns></returns>
    Option<int> SaveDefinitions(IEnumerable<ICommandSpec> specs);

    /// <summary>
    /// Obliterates all command specifications from the store, but leaves the definitions be
    /// </summary>
    /// <returns></returns>
    Option<int> PurgeSpecs();

    /// <summary>
    /// Obliterates all command definitions within the store and, by association, all specifications as well
    /// </summary>
    /// <returns></returns>
    Option<int> PurgeDefinitions();

    /// <summary>
    /// Obliterates all command definitions and specifications within the store
    /// </summary>
    /// <returns></returns>
    Option<int> Purge();

}

public static class CommandStoreType
{
    public const string FileStore = "Default";
    public const string DbStore = nameof(DbStore);
}
