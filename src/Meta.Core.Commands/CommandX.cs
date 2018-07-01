//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core.Commands;

    public static class CommandX
    {
        /// <summary>
        /// Convenience method for creating <see cref="CreateFileArchive"/> commands
        /// </summary>
        /// <param name="SrcFolder"></param>
        /// <param name="DstFolder"></param>
        public static IEnumerable<CreateFileArchive> CreateFileArchiveCommands
                (this FolderPath SrcFolder, FolderPath DstFolder)
                    => CreateFileArchive.DefineZipFilesCommands(SrcFolder, DstFolder);
    }
}
