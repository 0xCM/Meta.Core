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
        public static IEnumerable<ClrItemIdentifier> GetItemArray(this IClrTypeSpec spec)
            => spec.Members.Where(x => x.IsProperty).Select(x => x.ElementName.SimpleName);

        public static IEnumerable<MemberDeclarationSyntax> DeclareCustomMembers(this IClrTypeSpec type)
        {
            foreach (var member in type.Members.Where(x => x.IsCustom))
                yield return type.DeclareCustomMember(member);            
        }

        public static MethodDeclarationSyntax DeclareCustomMember(this IClrTypeSpec type, IClrMemberSpec spec)
        {
            if (spec.CustomMember == CustomMethods.GetItemArray)
                return type.DeclareGetItemArray();
            else if (spec.CustomMember == CustomMethods.SetItemArray)
                return type.DeclareSetItemArray();
            else
                throw new NotSupportedException();                  
        }

        public static ArrayTypeSyntax GetItemArrayType()
            => ArrayType(PredefinedType(Token(SyntaxKind.ObjectKeyword)))
               .WithRankSpecifiers(
                    SingletonList(
                        ArrayRankSpecifier(
                            SingletonSeparatedList<ExpressionSyntax>(
                                OmittedArraySizeExpression()))));

        public static MethodDeclarationSyntax DeclareGetItemArray(this IClrTypeSpec type)
            => MethodDeclaration(GetItemArrayType(), Identifier(CustomMethods.GetItemArray))
                    .WithModifiers(ToTokens(SyntaxKind.PublicKeyword, SyntaxKind.OverrideKeyword))
                    .WithBody(Block(SingletonList<StatementSyntax>(
                                ReturnStatement(
                                    CreateArray(new ClrClassName("object"), type.GetItemArray())))));

        public static IEnumerable<ExpressionStatementSyntax> AssignFromArray(this IReadOnlyList<PropertySpec> properties, 
            string arrayName)
        {
            var idx = 0;
            foreach (var property in properties)
            {
                yield return
                    ExpressionStatement(
                        AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        IdentifierName(property.Name.SimpleName),
                        CastExpression(
                            property.PropertyType.GetTypeSyntax(),
                            ElementAccessExpression(
                                IdentifierName(arrayName))
                            .WithArgumentList(
                                BracketedArgumentList(
                                    SingletonSeparatedList(
                                        Argument(
                                            LiteralExpression(
                                                SyntaxKind.NumericLiteralExpression,
                                                Literal(idx++)))))))));
            }
        }


        public static MethodDeclarationSyntax DeclareSetItemArray(this IClrTypeSpec type)
            =>  MethodDeclaration(TypeSyntaxBuilders.VoidSyntax, Identifier(CustomMethods.SetItemArray))
                .WithModifiers(ToTokens(SyntaxKind.PublicKeyword, SyntaxKind.OverrideKeyword))
                .WithParameters(new MethodParameterSpec("items", new ClrArrayClosure(new ClrClassName ("object"))))
                .WithBody(Block(type.Members.OfType<PropertySpec>().ToList().AssignFromArray("items")));

        public static ConstructorDeclarationSyntax Declare(this ItemArrayConstructorSpec spec)
            => ConstructorDeclaration(spec.Name.SimpleName)
               .WithModifiers(spec)
               .WithAttributions(spec)
               .WithComments(spec)
               .WithParameters(spec)
               .WithBody(Block(spec.InitializedMembers.AssignFromArray("items")));

        public static ConstructorDeclarationSyntax Declare(this PropertyConstructorSpec spec)
            => ConstructorDeclaration(spec.Name.SimpleName)
               .WithModifiers(spec)
               .WithAttributions(spec)
               .WithComments(spec)
               .WithParameters(spec)
               .WithBody(Block
                (map(spec.InitializedMembers, member 
                        => ExpressionStatement(AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    ThisExpression(),
                                    member.Name.ToNameSyntax()),
                                member.Name.ToNameSyntax()))).ToArray()
                ));
    }
}
