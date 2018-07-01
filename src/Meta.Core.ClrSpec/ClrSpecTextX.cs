//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace ClrModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static ClrStructureSpec;
    using static ClrBehaviorSpec;

    /// <summary>
    /// Defines <see cref="string"/> extensions within the <see cref="ClrModel"/> namepsace to prevent
    /// flooding the global scope with CLR-related operations
    /// </summary>
    public static class ClrNameSpecFactory
    {
        public static ClrClassName SpecifyClrClassName(this string text)
            => new ClrClassName(text);

        public static ClrInterfaceName SpecifyClrInteraceName(this string text)
            => new ClrInterfaceName(text);

        public static ClrStructName SpecifyClrStructName(this string text)
            => new ClrStructName(text);

        public static ClrMethodParameterName SpecifyClrMethodParameterName(this string text)
            => new ClrMethodParameterName(text);

        public static ClrMethodName SpecifyClrMethodName(this string text)
            => new ClrMethodName(text);

        public static ClrNamespaceName SpecifyNamespaceName(this string text)
            => new ClrNamespaceName(text);

        internal static ClrItemIdentifier identifier(string text)
            => new ClrItemIdentifier(text);

        public static ClrNamespaceName SpecifyNamespaceName(this string[] components)
            => new ClrNamespaceName(components);

        public static ClrTypeParameterName SpecifyClrTypeParameterName(this string text)
            => new ClrTypeParameterName(text);

        public static TypeParameter SpecifyTypeParameter(this string text, int position = 0)
            => new TypeParameter(text.SpecifyClrTypeParameterName(), position);

        public static CodeFilePreamble SpecifyCodeFilePreamble(this string text)
            => new CodeFilePreamble(text);

        /// <summary>
        /// Creates a <see cref="CodeFilePreamble"/> specification from a sequence of text lines
        /// </summary>
        /// <param name="lines">The lines that will be included int the body</param>
        /// <returns></returns>
        public static CodeFilePreamble SpecifyCodeFilePreamble(this IEnumerable<string> lines)
            => new CodeFilePreamble(lines.ToArray());

        /// <summary>
        /// Creates a <see cref="UsingSpec"/> given a namespace name supplied as text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static UsingSpec SpecifyUsing(this string text)
            => text.SpecifyNamespaceName().SpecifyUsing();

        public static IEnumerable<UsingSpec> SpecifyUsings(this IEnumerable<string> namespaces)
            => namespaces.Select(l => l.SpecifyUsing());

        public static LiteralValueSpec SpecifyLiteralValue(this string value)
            => new LiteralValueSpec(value);

    }
}