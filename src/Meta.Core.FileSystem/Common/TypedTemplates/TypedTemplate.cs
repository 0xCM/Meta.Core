//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;
using System.IO;

using static metacore;
using Meta.Core;

/// <summary>
/// Represents a text template predicated on a type
/// </summary>
public abstract class TypedTemplate : ITypedTemplate
{
    public enum ElementRole
    {
        /// <summary>
        /// The role of the element is unspecified
        /// </summary>
        None,
        
        /// <summary>
        /// The root of the template pattern
        /// </summary>
        Pattern,

        /// <summary>
        /// The template element defines the generation pattern for the type
        /// </summary>
        Type,

        /// <summary>
        /// The template element provides the name of a parameter that determines
        /// the generated type's specification
        /// </summary>
        SyntaxName,

        /// <summary>
        /// The template element provides the filename to use when emitting the 
        /// template (not the expansion)
        /// </summary>
        TemplateFileName
    }

    public abstract TypedTemplateDescription DescribeTemplate();
}

/// <summary>
/// Represents a text template predicated on a type
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
/// <typeparam name="S">The type on which the template is predicated</typeparam>
public abstract class TypedTemplate<T,S> : TypedTemplate 
    where T : TypedTemplate<T,S>, new()
{
    static string GetTemplatedType(string templateText)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"//Template generated at {now()}");
        sb.AppendLine("$(Header)");
        sb.AppendLine("namespace $(Namespace)");
        sb.AppendLine("{");
        sb.AppendLine("\t$(Usings)");
        sb.AppendLine();

        var lines = templateText.Split(array($"{eol()}"),
            StringSplitOptions.RemoveEmptyEntries);

        var capture = false;
        foreach (var line in lines)
        {
            if (line.Trim().Contains("//TemplatedType-Begin"))
            {
                capture = true;
                continue;
            }
            else if (line.Trim().Contains("//TemplatedType-End"))
                break;

            if (capture)
                sb.AppendLine($"{line}");
        }
        sb.AppendLine("}");

        return sb.ToString();
    }

    public override TypedTemplateDescription DescribeTemplate()
    {
        var containerType = typeof(T);
        var templateType = typeof(S);
        var subjectType = containerType.GetCustomAttribute<TypedTemplateAttribute>()?.Subject;
        var fullSubjectName = subjectType?.MapValueOrDefault(x => x.FullName, String.Empty);
        var formattedSubjectName = subjectType?.MapValueOrDefault(x => x.DisplayName(), String.Empty);
        var resid = containerType.Name.Replace("Template", String.Empty);
        var sourceText = containerType.Assembly.GetResourceText(resid);

        var attributions = (from nested in containerType.GetNestedTypes()
                            let a = nested.GetCustomAttribute<TypedTemplateAttribute>()
                            select (nested, 
                                a != null 
                                ? some(a) 
                                : none<TypedTemplateAttribute>())
                            ).ToDictionary(x => x.Item1, x => x.Item2);

        var roleidx = (from a in attributions
                       let role = a.Value.MapValueOrDefault(x => x.ElementRole, ElementRole.None)
                       where role != ElementRole.None
                       select (a.Key, role)).ToDictionary(x => x.Item1, x => x.Item2);

        var outfileParam = (from r in roleidx
                            where r.Value == ElementRole.TemplateFileName
                            select r.Key.Name).FirstOrDefault();

        var outfile = ifBlank(outfileParam, formattedSubjectName) + ".template";

        var nameTypes = (from a in attributions
                         let role = a.Value.MapValueOrDefault(x => x.ElementRole, ElementRole.None)
                         where role == ElementRole.SyntaxName
                         select a.Key).ToList();

        var parameters = MutableList.FromItems(unionize(stream(templateType.Name), map(nameTypes, t => t.Name)));
        parameters.Add("Header");
        parameters.Add("Namespace");
        parameters.Add("Usings");

        var replacements = map(parameters, n => (n, $"$({n})")).ToDictionary(x => x.Item1, x => x.Item2);
        var templateText = GetTemplatedType(sourceText.ReplaceAny(replacements));
        return new TypedTemplateDescription
        {
            SyntaxParameters = parameters.ToList(),
            TemplateFileName = outfile,
            SubjectName = fullSubjectName,
            TemplateText = templateText,
            TemplateTypeName = templateType.FullName

        };
    }

}


