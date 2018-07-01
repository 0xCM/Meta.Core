//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using Meta.Core;

using static metacore;

public class EnvironmentVariable<V>
{
    public EnvironmentVariable()
    {

    }

    protected EnvironmentVariable(string Name, bool IsSystemVariable = true)
        //: base(Name)
    {
        this.IsSystemVariable = IsSystemVariable;
        this.VariableName = Name;
    }

    public string Format()
        => NameParameter;

    public string VariableName { get; }

    public bool IsSystemVariable { get; }

    public string NameParameter
        => $"$({VariableName})";

    protected EnvironmentVariableTarget VariableTarget
        => IsSystemVariable
        ? EnvironmentVariableTarget.Machine
        : EnvironmentVariableTarget.User;

    protected Option<string> ReadVariable()
    {
        var val = Environment.GetEnvironmentVariable(VariableName, VariableTarget);
        if (isBlank(val))
            return none<string>();
        else
            return val;
    }

    public virtual Option<V> ResolveValue()
        => try_parse<V>(ReadVariable().ValueOrDefault());

    public override string ToString()
        => NameParameter;
}

public sealed class EnvironmentVariable : EnvironmentVariable<string>
{

    public static implicit operator string(EnvironmentVariable v)
        => Environment.GetEnvironmentVariable(v.VariableName);

    public EnvironmentVariable()
    {

    }

    public EnvironmentVariable(string Name, bool IsSystemVariable = true)
        : base(Name, IsSystemVariable)
    {

    }

    public override Option<string> ResolveValue()
    {
        var value = Environment.GetEnvironmentVariable(VariableName, VariableTarget);
        if (isBlank(value))
            return none<string>();
        else
            return value;
    }

        

}

