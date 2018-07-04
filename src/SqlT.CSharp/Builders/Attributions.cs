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
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    using static ClrStructureSpec;
    using static metacore;

    public static class AttributionBuilders
    {
        public static DelegateDeclarationSyntax WithAttributions(this DelegateDeclarationSyntax x, DelegateSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;
    
        public static AttributeListSyntax ToListSyntax(this SeparatedSyntaxList<AttributeSyntax> attributes)
            => AttributeList(attributes);

        public static AttributeArgumentSyntax BuildAttributeArgument(this AttributeParameterSpec spec)
            => spec.IsConstructorParameter 
            ? AttributeArgument(spec.ParameterValue.BuildLiteralExpression())
            : AttributeArgument
                (
                    NameEquals(spec.ParameterName.ToIdentifierName()), 
                    null, 
                    spec.ParameterValue.BuildLiteralExpression()
                );

        public static AttributeSyntax BuildAttribution(this AttributionSpec spec) 
            => Attribute(
                (spec.AttributeName.SimpleName.Value).Replace("Attribute", String.Empty).ToIdentifierName(),
                AttributeArgumentList(
                        map(spec.Parameters, p => p.BuildAttributeArgument()).ToSeparatedList()
                    )
                );

        public static SyntaxList<AttributeListSyntax> BuildAttributions(this IEnumerable<AttributionSpec> specs)
            => map(specs, BuildAttribution)
                    .ToSeparatedList()
                    .ToListSyntax()
                    .ToSingletonList();

    }
}
