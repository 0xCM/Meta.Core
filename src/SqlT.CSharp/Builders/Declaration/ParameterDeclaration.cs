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
        public static ParameterSyntax WithModifiers(this ParameterSyntax x, MethodParameterSpec spec)
        {
            if (spec.IsParameterArray)
                return x.WithModifiers(TokenList(Token(SyntaxKind.ParamsKeyword)));
            else
                return x;
        }

        public static ParameterSyntax DeclareParameter(this MethodParameterSpec spec)
            => Parameter(spec.Name.ToIdentifierToken())
                    .WithAttributions(spec)
                    .WithType(spec.ParameterType.GetTypeSyntax())
                    .WithModifiers(spec);
        
        public static ParameterSyntax WithAttributions(this ParameterSyntax x, MethodParameterSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;

        public static IEnumerable<ParameterSyntax> DeclareParameters(this IEnumerable<MethodParameterSpec> parameters)
            => map(parameters.OrderBy(p => p.Position), DeclareParameter);

        public static IEnumerable<ParameterSyntax> DeclareParameters<T,N>(this MethodSpec<T,N> spec)
            where T : MethodSpec<T,N>
            where N : IClrElementName
                => spec.MethodParameters.DeclareParameters();

        public static MethodDeclarationSyntax WithParameters(this MethodDeclarationSyntax syntax,
            params MethodParameterSpec[] parameters)
                => parameters.Length != 0 
                 ?  syntax.WithParameterList(ParameterList(parameters.DeclareParameters().ToSeparatedList())) 
                 : syntax;

        public static MethodDeclarationSyntax WithAttributions(this MethodDeclarationSyntax x, MethodSpec spec)
            => spec.Attributions.Count != 0 
            ? x.WithAttributeLists(spec.Attributions.BuildAttributions()) 
            : x;
    }

}