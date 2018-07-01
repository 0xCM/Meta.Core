//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


public sealed class CommandExecDescriptor
{

    public CommandExecDescriptor()
    { }

    public CommandExecDescriptor(Type PatternType, CommandSpecDescriptor SpecDescriptor)
    {
        this.CommandName = SpecDescriptor.CommandName;
        this.PatternType = PatternType;
        this.SpecType = SpecType;
        this.CommandDescription = SpecDescriptor.CommandDescription;
    }

    public CommandName CommandName { get; set; }

    public string CommandDescription { get; set; }

    public Type PatternType { get; set; }

    public Type SpecType { get; set; }


    public override string ToString()
        => $"{PatternType.Name}({CommandName} : {SpecType.Name})";
}
