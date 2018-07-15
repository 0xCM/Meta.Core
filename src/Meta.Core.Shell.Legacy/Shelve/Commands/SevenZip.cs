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
    using System.Text;
    using System.Threading.Tasks;


    //See: https://info.nrao.edu/computing/guide/file-access-and-archiving/7zip/7z-7za-command-line-guide
    public class SevenZipTool : CommandSpec<SevenZipTool, FilePath>
    {
        public class ToolActionFlags
        {
            public const string AddFiles = "a";
            public const string Benchmark = "b";
            public const string DeleteFiles = "d";
            public const string ExtractFlat = "e";
            public const string Hash = "h";
            public const string Info = "i";
            public const string ListFiles = "l";
            public const string RenameFiles = "rn";
            public const string Test = "t";
            public const string UpdateFiles = "u";
            public const string ExtractFiles = "x";
        }

        public class OverwriteModeFlags
        {
            /// <summary>
            /// Overwrite all existing files without prompt
            /// </summary>
            public const string SilentOverwrite = "aoa";

            /// <summary>
            /// Skip extracting of existing files
            /// </summary>
            public const string SkipExisting = "aos";

            /// <summary>
            /// Rename existing file in lieu of overwriting it
            /// </summary>
            public const string AutoRenameExisting = "aot";

            /// <summary>
            /// Rename archived file so it doesn't clash with existing file
            /// </summary>
            public const string AutoRenameExtracting = "aou";
        }

        public enum ToolAction
        {
            None = 0,
            AddFiles = 1,
            Benchmark = 2,
            DeleteFiles = 3,
            ExtractFlat = 4,
            Hash = 5,
            Info = 6,
            ListFiles = 7,
            RenameFiles = 8,
            Test = 9,
            UpdateFiles = 10,
            ExtractFiles = 11
        }

        public ToolAction Action { get; set; }

        /// <summary>
        /// Specifies the password for the archive, if applicable
        /// </summary>
        /// <remarks>
        /// Corresponds to the -p switch
        /// </remarks>
        public string Password { get; set; }
    }

}