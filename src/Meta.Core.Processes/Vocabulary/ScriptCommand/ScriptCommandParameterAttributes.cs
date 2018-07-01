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
/// Describes a script command parameter
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class ScriptCommandParameterAttribute : Attribute
{
    public ScriptCommandParameterAttribute(string description, string ParameterName = null)
    {
        this.Description = description;
        this.ParameterName = ParameterName ?? string.Empty;
        
    }

    /// <summary>
    /// Describes the purpose of the parameter
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The name of the parameter, if specified
    /// </summary>
    public string ParameterName { get; }
}


