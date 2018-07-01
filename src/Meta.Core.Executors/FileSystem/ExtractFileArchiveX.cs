//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;

    using static metacore;

    using C = ExtractFileArchive;
    using X = ExtractFileArchiveX;
    using R = ArchiveExtractionInfo;

    [CommandPattern]
    class ExtractFileArchiveX : CommandExecutionService<X, C, R>
    {


        IFileArchiveManager ArchiveManager { get; }


        public ExtractFileArchiveX(IApplicationContext C)
            : base(C)
        {
            ArchiveManager = C.FileArchiveManager();
        }


        protected override Option<R> TryExecute(C command)
            => ArchiveManager.ExpandArchive(command.ArchivePath, command.TargetFolder, command.Overwrite)
                             .Map(x => new R() { ArchivePath = x.Source });
    }
}