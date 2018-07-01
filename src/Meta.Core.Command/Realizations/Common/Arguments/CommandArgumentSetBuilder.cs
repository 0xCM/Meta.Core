//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public class CommandArgumentSetBuilder<T>
    where T : CommandArgumentSet<T>, new()
{

    public static implicit operator T(CommandArgumentSetBuilder<T> builder)
        => builder.Emit();

    protected readonly T set;

    public CommandArgumentSetBuilder()
    {
        set = new T();
    }

    protected CommandArgumentSetBuilder(T spec)
    {
        this.set = spec;
    }

    public virtual T Emit()
        => set;
}
