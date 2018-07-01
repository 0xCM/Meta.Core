//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using C = CopyFile;

    [CommandPattern]
    class CopyFileX : CommandExecutionService<CopyFileX, C, FileCopyResult>
    {

        static IApplicationMessage DestinationExists(C spec)
            => ApplicationMessage.Error($"Destination path @DstPath exists and {nameof(spec.Overwrite)} is false",
                new
                {
                    spec.DstPath
                });

        static IApplicationMessage DirectoryDoesNotExist(C spec)
            => ApplicationMessage.Error($"Destination directory @DstDir does not exist and {nameof(spec.CreateDirectory)} is false",
                new
                {
                    DstDir = Path.GetDirectoryName(spec.DstPath)
                });

        static IApplicationMessage SourceDoesNotExist(C spec)
            => ApplicationMessage.Error("The source path @SrcPath does not exist",
                new
                {
                    spec.SrcPath
                });


        public CopyFileX(IApplicationContext context)
            : base(context)
        { }

        protected override Option<FileCopyResult> TryExecute(C spec)
        {
            bool srcExists = File.Exists(spec.SrcPath);
            if (File.Exists(spec.SrcPath))
                return CommandError(SourceDoesNotExist(spec));

            bool dstExists = File.Exists(spec.DstPath);
            if (dstExists && !spec.Overwrite)
                return CommandError(DestinationExists(spec));

            if (dstExists && spec.Safe)
            {
                var backup = Path.ChangeExtension(spec.SrcPath, ".backup");
                if (File.Exists(backup))
                    File.Delete(backup);

                File.Move(spec.DstPath, backup);
            }

            var dstDir = Path.GetDirectoryName(spec.DstPath);
            if (!Directory.Exists(dstDir))
            {
                if (spec.CreateDirectory)
                    Directory.CreateDirectory(dstDir);
                else
                    return CommandError(DirectoryDoesNotExist(spec));
            }

            File.Copy(spec.SrcPath, spec.DstPath, true);
            return new FileCopyResult(spec.SrcPath, spec.DstPath, dstExists);
        }
    }
}