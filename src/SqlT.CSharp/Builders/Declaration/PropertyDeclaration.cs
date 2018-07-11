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
        public static PropertyDeclarationSyntax Declare(this PropertySpec spec)
            => PropertyDeclaration(spec.PropertyType.GetTypeSyntax(), 
                spec.PropertyName.ToIdentifierToken())
                .WithModifiers(spec)
                .WithAccessorList(spec)
                .WithAttributions(spec)
                .WithComments(spec);

        static PropertyDeclarationSyntax _BuildSyntax(this PropertySpec spec)
            => spec.Declare()
                   .WithModifiers(spec)
                   .WithComments(spec);

        public static PropertyDeclarationSyntax WithModifiers(this PropertyDeclarationSyntax x, 
            PropertySpec spec)
                => x.WithModifiers(spec.GetModifiers().ToTokens());

        public static SyntaxKind[] GetModifiers(this PropertySpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            if (spec.AccessLevel != ClrAccessKind.Default)
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
            if (spec.IsNew)
                modifiers.Add(SyntaxKind.NewKeyword);
            return modifiers.ToArray();
        }

        public static AccessorDeclarationSyntax WithSemicolon(this AccessorDeclarationSyntax syntax)
            => syntax.WithSemicolonToken(SyntaxKind.SemicolonToken.ToToken());

        public static IEnumerable<AccessorDeclarationSyntax> DeclareAccessors(this PropertySpec spec)
        {
            if (spec.CanRead)
            {
                var modifiers =
                    spec.AccessLevel != spec.ReadAccessLevel
                    ? spec.ReadAccessLevel.ToSyntaxKinds()
                    : array<SyntaxKind>();
                var tokenList = modifiers.ToTokens();
                yield return AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithModifiers(tokenList);
            }

            if (spec.CanWrite)
            {
                var modifiers =
                    spec.AccessLevel != spec.WriteAccessLevel
                    ? spec.WriteAccessLevel.ToSyntaxKinds()
                    : array<SyntaxKind>();
                var tokenList = modifiers.ToTokens();
                yield return AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithModifiers(tokenList);
            }
        }
        public static PropertyDeclarationSyntax WithAccessorList(this PropertyDeclarationSyntax syntax, PropertySpec spec)
        {
            var accessors = new List<AccessorDeclarationSyntax>();
            if (spec.CanRead)
                accessors.Add(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolon());
            if (spec.CanWrite)
                accessors.Add(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolon());
            return syntax.WithAccessorList(AccessorList(accessors.ToSyntaxList()));
        }

        public static PropertyDeclarationSyntax WithAttributions(this PropertyDeclarationSyntax x, PropertySpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;
    }
}