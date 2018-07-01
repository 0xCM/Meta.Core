//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using static metacore;

public static class FileSystemMessages
{
    public static IApplicationMessage PathDoesNotExist(string Path)
        => ApplicationMessage.Error("The path @Path does not exist",
            new
            {
                Path

            });

    public static IApplicationMessage ArchivedFolder(FolderPath Src, FilePath Dst)
                => inform($"Archived @Src to @Dst", new
                {
                    Src,
                    Dst
                });

    public static IApplicationMessage ExtractedArchive(FilePath Src, FolderPath Dst)
                => inform($"Extracted @Src to @Dst", new
                {
                    Src,
                    Dst
                });

    public static IApplicationMessage SymbolicLinkCreationFailed(FolderPath SrcFolder, FolderPath LinkPath)
        => error($"Attempt to create the {LinkPath} to {SrcFolder} failed for reasons unknown");
}

