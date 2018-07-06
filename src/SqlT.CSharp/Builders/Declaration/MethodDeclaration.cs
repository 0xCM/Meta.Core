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

    using Meta.Core;

    using static ClrStructureSpec;
    using static metacore;

    partial class SyntaxBuilders
    {
        public static MethodDeclarationSyntax Declare(this MethodSpec spec)
            => MethodDeclaration(spec.ReturnTypeSyntax(), spec.Name.SimpleName)
                    .WithModifiers(spec)
                    .WithParameters(spec)
                    .WithAttributions(spec)
                    .WithComments(spec)
                    .WithSemiColon();

        public static MethodDeclarationSyntax WithSemiColon(this MethodDeclarationSyntax syntax)
            => syntax.WithSemicolonToken(SyntaxKind.SemicolonToken.ToToken());

        public static MethodDeclarationSyntax WithParameters(this MethodDeclarationSyntax syntax, MethodSpec spec)
            => spec.MethodParameters.Count != 0 ?
            syntax.WithParameterList(ParameterList(spec.DeclareParameters().ToSeparatedList())) : syntax;

        public static MethodDeclarationSyntax WithModifiers<T,N>(this MethodDeclarationSyntax x, MethodSpec<T,N> spec)
            where T : MethodSpec<T,N>
            where N : IClrElementName
            => x.WithModifiers(spec.GetModifiers().ToTokens());

        static SyntaxKind[] GetModifiers<T,N>(this MethodSpec<T,N> spec)
            where T : MethodSpec<T, N>
            where N : IClrElementName
        {
            var modifiers = MutableList.Create<SyntaxKind>();
            if(spec.AccessLevel != ClrAccessKind.Default)
                modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.IsStatic)
                modifiers.Add(SyntaxKind.StaticKeyword);
            if (spec.IsAbstract)
                modifiers.Add(SyntaxKind.AbstractKeyword);
            if (spec.IsVirtual)
                modifiers.Add(SyntaxKind.VirtualKeyword);
            if (spec.IsSealed)
                modifiers.Add(SyntaxKind.SealedKeyword);
            if (spec.IsOverride)
                modifiers.Add(SyntaxKind.OverrideKeyword);
            if (spec.IsPartial)
                modifiers.Add(SyntaxKind.PartialKeyword);
            return modifiers.ToArray();
        }

    }

}