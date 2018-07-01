//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

class CommandFactoryAdapter
{
    readonly object F0;
    readonly object F1;
    readonly object F2;

    public CommandFactoryAdapter(object F0, object F1, object F2)
    {
        this.F0 = F0;
        this.F1 = F1;
        this.F2 = F2;
    }

    public CommandFactory Factory()
        => cast<CommandFactory>(F0);

    public CommandFactory<TSpec> Factory<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => cast<CommandFactory<TSpec>>(F1);

    public CommandFactory<TSpec, TResult> Factory<TSpec, TResult>()
        where TSpec : CommandSpec<TSpec, TResult>, new()
        => cast<CommandFactory<TSpec, TResult>>(F2);

}

