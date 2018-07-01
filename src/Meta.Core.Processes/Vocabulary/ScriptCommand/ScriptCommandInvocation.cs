//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Encapsulates a <see cref="ScriptCommand"/> together with the arguments to supply when executing
/// </summary>
public class ScriptCommandInvocation
{
    public readonly ScriptCommand Command;
    public readonly IReadOnlyList<object> Arguments;

    public ScriptCommandInvocation(ScriptCommand Command, IReadOnlyList<object> Arguments)
    {
        this.Command = Command;
        this.Arguments = Arguments;
    }

    public void Invoke(object host)
    {
        Command.Execute(host, Arguments.ToArray());
    }
}
