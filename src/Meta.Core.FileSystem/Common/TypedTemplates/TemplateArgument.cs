//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;
using static AppMessage;

/// <summary>
/// Defines a <see cref="TypedTemplate"/> argument
/// </summary>
public class TemplateArgument
{

    public static implicit operator TemplateArgument((string paramName, object argValue) x)
        => new TemplateArgument(x.paramName, x.argValue);

    public static implicit operator (string paramName, object argValue) (TemplateArgument arg)
        => (arg.ParamName, arg.ArgValue);

    public static Option<TemplateArgument> Parse(string text)
    {
        if (!(text ?? string.Empty).Contains(":="))
            return none<TemplateArgument>(Error($"No assignment specifier ':=' was detected"));

        var parts = text.Split(array(":="), StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            return none<TemplateArgument>(Error($"Expected to find an assignment expression yet found {parts.Length} components"));
        return new TemplateArgument(parts[0], parts[1]);
    }

    public TemplateArgument()
    {

    }

    public TemplateArgument(string ParamName, object ArgValue)
    {
        this.ParamName = ParamName;
        this.ArgValue = ArgValue;
    }

    public string ParamName { get; set; }

    public object ArgValue { get; set; }

    public override string ToString()
        => $"$({ParamName}) := {ArgValue}";
}
