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
    using static ClrBehaviorSpec;
    using static metacore;

    public static class LiteralExpressionFactory
    {
        public static LiteralExpressionSyntax ToLiteralExpression(this byte value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this sbyte value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this short value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this ushort value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this int value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this uint value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this long value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this ulong value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this double value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this float value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this decimal value) 
            => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this char value) 
            => LiteralExpression(SyntaxKind.CharacterLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this string value)
            => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value));

        public static LiteralExpressionSyntax ToLiteralExpression(this bool value)
            => LiteralExpression(value 
                ? SyntaxKind.TrueLiteralExpression 
                : SyntaxKind.FalseLiteralExpression);
        
        public static LiteralExpressionSyntax BuildLiteralExpression(this CoreDataValue value)
            => ToLiteralExpression((dynamic)value.ToClrValue());

        public static LiteralExpressionSyntax SpecifySyntax(this LiteralValueSpec spec)
            => spec.LiteralValue.BuildLiteralExpression();
    }
}
