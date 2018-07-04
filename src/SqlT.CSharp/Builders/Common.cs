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
    using Microsoft.CodeAnalysis.Formatting;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.CSharp.Formatting;

    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
    using static ClrStructureSpec;
    using static metacore;

    public static partial class SyntaxBuilders
    {
        /// <summary>
        /// Defines associations between <see cref="ClrAccessKind"/> values and one or more <see cref="SyntaxKind"/> values
        /// </summary>
        static readonly IReadOnlyDictionary<ClrAccessKind, SyntaxKind[]> AccessKeywords 
            = new Dictionary<ClrAccessKind, SyntaxKind[]>
            {
                [ClrAccessKind.Internal] = array(SyntaxKind.InternalKeyword),
                [ClrAccessKind.Private] = array(SyntaxKind.PrivateKeyword),
                [ClrAccessKind.Protected] = array(SyntaxKind.ProtectedKeyword),
                [ClrAccessKind.Public] = array(SyntaxKind.PublicKeyword),
                [ClrAccessKind.Default] = array(SyntaxKind.PublicKeyword),
                [ClrAccessKind.ProtectedOrInternal] = array(SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)
            };

        /// <summary>
        /// Defines associations between CLR primitive type names and <see cref="SyntaxKind"/> values
        /// </summary>
        static readonly IReadOnlyDictionary<string, SyntaxKind> PrimitiveKeywords
            = new Dictionary<string, SyntaxKind>
            {
                [nameof(String)] = SyntaxKind.StringKeyword,
                [nameof(Char)] = SyntaxKind.CharKeyword,
                [nameof(SByte)] = SyntaxKind.SByteKeyword,
                [nameof(Boolean)] = SyntaxKind.BoolKeyword,
                [nameof(Byte)] = SyntaxKind.ByteKeyword,
                [nameof(Int32)] = SyntaxKind.IntKeyword,
                [nameof(UInt32)] = SyntaxKind.UIntKeyword,
                [nameof(Int16)] = SyntaxKind.ShortKeyword,
                [nameof(UInt16)] = SyntaxKind.UShortKeyword,
                [nameof(Int64)] = SyntaxKind.LongKeyword,
                [nameof(UInt64)] = SyntaxKind.ULongKeyword,
                [nameof(Decimal)] = SyntaxKind.DecimalKeyword,
                [nameof(Single)] = SyntaxKind.FloatKeyword,
                [nameof(Double)] = SyntaxKind.DoubleKeyword,
            };

        /// <summary>
        /// Determines whether a name identifies a system primitive type
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsSystemPrimitive(this IClrTypeName name) 
            =>  PrimitiveKeywords.ContainsKey(name.SimpleName);

        public static SeparatedSyntaxList<TNode> ToSeparatedList<TNode>(this IEnumerable<TNode> nodes)
             where TNode : SyntaxNode => SeparatedList(nodes);
       
        public static SyntaxList<TNode> ToSingletonList<TNode>(this TNode node)
             where TNode : SyntaxNode => SingletonList(node);

        public static SeparatedSyntaxList<TNode> ToSingletonSeparatedList<TNode>(this TNode node)
             where TNode : SyntaxNode => SingletonSeparatedList(node);

        public static TypeArgumentListSyntax ToListSyntax(this SeparatedSyntaxList<TypeSyntax> item) 
            => TypeArgumentList(item);       
            
        public static TypeArgumentListSyntax GetTypeArgumentList(this IEnumerable<TypeArgument> items)
            => items.Select( x => x.ArgumentValue).ToNameSyntax().ToSeparatedList<TypeSyntax>().ToListSyntax();

        public static SimpleBaseTypeSyntax ToSimpleBaseType(this GenericNameSyntax item)
            => SimpleBaseType(item);

        public static GenericNameSyntax ToGenericName(this IClrElementName name, params TypeArgument[] arguments)
            => GenericName(name.SimpleName).WithTypeArgumentList(arguments.GetTypeArgumentList());

        public static SimpleBaseTypeSyntax ToSimpleBaseType(this IClrElementName item) 
            => SimpleBaseType(item.ToNameSyntax());

        public static IEnumerable<SimpleBaseTypeSyntax> GetBaseTypes<S>(this TypeSpec<S> item)
            where S : TypeSpec<S> => ReadOnlyList.Create(
                map(item.BaseTypes, t => SimpleBaseType(t.GetTypeSyntax())),
                map(item.ImplicitRealizations, i => i.ToSimpleBaseType())
                );

        public static IdentifierNameSyntax idname<T>()
            => IdentifierName(typeof(T).Name);

        public static BaseListSyntax ToBaseList(this IEnumerable<SimpleBaseTypeSyntax> items) 
            => BaseList(items.ToSeparatedList<BaseTypeSyntax>());

        public static SyntaxKind[] ToSyntaxKinds(this ClrAccessKind access) 
            => AccessKeywords[access];

        public static SyntaxKind[] ToSyntaxKinds(this Option<ClrAccessKind> access)
            => access.MapValueOrElse(a => a.ToSyntaxKinds(), _ => array<SyntaxKind>());

        public static SyntaxToken ToToken(this SyntaxKind kind)
            => Token(kind);
    
        public static SyntaxTokenList ToTokens(params SyntaxKind[] kinds)
            => TokenList(kinds.Select(Token));

        public static SyntaxTokenList ToTokens(this IEnumerable<SyntaxKind> kinds) 
            => TokenList(kinds.Select(Token));

        public static SyntaxKind ToPrimitiveKeyword(this ClrType primitive)
            => PrimitiveKeywords[primitive.Name];

        public static SyntaxKind ToPrimitiveKeyword(this IClrElementName primitive) 
            => PrimitiveKeywords[primitive.SimpleName];

        public static SyntaxList<TNode> ToSyntaxList<TNode>(this IEnumerable<TNode> items) where TNode : SyntaxNode 
            => List(items);

        static MemberDeclarationSyntax _BuildSyntax(this TypeTemplateSpec spec)
        {
            var expansion = spec.FormatValue();
            var cu = SyntaxFactory.ParseCompilationUnit(expansion);
            return cu.Members[0];            
        }
            
        public static IdentifierNameSyntax ToNameSyntax(this IClrElementName name)
            => IdentifierName(name.SimpleName);

        public static IEnumerable<IdentifierNameSyntax> ToNameSyntax(this IEnumerable<IClrElementName> items)
            => map(items, ToNameSyntax);

        public static IdentifierNameSyntax GetNameSyntax(this Type type)
            => IdentifierName(type.Name);

        public static IdentifierNameSyntax ToIdentifierName(this string x)
            => IdentifierName(x);

        public static SyntaxToken ToIdentifierToken(this IClrElementName x)
            => Identifier(x.SimpleName);

        public static IdentifierNameSyntax ToIdentifierName(this ClrItemIdentifier identifier)
            => identifier.Value.ToIdentifierName();

        public static IEnumerable<IdentifierNameSyntax> ToIdentifierNames(this IEnumerable<ClrItemIdentifier> identifiers)
            => map(identifiers, ToIdentifierName);
    }
}
