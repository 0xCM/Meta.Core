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
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    using static ClrStructureSpec;
    using static metacore;

    partial class SyntaxBuilders
    {
        public static NamespaceDeclarationSyntax WithMembers(this NamespaceDeclarationSyntax x, NamespaceSpec spec)
            => x.AddMembers(map(spec.DeclaredElements, e => e.BuildSyntax()).ToArray());

        public static NamespaceDeclarationSyntax Declare(this NamespaceSpec spec)
            => NamespaceDeclaration(spec.Name.ToNameSyntax())
                    .WithUsings(spec)
                    .WithComments(spec);

        public static NamespaceDeclarationSyntax WithUsings(this NamespaceDeclarationSyntax syntax, NamespaceSpec spec)
            => syntax.WithUsings(spec.Usings.BuildSyntaxList());

        static NamespaceDeclarationSyntax _BuildSyntax(this NamespaceSpec spec)
            => spec.Declare()
                   .WithMembers(spec);
    }
}