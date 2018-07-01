//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using static metacore;

public sealed class CommandArguments : IEnumerable<CommandArgument>
{
    public static readonly CommandArguments Emtpy = new CommandArguments();


    public static CommandArguments FromObject(object o)
        => new CommandArguments(o.GetType().GetPropertyValues(o));

    public static implicit operator CommandArguments(CommandArgument[] args)
        => new CommandArguments(args);

    public static implicit operator CommandArguments(ReadOnlyList<CommandArgument> args)
        => new CommandArguments(args);

    readonly IReadOnlyList<CommandArgument> args;

    public CommandArguments()
    {

    }

    public CommandArguments(IReadOnlyDictionary<string, object> values)
    {
        this.args = map(values.Keys,
                        name => new CommandArgument(name, values[name]));
    }

    public CommandArguments(IEnumerable<CommandArgument> args)
    {
        this.args = args.ToList();
    }

    public IReadOnlyDictionary<string, object> ToValueIndex()
        => this.ToDictionary(x => x.Name, x => x.Value);

    public Option<string> CommandName
        => from a in args.TryGetFirst(x => x.Name == nameof(CommandName))
           select toString(a.Value);
        
    public Option<string> SpecName
        => from a in args.TryGetFirst(x => x.Name == nameof(SpecName))
           select toString(a.Value);

    public CorrelationToken? CorrelationToken
    {
        get
        {
            var value = args.FirstOrDefault(x => x.Name == nameof(CorrelationToken))?.Value;
            return (value is CorrelationToken) ? 
                (CorrelationToken?)value 
                : new CorrelationToken(value);
        }
    }
        
    IEnumerator<CommandArgument> IEnumerable<CommandArgument>.GetEnumerator()
        => args.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => args.GetEnumerator();

    public override string ToString()
        => string.Join(";", args);

    public string FormatMessage(string template)
    {
        var output = template;
        foreach (var arg in args)
            output = output.Replace(arg.Name, toString(arg.Value));
        return output;
    }

}
