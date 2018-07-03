//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class ClrMethodArgumentDescription 
{
    public ClrMethodArgumentDescription(ClrMethodParameter Parameter, string ArgumentValue)
    {
        this.Method = Parameter.DeclaringMethod;
        this.ParameterName = Parameter.Name;
        this.ParameterType = Parameter.ParameterType;
        this.ArgumentValue = ArgumentValue;
    }

    public ClrMethod Method { get; }

    public ClrMethodParameterName ParameterName { get; }

    public ClrType ParameterType { get; }

    public string ArgumentValue { get; }

    public override string ToString()
        => $"{ParameterName}: {ArgumentValue}";
}

public sealed class ClrMethodArgumentDescriptions : TypedItemList<ClrMethodArgumentDescriptions, ClrMethodArgumentDescription>
{
    public static implicit operator ClrMethodArgumentDescriptions(ClrMethodArgumentDescription[] items)
        => Create(items);

    public ClrMethodArgumentDescriptions()
        : base(',')
    { }
}