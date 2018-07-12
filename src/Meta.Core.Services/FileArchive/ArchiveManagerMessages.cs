//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using static metacore;

    public static class ArchiveManagerMessages
    {

        public static IAppMessage AddingFileToArchive(FilePath SrcFile, FilePath DstArchive)
            => babble($"Adding {SrcFile} to {DstArchive}");

        public static IAppMessage ExtractingFile(FileName SrcFile, FilePath DstPath)
            => inform($"Extracting {SrcFile} to {DstPath}");

    }



}