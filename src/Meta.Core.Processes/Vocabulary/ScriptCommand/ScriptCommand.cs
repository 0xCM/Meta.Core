//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Meta.Core;
using static metacore;

/// <summary>
/// Represents a command that can be executed via a script
/// </summary>
public class ScriptCommand
{
    public static Option<ScriptCommandInvocation> MatchInvocation(Seq<ScriptCommand> commands, string expression)
        => from command in Match(commands, expression)
           from invocation in PrepareInvocation(command)
           select invocation;

    public static Option<(ScriptCommand, string[])> Match(Seq<ScriptCommand> commands, string expression)
    {
        var regex = new Regex(@"(?<FunctionName>[a-zA-Z]{1}[a-zA-Z0-9_]*)\((?<ArgList>(.)*)\)");
        var m = regex.Match(expression);
        if (m.HasGroupValue("FunctionName"))
        {
            var functionName = m.GetGroupValue("FunctionName");
            var functionArgs = m.HasGroupValue("ArgList") && m.GetGroupValue("ArgList") != String.Empty
                                ? m.GetGroupValue("ArgList").Split(',') : new string[0];

            var command = commands.FirstOrDefault(x => x.Name == functionName);
            if (command != null)
                return (command, functionArgs);
        }
        else
        {
            var command = commands.FirstOrDefault(x => string.Compare(x.Name, expression) == 0);
            if (command != null)
                return (command, array<string>());
        }

        return none<(ScriptCommand,string[])>();
    }


    static Option<object> ConvertArgValue(object srcValue, Type targetType)
    {
        try
        {
            if (targetType.IsDate() && srcValue != null)
                return Date.Parse($"{srcValue}");
            else
                return Convert.ChangeType(srcValue, targetType);

        }
        catch (Exception e)
        {
            return none<object>(e);
        }

    }

    public static Option<ScriptCommandInvocation> PrepareInvocation((ScriptCommand, string[]) call)
    {
        var command = call.Item1;
        var args = call.Item2;
        var argConversions = MutableList.Create<object>();
        var parameters = map(command.Parameters, p => p.ClrParameter);

        if (parameters.Count == 1 && parameters[0].ParameterType.IsArray)
        {

            var elementType = parameters[0].ParameterType.GetElementType();
            var elementValues = MutableList.Create<object>();
            foreach(var srcValue in args)
            {

                var dstValue = ConvertArgValue(srcValue, elementType)
                    .OnSome(elementValue => elementValues.Add(elementValue));
                if (!dstValue)
                    return dstValue.ToNone<ScriptCommandInvocation>();
            }

            var elementCount = elementValues.Count;
            var array = Array.CreateInstance(elementType, elementCount);           
            for(int i=0; i< elementCount; i++)
                array.SetValue(elementValues[i], i);

            return new ScriptCommandInvocation(command, metacore.roitems(array));

        }
        else
        {
            for (var i = 0; i < parameters.Count; i++)
            {
                var dstType = parameters[i].ParameterType;
                var srcValue = i < args.Length
                                ? args[i].Replace("\"", String.Empty).Replace("'", String.Empty).Trim()
                                : (parameters[i].HasDefaultValue ? parameters[i].DefaultValue : null);

                var dstValue = ConvertArgValue(srcValue, dstType)
                    .OnSome(convertedValue => argConversions.Add(convertedValue));
                if (!dstValue)
                    return dstValue.ToNone<ScriptCommandInvocation>();
            }
        }
        return new ScriptCommandInvocation(command, argConversions.ToReadOnlyList());
    }

    public static Seq<ScriptCommand> Discover(params object[] hosts)
        => from host in seq(hosts)
           from m in ClrClass.Get(host.GetType()).PublicInstanceMethods.Where(m => !m.IsGenericMethodDefinition)
           let mAttrib = m.GetCustomAttribute<ScriptCommandMethodAttribute>()
           select new ScriptCommand
           (
               Host: host,               
               ClrMethod: m,
               Description: ifNotNull(mAttrib, x => x.Description, () => String.Empty),
               CommandName: ifNotNull(mAttrib, attrib => ifBlank(attrib.CommandName, m.Name), () => m.Name),
               IsProductionCommand: ifNotNull(mAttrib, x => x.IsProductionCommand, () => true),
               Parameters: from p in m.Parameters
                           let pAttrib = p.GetCustomAttribute<ScriptCommandParameterAttribute>()
                           select new ScriptCommandParameter
                           (
                               ClrParameter: p,
                               Description: ifNotNull(pAttrib, x => x.Description, () => String.Empty),
                               ParameterName: ifNotNull(pAttrib, attrib => ifBlank(attrib.ParameterName, p.Name), () => p.Name)
                           )
           );

