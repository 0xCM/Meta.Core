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
        public static ClassDeclarationSyntax Declare(this ClassSpec spec)
            => ClassDeclaration(spec.Name.SimpleName);

        static ClassDeclarationSyntax _BuildSyntax(this ClassSpec spec)
            => spec.Declare()
                    .WithModifiers(spec)
                    .WithAttributions(spec)
                    .WithBaseList(spec)
                    .WithComments(spec)
                    .WithMembers(spec)
                    .WithNestedTypes(spec.DeclaredTypes);

        public static ClassDeclarationSyntax WithBaseList(this ClassDeclarationSyntax syntax, ClassSpec spec)
            => spec.BaseTypes.Count != 0 || spec.ImplicitRealizations.Count != 0
             ? syntax.WithBaseList(spec.GetBaseTypes().ToBaseList())
             : syntax;

        public static ClassDeclarationSyntax WithAttributions(this ClassDeclarationSyntax x, ClassSpec spec)
            => spec.Attributions.Count != 0 ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) : x;

        public static ClassDeclarationSyntax WithMembers(this ClassDeclarationSyntax x, ClassSpec spec)
            => x.WithMembers(x.Members.Union(spec.DeclareMembers()).ToSyntaxList());

        public static ClassDeclarationSyntax WithNestedTypes(this ClassDeclarationSyntax x, IReadOnlyList<IClrTypeSpec> types)
            => types.Count == 0 ? x
             : x.WithMembers(map(types, c => BuildSyntax(c)).ToSyntaxList());

        public static ClassDeclarationSyntax WithModifiers(this ClassDeclarationSyntax x, ClassSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());

        public static SyntaxKind[] GetModifiers(this ClassSpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.IsPartial)
                modifiers.Add(SyntaxKind.PartialKeyword);
            if (spec.IsStatic)
                modifiers.Add(SyntaxKind.StaticKeyword);
            if (spec.IsSealed)
                modifiers.Add(SyntaxKind.SealedKeyword);
            if (spec.IsAbstract)
                modifiers.Add(SyntaxKind.AbstractKeyword);
            return modifiers.ToArray();
        }

    }

}