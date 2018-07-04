//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Formatting;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.CSharp.Formatting;

    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
    using static ClrStructureSpec;
    using static metacore;

    partial class SyntaxBuilders
    {
        public static CompilationUnitSyntax BuildCompilationUnit(params MemberDeclarationSyntax[] nodes)
            => CompilationUnit().WithMembers(nodes.ToSyntaxList());

        static CompilationUnitSyntax WithUsings(this CompilationUnitSyntax syntax, CodeFileSpec spec)
            => syntax.WithUsings(spec.Usings.BuildSyntaxList());

        public static CompilationUnitSyntax WithMembers(this CompilationUnitSyntax syntax, CodeFileSpec spec)
            => syntax.WithMembers(spec.ElementDefinitions.BuildSyntaxList());

        public static CompilationUnitSyntax BuildSyntax(this CodeFileSpec spec)
            => CompilationUnit().WithUsings(spec)
                                .WithMembers(spec)
                                .WithComments(spec);

        public static CompilationUnitSyntax BuildSyntax(this TypeTemplateSpec spec)
            => CSharpSyntaxTree.ParseText(spec.TemplateText).GetCompilationUnitRoot();
    }
}