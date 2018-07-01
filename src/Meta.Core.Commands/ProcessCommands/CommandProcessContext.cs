//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using static metacore;

    public class CommandProcessContext
    {
        public CommandProcessContext(params FolderPath[] SearchFolders)
        {
            this.WorkingDirectory = Environment.CurrentDirectory;
            this.SearchFolders = rolist(SearchFolders);
        }

        public FolderPath WorkingDirectory { get; }

        public IReadOnlyList<FolderPath> SearchFolders { get; }
    }
}