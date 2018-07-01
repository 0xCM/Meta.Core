//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Identifies a <see cref="CommandFactory{TSpec, TPayload}"/>
/// </summary>
public sealed class CommandFactoryIdentifier : DomainPrimitive<CommandFactoryIdentifier, string>
{
    const string DefaultFactoryName = "Default";

    public static implicit operator CommandFactoryIdentifier(string x)
        => new CommandFactoryIdentifier(x);

    public static CommandFactoryIdentifier Create(CommandName CommandName, string FactoryName = null)
        => $"{CommandName}/Factories/{FactoryName ?? DefaultFactoryName}";

    public CommandFactoryIdentifier(string Value)
        : base(Value)
    { }

}