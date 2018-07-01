//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static metacore;


public sealed class FolderPathVariable : EnvironmentVariable<FolderPath>
{
    public static implicit operator FolderPath(FolderPathVariable x)
        => x.ResolveValue().ValueOrDefault(FolderPath.Empty);

    public FolderPathVariable()
        : base(Symbol.fsep)
    {

    }

    public FolderPathVariable(string Name, bool SystemVariable = true)
        : base(Name, SystemVariable)
    {

    }

    public override Option<FolderPath> ResolveValue()
        => ReadVariable().Map(v => FolderPath.Parse(v));

}
