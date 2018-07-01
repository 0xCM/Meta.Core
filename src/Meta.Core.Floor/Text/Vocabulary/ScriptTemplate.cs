//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.IO;

using static metacore;

/// <summary>
/// Defines a parameterized text block
/// </summary>
public class ScriptTemplate
{
    public static implicit operator ScriptTemplate(string Content)
        => Define(Content);

    public static ScriptTemplate Define(string Content, string Name = null)
        => new ScriptTemplate(Name ?? string.Empty, Content);

    public ScriptTemplate(string TemplateName, Script Content)
    {
        this.TemplateName = TemplateName;
        this.Content = Content;
    }

    /// <summary>
    /// The logical name of the template 
    /// </summary>
    public string TemplateName { get; }

    /// <summary>
    /// The parameterized content
    /// </summary>
    protected Script Content { get; }

    public override string ToString()
        => TemplateName;

    public string Expand(object parameters = null)
        => Content.SpecifyParametersWithObject(parameters ?? this);

    public string Expand(string path)
    {
        var expansion = Expand();
        File.WriteAllText(path, expansion);
        return expansion;
    }

    public string ExpandBounded(char open, char close)
    {
        var expansion = Content.Body;
        foreach(var p in GetType().GetProperties())
        {
            var value = p.GetValue(this);
            if (value == null)
                continue;

            if (value is string && isBlank(value as string))
                continue;
                
            var token = $"{open}{p.Name}{close}";
            var replacement = $"{value}";
            expansion = expansion.Replace(token, replacement);
        }
        return expansion;
    }
}

public abstract class ScriptTemplate<T> : ScriptTemplate
    where T : ScriptTemplate<T>
{

    protected ScriptTemplate()
        : base(typeof(T).Name, typeof(T).Assembly.GetResourceProvider().FindTextResource(typeof(T).Name))
       
    {

    }

    protected ScriptTemplate(string resid)
        : base(resid, typeof(T).Assembly.GetResourceProvider().FindTextResource(resid))
    {

    }
}

