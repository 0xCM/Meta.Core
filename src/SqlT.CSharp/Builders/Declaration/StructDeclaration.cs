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
        public static StructDeclarationSyntax Declare(this StructSpec x)
            => StructDeclaration(x.Name.SimpleName);

        public static StructDeclarationSyntax WithMembers(this StructDeclarationSyntax x, StructSpec spec)
            => x.WithMembers(x.Members.Union(spec.DeclareMembers()).ToSyntaxList());

        public static StructDeclarationSyntax WithAttributions(this StructDeclarationSyntax x, StructSpec spec)
            => spec.Attributions.Count != 0 ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) : x;

        public static StructDeclarationSyntax WithModifiers(this StructDeclarationSyntax x, StructSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());

        public static SyntaxKind[] GetModifiers(this StructSpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.IsPartial)
                modifiers.Add(SyntaxKind.PartialKeyword);
            if (spec.IsStatic)
                modifiers.Add(SyntaxKind.SealedKeyword);
            return modifiers.ToArray();
        }
    }
}