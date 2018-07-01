//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

using static metacore;

public class FileCopyResults : TypedItemList<FileCopyResults, FileCopyResult>
{
    public static implicit operator FileCopyResults(FileCopyResult[] Items)
        => Create(Items);

    public FileCopyResults() { }
}
