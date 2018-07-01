//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

/// <summary>
/// Identifies and describes a command that can be executed via a script
/// </summary>
[AttributeUsage(AttributeTargets.Method), Description("Identifies and describes a command that can be executed via a script")]
public class ScriptCommandMethodAttribute : Attribute
{
    public ScriptCommandMethodAttribute(string Description, string CommandName = null, bool IsProductionCommand = true)
    {
        this.Description = Description;
        this.CommandName = CommandName ?? string.Empty;
        this.IsProductionCommand = IsProductionCommand;
    }

    /// <summary>
    /// The name of the command, if specified
    /// </summary>
    public string CommandName { get; }

    /// <summary>
    /// Describes the purpose of the command
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Specifies whether the command is available in the production environment
    /// </summary>
    public bool IsProductionCommand { get; }
}

