//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static minicore;

public interface IScript
{
    string Body { get; }
}


/// <summary>
/// Represents a script of some sort
/// </summary>
public sealed class Script : IScript
{
    /// <summary>
    /// Implicitly converts text to a <see cref="Script"/>
    /// </summary>
    /// <param name="x">The script body</param>
    public static implicit operator Script(string x)
        => new Script(x);

    /// <summary>
    /// Implicitly converts <see cref="Script"/> to text
    /// </summary>
    /// <param name="x">The script body</param>
    public static implicit operator string(Script x)
        => x.Body;

    public static Script SpecifyParameter(Script script, string paramName, string paramValue)
        => script.SpecifyParameter(paramName, paramValue);

    public static Script SpecifyEnvironmentParameters(Script script)
        => script.SpecifyEnvironmentParameters();

    /// <summary>
    /// The script body
    /// </summary>
    public string Body { get; }

    /// <summary>
    /// Gets the names of the script parameters implied by the script body
    /// </summary>
    /// <param name="skipSecondary">Whether type-2 parameters are to be ignored</param>
    /// <returns></returns>
    public IEnumerable<string> GetParameterNames(bool skipSecondary)
        => ScriptText.GetParameterNames(Body, skipSecondary);

    /// <summary>
    /// Expands a script parameter and returns the resulting script
    /// </summary>
    /// <param name="paramName">The parameter name</param>
    /// <param name="paramValue">The replacement value</param>
    /// <returns></returns>
    public Script SpecifyParameter(string paramName, string paramValue)
    {
        var script = this;
        return script.Body.Replace($"$({paramName})", paramValue).Replace($"@{paramName}", paramValue);
    }

    public Script SpecifyParametersWithObject(object paramobj)
        => ScriptText.SpecifyParametersWithObject(this.Body, paramobj);

    public Script SpecifyParametersWithObjects(params object[] args)
        => ScriptText.SpecifyParametersWithObjects(this.Body, args);

    public Script SpecifyParameters(IEnumerable<(string paramName, object paramValue)> parameters, bool skipSecondary)
        => GetParameterNames(skipSecondary).Aggregate(Body,
             (input, name) => SpecifyParameter(input, name,
                parameters.Any(p => p.paramName == name)
              ? toString(parameters.First(p => p.paramName == name).paramValue)
              : string.Empty));
    
    public Script SpecifyParameters<T>(IReadOnlyDictionary<string, T> values, bool skipSecondary)
        => GetParameterNames(skipSecondary).Aggregate(Body,
            (input, name) => SpecifyParameter(input, name, values.ContainsKey(name) ? toString(values[name]) : String.Empty));

    public Script SpecifyEnvironmentParameters()
        => GetParameterNames(true).Aggregate(Body,
            (input, name) => SpecifyParameter(input, name, Environment.GetEnvironmentVariable(name)));

    public Script(string Body)
    {
        this.Body = Body;
    }

    public override string ToString()
        => Body;

}

