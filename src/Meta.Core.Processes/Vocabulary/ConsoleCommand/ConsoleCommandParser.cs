//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public static class ConsoleCommandParser
{

    private static readonly Regex NamedValuePattern 
        = new Regex(@"\/(?<Name>[a-zA-Z]*)[:](?<Value>(.)*)", RegexOptions.Compiled);
    private static readonly Regex NamePattern 
        = new Regex(@"\/(?<Name>[a-zA-Z]*)", RegexOptions.Compiled);


    public static IReadOnlyDictionary<string,string> ParseCommand(IEnumerable<string> argExpressions, bool preserveCase = false)
    {
        var results = new Dictionary<string, string>();
        foreach (var argExpression in argExpressions)
        {
            var namedValueMatch = NamedValuePattern.Match(argExpression);
            if (namedValueMatch.Success)
            {
                var name = namedValueMatch.GroupValue("Name");
                var value = namedValueMatch.GroupValue("Value");
                var expandedValue = Script.SpecifyEnvironmentParameters(value);
                results[preserveCase ? name : name.ToLower()] = expandedValue;

            }
            else
            {
                var nameMatch = NamePattern.Match(argExpression);
                if (nameMatch.Success)
                {
                    var name = nameMatch.GroupValue("Name").ToLower();
                    results[preserveCase ? name : name.ToLower()] = string.Empty;
                }
                else
                {
                    if (results.ContainsKey(string.Empty))
                    {
                        results[string.Empty] = $"{results[string.Empty]} {argExpression}";
                    }
                    else
                    {
                        results[string.Empty] = argExpression;
                    }
                }
            }
        }
        return results;
    }

}









