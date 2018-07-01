//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Linq;

using static metacore;

public sealed class CommandSpecDescriptor
{
    public static Option<CommandSpecDescriptor> TryGetFromType(Type SpecType)
        => Attribute.IsDefined(SpecType, typeof(CommandSpecAttribute)) 
        ? FromSpecType(SpecType) 
        : none<CommandSpecDescriptor>();

    public static CommandSpecDescriptor FromSpecType(Type SpecType)
    {
        var attrib = SpecType.GetCustomAttribute<CommandSpecAttribute>();
        var commandName = ifBlank(attrib?.CommandName, SpecType.FullName.Replace('.', '/'));
        return new CommandSpecDescriptor
        (
            commandName,
            SpecType,
            attrib?.CommandDescription ?? String.Empty
        );
    }

    public static CommandSpecDescriptor FromSpecType<TSpec>()
        => FromSpecType(typeof(TSpec));


    public CommandSpecDescriptor(CommandName CommandName, Type SpecType, string CommandDescription = null)
    {
        this.CommandName = CommandName;
        this.SpecType = SpecType;
        this.CommandDescription = CommandDescription ?? String.Empty;

    }

    public CommandName CommandName { get; set; }

    public Type SpecType { get; set; }

    public string CommandDescription { get; set; }

    public override string ToString()
        => CommandName.ToString();

    public string FormatDisplayString()
        => $"{CommandName} ({SpecType.FullName}): {ifBlank(CommandDescription, "UnDocumented")}";
}
