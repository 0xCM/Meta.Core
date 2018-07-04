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

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
    using static ClrStructureSpec;
    using static metacore;

    /// <summary>
    /// Defines <see cref="TypeSyntax"/> factories
    /// </summary>
    public static class TypeSyntaxBuilders
    {
        static TypeSyntax ToPredefinedType(this SyntaxKind keyword, bool nullable)
            => nullable
            ? NullableType(PredefinedType(keyword.ToToken()))
            : (TypeSyntax)PredefinedType(keyword.ToToken());

        static TypeSyntax _GetTypeSyntax(this ClrNullableTypeReference spec)
            => NullableType(spec.ReferencedType.ToNameSyntax());

        static TypeSyntax _GetTypeSyntax(this ClrArrayClosure spec)
            => spec.ItemTypeName.ToUnsizedArrayType();

        static TypeSyntax _GetTypeSyntax(this ClrTypeClosure spec)
            => spec.IsGenericClosure
            ? spec.ReferencedType.ToGenericName(spec.TypeArguments.ToArray())
            : (TypeSyntax)spec.ReferencedType.ToNameSyntax();

        static TypeSyntax _GetTypeSyntax(this ClrTypeReference spec)
            => spec.ReferencedType.ToNameSyntax();

        public static TypeSyntax GetTypeSyntax(this ClrTypeReference spec)
            => spec.ReferencedType.IsSystemPrimitive()
            ? spec.ReferencedType.ToPrimitiveKeyword().ToPredefinedType(spec.IsNullable)
            : _GetTypeSyntax((dynamic)spec);

        public static TypeSyntax ToPredefinedType(this ClrType name, bool nullable)
            => name.ToPrimitiveKeyword().ToPredefinedType(nullable);

        public static TypeSyntax ReturnTypeSyntax(this MethodSpec spec)
            => spec.ReturnType.Map(x => x.GetTypeSyntax(), () => VoidSyntax);

        public static readonly TypeSyntax VoidSyntax 
            = PredefinedType(SyntaxKind.VoidKeyword.ToToken());
    }
}