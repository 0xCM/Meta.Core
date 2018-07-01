//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public sealed class TypedTemplateDescription
{

    public string TemplateTypeName { get; set; }

    public string TemplateText { get; set; }

    public string SubjectName { get; set; }

    public string Namespace { get; set; }

    /// <summary>
    /// The template element provides the filename to use when emitting the 
    /// template (not the expansion)
    /// </summary>
    public FileName TemplateFileName { get; set; }

    public IReadOnlyList<string> SyntaxParameters { get; set; }

}
