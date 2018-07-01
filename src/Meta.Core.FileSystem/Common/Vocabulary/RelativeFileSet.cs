//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using static metacore;

/// <summary>
/// Defines a set of files whose location is expressed relative to a given root folder
/// </summary>
public sealed class RelativeFileSet : ValueObject<RelativeFileSet>
{
    public RelativeFileSet(FolderPath RootFolder, IEnumerable<RelativePath> Files)
    {
        this.RootFolder = RootFolder;
        this.Files = rovalues(Files);
    }

    public FolderPath RootFolder { get; }

    public IReadOnlyList<RelativePath> Files { get; }
}
