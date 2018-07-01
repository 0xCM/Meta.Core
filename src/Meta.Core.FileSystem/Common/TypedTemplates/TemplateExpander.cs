//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static metacore;

using Meta.Core;

/// <summary>
/// Defines <see cref="TypedTemplate"/> expansion operations
/// </summary>
public class TemplateExpander
{
    public static TemplateExpander Define(Type TemplateType, FilePath TemplateFile)
        => new TemplateExpander(TemplateType, TemplateFile);

    public static TemplateExpander Define(Type TemplateType, string TemplateText)
        => new TemplateExpander(TemplateType, TemplateText);

    public static TemplateExpander Define<T>(FilePath TemplateFile)
        => new TemplateExpander(typeof(T), TemplateFile);

    TemplateExpander(Type TemplateType, FilePath TemplateFile)
    {
        this.TemplateType = TemplateType;
        this.TemplateScript = TemplateFile.ReadAllText();

    }

    TemplateExpander(Type TemplateType, string TemplateText)
    {
        this.TemplateType = TemplateType;
        this.TemplateScript = TemplateText;
    }

    public Script TemplateScript { get; }

    public Type TemplateType { get; }

    public FileWriteResult Expand(IReadOnlyList<TemplateArgument> args, FilePath dstPath)
        => Expand(args.Select(a => (a.ParamName, a.ArgValue)).ToList(), dstPath);

    public FileWriteResult Expand(IReadOnlyList<(string paramName, object argValue)> argValues, FilePath dstPath)

    {
        var filenameSegment = argValues.First();
        var expansion = TemplateScript.SpecifyParameters(argValues, true);
        return dstPath.Write(expansion);
    }

    public FileWriteResult Expand(ITypedTemplate template, FilePath dstPath)
    {
        var description = template.DescribeTemplate();
        var argValues = mapi(description.SyntaxParameters, (i, p) => (p, (object)$"Value{i}"));
        dstPath.Write(description.TemplateText);
        var codeOutPth = dstPath.ChangeExtension("cs");
        return Expand(argValues, codeOutPth);
    }



}

