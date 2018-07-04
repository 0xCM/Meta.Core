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
        public static ConstructorDeclarationSyntax Declare(this DefaultConstructorSpec spec)
            => ConstructorDeclaration(spec.Name.SimpleName)
               .WithModifiers(spec)
               .WithAttributions(spec)
               .WithComments(spec)
               .WithBody(Block());

        public static ConstructorDeclarationSyntax WithAttributions(this ConstructorDeclarationSyntax x, ConstructorSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;

        public static ConstructorDeclarationSyntax WithParameters(this ConstructorDeclarationSyntax syntax, ConstructorSpec spec)
            => spec.MethodParameters.Count != 0 ?
            syntax.WithParameterList(ParameterList(spec.DeclareParameters().ToSeparatedList())) 
            : syntax;

        public static ConstructorDeclarationSyntax WithModifiers(this ConstructorDeclarationSyntax x, ConstructorSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());
    }

}