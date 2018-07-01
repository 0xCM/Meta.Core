//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;
public sealed class CommandArgument
{
    public CommandArgument()
    { }

    public CommandArgument(string Name, object Value)
    {
        this.Name = Name;
        this.Value = Value;
    }

    public string Name { get; set; }

    public object Value { get; set; }

    public override string ToString()
        => $"{Name} := {Value}";

    public bool IsBit 
        => Value is bool;

    public T GetValue<T>() 
        => (T)Value;
}



