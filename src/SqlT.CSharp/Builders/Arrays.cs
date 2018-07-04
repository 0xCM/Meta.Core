//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    partial class SyntaxBuilders
    {
        public static ArrayTypeSyntax ToUnsizedArrayType(this IClrElementName name)
            => ArrayType(name.ToNameSyntax()).WithRankSpecifiers(
                    SingletonList(
                        ArrayRankSpecifier(
                            SingletonSeparatedList<ExpressionSyntax>(
                                OmittedArraySizeExpression()))));

        public static ArrayCreationExpressionSyntax CreateArray(this ArrayTypeSyntax syntax)
            => ArrayCreationExpression(syntax);

        public static ArrayCreationExpressionSyntax WithInitializer
            (this ArrayCreationExpressionSyntax syntax, IEnumerable<ClrItemIdentifier> identifiers)
            => syntax.WithInitializer(
                InitializerExpression(
                    SyntaxKind.ArrayInitializerExpression,
                    identifiers.ToIdentifierNames().ToSeparatedList<ExpressionSyntax>()
                )
            );

        public static ArrayCreationExpressionSyntax CreateArray(IClrElementName type, IEnumerable<ClrItemIdentifier> identifiers)
            => type.ToUnsizedArrayType()
                   .CreateArray()
                   .WithInitializer(identifiers);
    }
}
