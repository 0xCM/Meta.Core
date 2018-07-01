//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public sealed class CommandExecutorName : SemanticIdentifier<CommandExecutorName, string>
{
    public static implicit operator CommandExecutorName(string x)
        => new CommandExecutorName(x);

    public static explicit operator SystemUri(CommandExecutorName x)
        => SystemUri.Define(
            scheme: "command.exec",
            host: "exec",
            path: x.IdentifierText
            );

    protected override CommandExecutorName New(string IdentifierText)
        => new CommandExecutorName(IdentifierText);

    CommandExecutorName()
        : this(String.Empty)
    { }

    public CommandExecutorName(string Value)
        : base(Value ?? String.Empty)
    { }


}

