//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Collections.Concurrent;
    
    using static metacore;


    /// <summary>
    /// Operational contract for a Local Command Store
    /// </summary>
    public interface ILocalCommandStore : IDisposable, IApplicationComponent
    {
        FolderPath StorageRoot { get; }

        IEnumerable<ICommandSpec> StoredCommands { get; }

        Option<ICommandSpec> FindCommand(string SpecName);

        Option<T> FindCommand<T>(string SpecName)
            where T : CommandSpec<T>, new();

        Option<FolderPath> PurgeStore();

        Option<FilePath> DeleteCommand(string SpecName);

        Option<FilePath> SaveCommand(ICommandSpec Command, FileExtension Extension = null, bool FlattenHierarchy = true);
    }


}