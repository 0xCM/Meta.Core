//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static metacore;

public sealed class CommandName : SemanticIdentifier<CommandName, string>  
{
    public static implicit operator CommandName(string x) 
        => new CommandName(x);
    
    public static explicit operator SystemUri(CommandName x)
        => SystemUri.Define(
            scheme: "command.spec",
            path: x.IdentifierText
            );

    protected override CommandName New(string IdentifierText)
        => new CommandName(IdentifierText);

    CommandName()
        : this(String.Empty)
    { }

    public CommandName(string Value)
        : base(Value ?? String.Empty)
    { }

}


