//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class)]
public class CommandPatternAttribute : Attribute
{

    public CommandPatternAttribute()
    {

    }

    public CommandPatternAttribute(string CommandName)
    {
        this.CommandName = CommandName;
    }


    public string CommandName { get; }

    public override string ToString()
        => CommandName ?? String.Empty;
}