    public static Seq<ScriptCommand> Discover(params Type[] hosts)
        => from host in seq(hosts)
           from m in ClrClass.Get(host).PublicInstanceMethods.Where(m => !m.IsGenericMethodDefinition)
           let mAttrib = m.GetCustomAttribute<ScriptCommandMethodAttribute>()
           select new ScriptCommand
            (
                ClrMethod: m,
                Description: ifNotNull(mAttrib, x => x.Description, () => String.Empty),
                CommandName: ifNotNull(mAttrib, attrib => ifBlank(attrib.CommandName, m.Name), () => m.Name),
                IsProductionCommand: ifNotNull(mAttrib, x => x.IsProductionCommand, () => true),
                Parameters: 
                    from p in m.Parameters
                    let pAttrib = p.GetCustomAttribute<ScriptCommandParameterAttribute>()
                    select new ScriptCommandParameter
                    (
                        ClrParameter: p,
                        Description: ifNotNull(pAttrib, x => x.Description, () => String.Empty),
                        ParameterName: ifNotNull(pAttrib, attrib => ifBlank(attrib.ParameterName, p.Name), () => p.Name)
                    )
            );

    public ScriptCommand
        (
            object Host, 
            MethodInfo ClrMethod, 
            string Description, 
            string CommandName, 
            bool IsProductionCommand, 
            IEnumerable<ScriptCommandParameter> Parameters
        )
    {
        this.Host = Host;
        this.ClrMethod = ClrMethod;
        this.CommandName = CommandName;
        this.Description = Description;
        this.IsProductionCommand = IsProductionCommand;
        this.Parameters = ReadOnlyList.Create(Parameters);
    }

    public ScriptCommand(Action CommandDelegate, string Name, string Description, bool IsProductionCommand = true)
    {
        this.CommandDelegate = CommandDelegate;
        this.CommandName = Name;
        this.Description = Description;
        this.IsProductionCommand = IsProductionCommand;
        this.Parameters = ReadOnlyList.Create<ScriptCommandParameter>();
    }

    public ScriptCommand
        (
            MethodInfo ClrMethod, 
            string Description, 
            string CommandName,  
            bool IsProductionCommand, 
            IEnumerable<ScriptCommandParameter> Parameters
        )
    {
        this.ClrMethod = ClrMethod;
        this.CommandName = CommandName;
        this.Parameters = ReadOnlyList.Create(Parameters);
        this.IsProductionCommand = IsProductionCommand;
        this.Description = Description;
    }

    object Host { get; }

    Action CommandDelegate { get; }

    MethodInfo ClrMethod { get; }

    string CommandName { get; }

    public string Description { get; }

    public bool IsProductionCommand { get; }

    public IReadOnlyList<ScriptCommandParameter> Parameters { get; }

    public string Name  
        => CommandName;

    public override string ToString()
    {
        var s = Name + $"({String.Join(",", Parameters.Select(x => x.ToString()))})";
        return isBlank(Description) ? s : appendl(s, "\t-" + Description);                
    }

    public Type HostType
        => ClrMethod.DeclaringType;

    public void Execute(object host, params object[] parameters)
    {
        if (Host != null)
        {
            var methodParms = ClrMethod.GetParameters();
            if (methodParms.Length == 1 && methodParms[0].ParameterType.IsArray)
                ClrMethod.Invoke(Host, parameters.ToArray());
            else
                ClrMethod.Invoke(Host, parameters);
            return;
        }

        if (ClrMethod != null)
            ClrMethod.Invoke(host, parameters);
        else
            CommandDelegate?.Invoke();
    }
}


