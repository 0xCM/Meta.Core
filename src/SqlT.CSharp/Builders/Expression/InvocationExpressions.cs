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
  
    public static class ExpressionBuilders
    {
        static ExpressionSyntax Specify(IClrExpressionSpec spec)
            => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("That's above my pay-grade"));

        static ExpressionSyntax Specify(this LiteralValueSpec spec)
            => spec.LiteralValue.BuildLiteralExpression();

        static ArgumentListSyntax ToArgumentList(this IEnumerable<ArgumentSyntax> args)
            => ArgumentList(args.ToSeparatedList());

        static MemberAccessExpressionSyntax AccessMember(this IClrElementName type, string member)
            => MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    type.ToNameSyntax(), member.ToIdentifierName());

        static InvocationExpressionSyntax Invoke(this MemberAccessExpressionSyntax syntax, IEnumerable<MethodArgumentValueSpec> arguments)
            => InvocationExpression(syntax).WithArgumentList(arguments.Specify());

        static ArgumentSyntax SpecifyNullArgument(this MethodArgumentValueSpec spec)
            => Argument(LiteralExpression(SyntaxKind.NullLiteralExpression));

        static ArgumentSyntax Specify(this MethodArgumentValueSpec spec)
            => spec.ValueExpression.Map(value => Argument(SpecifySyntax(value)), 
                    () => SpecifyNullArgument(spec));

        static ArgumentListSyntax Specify(this IEnumerable<MethodArgumentValueSpec> specs)
            => map(specs, spec => spec.Specify()).ToArgumentList();

        static ObjectCreationExpressionSyntax WithArguments(this ObjectCreationExpressionSyntax syntax, ConstructorInvocationSpec spec)
            => spec.Arguments.Count == 0 
            ? syntax 
            : syntax.WithArgumentList(spec.Arguments.Specify());

        static ObjectCreationExpressionSyntax Specify(this ConstructorInvocationSpec spec)
            => ObjectCreationExpression(spec.TypeReference.ReferencedType.ToNameSyntax()).WithArguments(spec);

        static InvocationExpressionSyntax Specify(this MethodInvocationSpec spec)
            => spec.TypeName.AccessMember(spec.MethodName).Invoke(spec.ArgumentValues);

        public static VariableDeclaratorSyntax WithInitializer(this VariableDeclaratorSyntax syntax, FieldInitializerSpec spec)
            => syntax.WithInitializer(spec.LiteralValue
                ? EqualsValueClause((~spec.LiteralValue).SpecifySyntax())            
                : EqualsValueClause((~spec.ConstructorInvocation).SpecifySyntax()));

        public static ExpressionSyntax SpecifySyntax(this IClrExpressionSpec spec)
            => Specify((dynamic)spec);
    }


}