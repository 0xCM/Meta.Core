//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

using static minicore;


public static class ScriptText
{
    static Regex regex(string pattern)
        => new Regex(pattern, RegexOptions.Compiled);

    /// <summary>
    /// Identifies script parameters of the form $(Parameter)
    /// </summary>
    static readonly Regex ParamType1 = regex(@"\$\((?<Name>(\w)*)\)");

    /// <summary>
    /// Identifies script parameters of the form @Parameter
    /// </summary>
    static readonly Regex ParamType2 = regex(@"@(?<Name>[a-zA-Z]*)");

    /// <summary>
    /// Identifies script parameters of the form %Parameter%
    /// </summary>
    static readonly Regex ParamType3 = regex(@"\%(?<Name>[a-zA-Z]*)\%");

    /// <summary>
    /// Gets the names of the script parameters implied by the script body
    /// </summary>
    /// <param name="skipSecondary">Whether type-2 parameters are to be ignored</param>
    /// <returns></returns>
    public static IEnumerable<string> GetParameterNames(string script, bool skipSecondary)
    {

        var names = new HashSet<string>();
        foreach (Match match in ParamType1.Matches(script))
            names.Add(match.GroupValue("Name"));

        if (!skipSecondary)
        {
            foreach (Match match in ParamType2.Matches(script))
                names.Add(match.GroupValue("Name"));
        }

        foreach (Match match in ParamType3.Matches(script))
            names.Add(match.GroupValue("Name"));

        return names;
    }

    public static IEnumerable<string> GetType2ParameterNames(string script)
    {
        var names = new HashSet<string>();

        foreach (Match match in ParamType2.Matches(script))
            names.Add(match.GroupValue("Name"));

        return names;
    }

    public static string SpecifyParameter(string script, string paramName, string paramValue)    
        => script.Replace($"$({paramName})", paramValue).Replace($"@{paramName}", paramValue);
    

    public static string SpecifyParametersWithObject(string script, object paramobj)
    {
        var result = script;
        foreach (var property in paramobj.GetType().GetProperties())
        {
            var paramName = property.Name;
            var paramValue = property.GetValue(paramobj)?.ToString() ?? String.Empty;
            result = SpecifyParameter(result, paramName, paramValue);
        }
        return result;
    }

    public static string SpecifyParametersWithObjects(string script, params object[] args)
    {
        var argValues = from arg in args
                        let properties = arg.GetType().GetProperties()
                        from p in properties
                        select new
                        {
                            ArgName = p.Name,
                            ArgValue = toString(p.GetValue(arg))
                        };
        var result = script;
        foreach (var argValue in argValues)
            result = SpecifyParameter(result, argValue.ArgName, argValue.ArgValue);
        return result;
    }

    public static string SpecifyParameters<T>(string script, IReadOnlyDictionary<string, T> values, bool skipSecondary)
        => GetParameterNames(script, skipSecondary).Aggregate(script,
            (input, name) => SpecifyParameter(input, name, values.ContainsKey(name) ? toString(values[name]) : String.Empty));

    public static string SpecifyEnvironmentParameters(string script)
        => GetParameterNames(script, true).Aggregate(script,
            (input, name) => Script.SpecifyParameter(input, name, Environment.GetEnvironmentVariable(name)));
}
