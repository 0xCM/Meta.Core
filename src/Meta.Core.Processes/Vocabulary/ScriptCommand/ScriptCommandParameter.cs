//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

using static metacore;

/// <summary>
/// Represents a parameter referenced in a <see cref="ScriptCommand"/>
/// </summary>
public class ScriptCommandParameter 
{

    public ScriptCommandParameter(ParameterInfo ClrParameter, string Description, string ParameterName = null)
    {
        this.ClrParameter = ClrParameter;
        this.Description = Description;
        this.ParameterName = ParameterName ?? ClrParameter.Name;
    }

    public ParameterInfo ClrParameter { get; }

    public string ParameterName { get; }

    public string Description { get; }

    public override string ToString() 
        => append
        (
            $"{ParameterName} : {ClrParameter.ParameterType.Name}",
            (isBlank(Description) ? String.Empty : $" - {Description}")
        );
}

