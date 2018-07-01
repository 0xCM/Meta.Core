//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using System.IO;
using System.ComponentModel;

using Meta.Core;

using static metacore;

public sealed class ShellCommand : CommandSpec<ShellCommand> 
{

    public static IEnumerable<Type> DiscoverHosts(Assembly a)
        => from t in a.GetTypes()
           where not(t.IsAbstract)
            && not(t.IsGenericType)
           && t.HasAttribute<ShellCommandHostAttribute>()
           select t;

    public static IEnumerable<ShellCommandDescriptor> DiscoverCommands(Type Host)
        => from m in Host.GetPublicMethods(MemberInstanceType.Instance)
           where m.HasAttribute<ShellCommandAttribute>()
           let synonyms = m.GetCustomAttribute<ShellCommandAttribute>().Synonyms
           let description = m.GetCustomAttribute<DescriptionAttribute>()?.Description
           select new ShellCommandDescriptor(Host, m, synonyms, description);
        
    const string SpecArgName
        = "spec";

    const string DoArgName
        = "do";

    const string CommandNameMarker
        = "CommandName";

    static readonly string CommandNameMatch
        = "\"" + CommandNameMarker + "\"" + @"\s:\s" + "\"" + $"(?<{CommandNameMarker}>[0-9a-zA-Z-]*)";

    static readonly Regex CommandNameRegEx
        = new Regex(CommandNameMatch, RegexOptions.Compiled);

    readonly IReadOnlyDictionary<string, object> _Args;
    readonly Option<ICommandSpec> _Spec;

    public ShellCommand()
    { }

    public T GetArgumentValue<T>(string name)
        => _Args.ContainsKey(name) ? (T)_Args[name] : default(T);
   
    public ShellCommand(ICommandSpecSerializer serializer, IReadOnlyDictionary<string, object> arguments)
    {
       
        this._Args = arguments;
        this.CommandName = GetArgumentValue<string>(DoArgName);

        var path = HasArgument(SpecArgName)
                 ? GetArgumentValue<string>(SpecArgName)
                 : GetArgumentValue<string>(String.Empty);

        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            this._Spec = serializer.Decode(File.ReadAllText(path));
            this.SpecName = _Spec.Map(x => x.SpecName).ValueOrDefault(String.Empty);
            this.CommandName = _Spec.Map(x => x.CommandName).ValueOrDefault(String.Empty);
        }

    }

    public ShellCommand(ICommandSpec spec)
    {
        this.CommandName = spec.CommandName;
        this.SpecName = spec.SpecName;
        this._Args = spec.Arguments.ToValueIndex();
        this._Spec = some(spec);
    }

    public Option<ICommandSpec> Spec 
        => _Spec;

    public bool HasArgument(string name)
        => _Args.ContainsKey(name);

    public override CommandArguments GetArguments()
        => new CommandArguments(_Args.Select(kvp => new CommandArgument(kvp.Key, kvp.Value)));

    static string FormatArgument(string name, object value)
        => $"{name} := {value}";

    public override string ToString()
        => string.Join("; ", $"{_Args.Select(x => FormatArgument(x.Key, x.Value)).ToList()}");

}

