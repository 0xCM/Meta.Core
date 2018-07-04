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
        public static FieldDeclarationSyntax Declare(this FieldSpec spec)
            => spec.IsLiteral
            ? spec.BuildLiteralField()
            : spec.BuildNonLiteralField();

        public static VariableDeclaratorSyntax BuildDeclarator(this FieldSpec field)
        {
            var declarator = VariableDeclarator(field.Name.ToIdentifierToken());
            return field.FieldInitializer.Map(i => declarator.WithInitializer(i), () => declarator);
        }

        public static FieldDeclarationSyntax WithAttributions(this FieldDeclarationSyntax x, FieldSpec spec)
            => spec.Attributions.Count != 0 ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) : x;

        public static SyntaxKind[] GetModifiers(this FieldSpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.AccessLevel != ClrAccessKind.Default)
                modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            if (spec.IsConst)
                modifiers.Add(SyntaxKind.ConstKeyword);
            if (spec.IsReadOnly)
                modifiers.Add(SyntaxKind.ReadOnlyKeyword);
            if (spec.IsStatic)
                modifiers.Add(SyntaxKind.StaticKeyword);
            return modifiers.ToArray();
        }

        public static FieldDeclarationSyntax BuildNonLiteralField(this FieldSpec field)
            => FieldDeclaration(
                 VariableDeclaration(field.FieldType.GetTypeSyntax())
               .WithVariables(field.BuildDeclarator().ToSingletonSeparatedList()))
               .WithModifiers(field)
               .WithAttributions(field)
               .WithComments(field);

        public static FieldDeclarationSyntax BuildLiteralField(this FieldSpec field)
        {
            var literalValue = field.FieldInitializer.ValueOrDefault().LiteralValue.ValueOrDefault().LiteralValue;
            return FieldDeclaration(
                VariableDeclaration(literalValue.ClrType.ToPredefinedType(false))
                .WithVariables(
                    SingletonSeparatedList(VariableDeclarator(Identifier(field.Name.SimpleName))
                        .WithInitializer(EqualsValueClause(literalValue.BuildLiteralExpression())))))
                .WithModifiers(
                    ToTokens(SyntaxKind.PublicKeyword, SyntaxKind.ConstKeyword));
        }

        public static FieldDeclarationSyntax WithModifiers(this FieldDeclarationSyntax x, FieldSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());
    }

}