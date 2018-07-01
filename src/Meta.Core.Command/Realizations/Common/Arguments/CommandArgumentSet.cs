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

public abstract class CommandArgumentSet<T> : ValueObject<T>
    where T : CommandArgumentSet<T>, new()
{

    static Option<CommandArgument> TryGetArgument(CommandParameterInfo p, object o)
    {
        var v = p.Accessor.GetValue(o);
        if (v != null)
        {
            var option = v as IOption;
            var actualValue = option != null ? (option.IsSome ? option.Value : null) : v;
            if (actualValue != null)
            {
                return new CommandArgument(p.ParameterName, actualValue);
            }

        }

        return null;
    }

    protected static IReadOnlyDictionary<string, CommandParameterInfo> ParameterIndex
        = dict(
            from member in typeof(T).GetValueMembers()
            let attrib = member.GetAttribute<CommandParameterAttribute>()
            where attrib.Exists
            let paramName = attrib.ValueOrDefault().ParameterName ?? member.Name
            select (paramName, new CommandParameterInfo(paramName, member))
           );

    public virtual CommandArguments GetArguments()
        => new CommandArguments(from p in ParameterIndex.Values
                                let arg = TryGetArgument(p, this)
                                where arg.Exists
                                select arg.Require());
}



