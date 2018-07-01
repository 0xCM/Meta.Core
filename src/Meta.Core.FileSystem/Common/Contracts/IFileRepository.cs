//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using N = SystemNode;

    /// <summary>
    /// Defines contract for a basic/minimal file-based repository
    /// </summary>
    public interface IFileRepository
    {
        NodeFolderPath RootLocation { get; }

        Option<NodeFilePath> Resolve(RepositoryFile DepositedFile);

        Option<RepositoryFile> Deposit(FilePath SrcFile);

        IEnumerable<FileExtension> SupportedExtensions { get; }

        IEnumerable<FolderName> TopFolderNames { get; }

        IEnumerable<RepositoryFile> DepositedFiles { get; }

        FileRepositoryNavigator Navigator { get; }

    }


}