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
    using System.Threading.Tasks;
    using System.IO;

    using static metacore;

    

    public static class AppCmdX
    {
        static IApplicationContext C;

        static IAppMessage ArchivedFolder(FolderPath Src, FilePath Dst)
                    => inform($"Archived @Src to @Dst", new
                    {
                        Src,
                        Dst
                    });

        static IAppMessage ExtractedArchive(FilePath Src, FolderPath Dst)
                    => inform($"Extracted @Src to @Dst", new
                    {
                        Src,
                        Dst
                    });

        public static void Init(IApplicationContext C)
        {
            AppCmdX.C = C;
        }


        

    }

}