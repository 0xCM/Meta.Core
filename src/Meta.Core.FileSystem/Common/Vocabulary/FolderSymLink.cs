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
    using System.IO;

    using static metacore;

    /// <summary>
    /// Represents a symbolic like to a folder
    /// </summary>
    public sealed class FolderSymLink : SymLink<FolderPath, FolderPath>
    {
        public FolderSymLink(FolderPath Src, FolderPath Link)
            : base(Src, Link)
        { }
    }
}