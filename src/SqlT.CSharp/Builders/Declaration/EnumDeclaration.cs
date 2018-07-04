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
        public static EnumDeclarationSyntax DeclareType(this EnumSpec spec)
            => spec.Declare();

        public static EnumDeclarationSyntax Declare(this EnumSpec spec)
            => EnumDeclaration(spec.Name.SimpleName)
                    .WithBaseList(BaseList(spec.GetBaseTypeSyntax().ToSingletonSeparatedList()))
                    .WithMembers(spec.DeclareMembers());

        static EnumDeclarationSyntax _BuildSyntax(this EnumSpec spec)
            => spec.Declare()
                    .WithModifiers(spec)
                    .WithAttributions(spec)
                    .WithComments(spec);

        public static EnumMemberDeclarationSyntax WithAttributions(this EnumMemberDeclarationSyntax x, EnumLiteralSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;

        public static EnumDeclarationSyntax WithAttributions(this EnumDeclarationSyntax x, EnumSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;

        static BaseTypeSyntax GetBaseTypeSyntax(this EnumSpec spec)
            => SimpleBaseType(spec.UnderlyingType.GetTypeSyntax());

        public static SeparatedSyntaxList<EnumMemberDeclarationSyntax> DeclareMembers(this EnumSpec spec)
            => SeparatedList(map(spec.Members.Cast<EnumLiteralSpec>(), l => l.Declare()));

        public static EnumMemberDeclarationSyntax Declare(this EnumLiteralSpec spec)
            => (spec.LiteralValue.IsSome()
            ? EnumMemberDeclaration(Identifier(spec.Name.SimpleName))
             .WithEqualsValue(EqualsValueClause(spec.LiteralValue.Require().BuildLiteralExpression()))
            : EnumMemberDeclaration(Identifier(spec.Name.SimpleName)))
            .WithAttributions(spec)
            .WithComments(spec);

        public static SyntaxKind[] GetModifiers(this EnumSpec spec)
            => array(spec.AccessLevel.ToSyntaxKinds());                                

        public static EnumDeclarationSyntax WithModifiers(this EnumDeclarationSyntax x, EnumSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());
    }
}