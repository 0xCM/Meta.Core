//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    partial class BuildSyntax
    {
        public sealed class CopyTask : BuildTask<CopyTask>
        {
            public CopyTask(string Label, int? LineNumber = null)
                :base(new ElementDescriptor("Copy",Label,LineNumber))
            {
                this.SourceFiles = new FileGlobPatterns();
                this.DestinationFiles = rolist<FilePath>();
                this.DestinationFolder = FolderPath.Empty;
            }

            public FileGlobPatterns SourceFiles { get; set; }

            public IReadOnlyList<FilePath> DestinationFiles { get; set; }

            public FolderPath DestinationFolder { get; set; }

            public bool SkipUnchangedFiles { get; set; }
        }

    }
}
