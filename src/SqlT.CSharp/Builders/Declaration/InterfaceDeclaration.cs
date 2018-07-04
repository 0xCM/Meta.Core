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
        public static InterfaceDeclarationSyntax Declare(this InterfaceSpec spec)
            => InterfaceDeclaration(spec.Name.SimpleName);

        static InterfaceDeclarationSyntax _BuildSyntax(this InterfaceSpec spec)
            => spec.Declare()
                    .WithModifiers(spec)
                    .WithAttributions(spec)
                    .WithBaseList(spec)
                    .WithComments(spec)
                    .WithMembers(spec);

        public static InterfaceDeclarationSyntax WithMembers(this InterfaceDeclarationSyntax x, InterfaceSpec spec)
            => x.WithMembers(x.Members.Union(spec.DeclareMembers()).ToSyntaxList());

        public static InterfaceDeclarationSyntax WithBaseList(this InterfaceDeclarationSyntax syntax, InterfaceSpec spec)
            => spec.BaseTypes.Count != 0 
            ? syntax.WithBaseList(spec.GetBaseTypes().ToBaseList()) 
            : syntax;

        public static InterfaceDeclarationSyntax WithAttributions(this InterfaceDeclarationSyntax x, InterfaceSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;

        public static InterfaceDeclarationSyntax WithModifiers(this InterfaceDeclarationSyntax x, InterfaceSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());

        public static SyntaxKind[] GetModifiers(this InterfaceSpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.IsPartial)
                modifiers.Add(SyntaxKind.PartialKeyword);
            return modifiers.ToArray();
        }
    }
}