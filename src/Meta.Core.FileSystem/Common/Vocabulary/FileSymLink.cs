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

    using static metacore;

    /// <summary>
    /// Represents a symbolic link to a file
    /// </summary>
    public sealed class FileSymLink : SymLink<FilePath, FilePath>
    {
        public FileSymLink(FilePath Src, FilePath Link)
            : base(Src, Link)
        {

        }
    }
}