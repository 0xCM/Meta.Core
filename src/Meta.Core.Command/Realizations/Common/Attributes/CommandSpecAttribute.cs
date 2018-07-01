//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


/// <summary>
/// Applied to a command specification to identify and describe it
/// </summary>
public class CommandSpecAttribute : Attribute
{

    public CommandSpecAttribute(string CommandName = null, string CommandDescription = null)
    {
        this.CommandName = CommandName ?? String.Empty;
        this.CommandDescription = CommandDescription ??  String.Empty;
    }

    
    /// <summary>
    /// The name of the command, if different from the name of the type that represents it
    /// </summary>
    public string CommandName { get; }

    /// <summary>
    /// The purpose of the command
    /// </summary>
    public string CommandDescription { get; }
       

    public override string ToString()
        => CommandName;

}

public class CommandActionSpecAttribute : CommandSpecAttribute
{

    public CommandActionSpecAttribute(string CommandName, string ActionName)
        : base(CommandName)
    {
        this.ActionName = ActionName;
    }

    public string ActionName { get; private set; }
    public string ActionDescription { get; set; }
}
