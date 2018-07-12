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

    using C = CreateFileArchive;
    using X = CreateFileArchiveX;
    using R = FileArchiveDescription;

    using Point = FilePath;
    using FlowManyToOne = Link<ReadOnlyList<FilePath>, FilePath>;

    [CommandPattern]
    class CreateFileArchiveX : CommandExecutionService<X, C, R>
    {


        static IAppMessage DestinationExists(C command)
            => AppMessage.Error($"Destination path @ArchivePath exists and {nameof(command.Overwrite)} is false",
                new
                {
                    command.ArchivePath                    
                });


        IFileArchiveManager ArchiveManager { get; }

        public CreateFileArchiveX(IApplicationContext C)
            : base(C)
        {
            ArchiveManager = C.FileArchiveManager();
        }


        IEnumerable<Point> GetFiles(IEnumerable<FolderPath> folders)
        {
            foreach (var folder in folders)
                foreach (var file in folder.Files(recursive: true))
                    yield return file;
        }

        IEnumerable<Point> GetSourcePaths(C command)
        {           
            foreach (var path in command.SourceFiles)
                yield return path;

            foreach (var path in GetFiles(command.SourceFolders))
                yield return path;
        }

        Option<FlowManyToOne> CreateArchive(IEnumerable<Point> SrcFiles, Point DstArchive)
            => ArchiveManager.CreateArchive(SrcFiles, DstArchive);

        protected override Option<R> TryExecute(C command)
        {
            try
            {
                if (command.ArchivePath.Exists())
                    if (!command.Overwrite)
                        return CommandError(DestinationExists(command));
                    else
                        command.ArchivePath.DeleteIfExists();

                return from flow in CreateArchive(GetSourcePaths(command), command.ArchivePath)
                       select new R() {ArchivePath = flow.Target};

            }
            catch (Exception e)
            {
                return none<R>(e);
            }
        }
    }
}