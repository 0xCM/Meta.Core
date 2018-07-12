//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;

using static metacore;



/// <summary>
/// Represents a typed command specification
/// </summary>
public class CommandSpec<TSpec> : CommandArgumentSet<TSpec>, ICommandSpec<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{

    protected static IAppMessage Describe<C>(string template, C content,
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => AppMessage.Inform(template, content, callerFile, callerName);

    static IReadOnlyDictionary<string, PropertyInfo> argprops
        = typeof(TSpec).GetProperties().Select(p => (p.Name, p)).ToReadOnlyDictionary();

    public static readonly CommandSpecDescriptor Descriptor
        = CommandSpecDescriptor.FromSpecType(typeof(TSpec));

    public static readonly TSpec Empty = new TSpec();
    
    public static TSpec Expand(ICommandSpec src)
    {
        if ((src as TSpec)?.Expanded ?? false)
            return src as TSpec;

        var args = src.Arguments;
        var expansion = new TSpec
        {
            CommandName = src.CommandName,
            Expanded = true,
        };

        iter(args, arg =>
        {
            if (ParameterIndex.ContainsKey(arg.Name))
            {
                if ((arg.Value as string) != null)
                {
                    var argExpansion = ScriptText.SpecifyEnvironmentParameters((string)arg.Value);
                    expansion[arg.Name] = new CommandArgument(arg.Name, argExpansion);
                }
                else
                {
                    expansion[arg.Name] = new CommandArgument(arg.Name, arg.Value);
                }
            }

        });
        return expansion;
    }

    static string format(object o)
        => o is Date d ? d.ToIsoString() : toString(o);

    protected string FormatSpecName(params object[] coordinates)
    {
        return coordinates.Length != 0 
            ? NormalizedCommandName + enclose(string.Join(",", coordinates.Select(format)), "(", ")") 
            : NormalizedCommandName;
    }


    public static TSpec Create(IEnumerable<CommandArgument> args)
    {
        if (typeof(TSpec) == typeof(CommandArguments))
        {
            return (metacore.castItem<TSpec>(new CommandArguments(args)));
        }
        else
        {
            var _args = new TSpec();
            _args.CommandName = Descriptor.CommandName;
            foreach (var arg in args)
            {
                if (argprops.ContainsKey(arg.Name))
                    argprops[arg.Name].SetValue(_args, arg.Value);
            }

            return _args;
        }
    }

    public CommandSpec()
    {
        this.CommandName = Descriptor.CommandName;
        this.CommandDescription = Descriptor.CommandDescription;
        this.SpecName = $"{CommandName}: {DateTime.Now.ToLexicalString()}";
    }

    public CommandSpec(CommandName CommandName)
        : this()
    {
        this.CommandName = CommandName ?? Descriptor.CommandName;
        this.CommandDescription = Descriptor.CommandDescription;
    }

    
    public CommandName CommandName { get; set; }

    public string CommandDescription { get; set; }

    public string SpecName { get; set; }

    bool Expanded { get; set; }

    public bool IsEmpty 
        => ReferenceEquals(this, Empty);

    public bool IsSpecifed 
        => !IsEmpty;

    public CommandArguments Arguments 
        => GetArguments();

    public CommandSpecDescriptor Describe()
        => Descriptor;


    public virtual string CommandArea
        => CommandName.Identifier.Split('/').FirstOrDefault() ?? CommandName;

    public virtual string CommandAction
        => CommandName.Identifier.Split('/').LastOrDefault() ?? CommandName;
      

    public Option<CommandArgument> this[string argname]
    {
        get
        {
            var value = ParameterIndex.ContainsKey(argname)
                      ? ParameterIndex[argname].Accessor.GetValue(this)
                      : null;

            return value != null
                ? new CommandArgument(argname, value)
                : none<CommandArgument>();
        }
        set
        {
            
            ParameterIndex.TryFind(argname).OnSome(parameter 
                => parameter.Accessor.SetValue(this, value.MapValueOrDefault(x => x.Value, null)));
        }
    }

    ICommandSpec ICommandSpec.ExpandVariables()
        => Expand(this);

    TSpec ICommandSpec<TSpec>.ExpandVariables()
        => Expand(this);

    public virtual IAppMessage DescribeIntent()
        => Describe("Beginning execution of the @CommandName command as specified by @SpecName",
            new
            {
                CommandName,
                SpecName
            });

    protected string NormalizedCommandName
        => CommandName.Identifier.Replace('-', '_').Replace('/', '-');

    public override string ToString()
        => SpecName;

}

public abstract class CommandSpec<TSpec,TPayload> : CommandSpec<TSpec>, ICommandSpec<TSpec,TPayload>
    where TSpec : CommandSpec<TSpec,TPayload>, new()
{
    public CommandSpec()
    { }

}

