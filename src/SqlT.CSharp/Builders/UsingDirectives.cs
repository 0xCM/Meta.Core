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
        public static UsingDirectiveSyntax WithSemicolon(this UsingDirectiveSyntax syntax)
            => syntax.WithSemicolonToken(SyntaxKind.SemicolonToken.ToToken());

        public static UsingDirectiveSyntax BuildSyntax(this UsingSpec spec)
        {
            var u = UsingDirective(spec.SubjectName.ToNameSyntax());
            if (spec.IsAliased)
                u = u.WithAlias(NameEquals(spec.AliasName));
            if (spec.IsStatic)
                u = u.WithStaticKeyword(SyntaxKind.StaticKeyword.ToToken());
            return u.WithSemicolon();
        }

        public static SyntaxList<UsingDirectiveSyntax> BuildSyntaxList(this IEnumerable<UsingSpec> specs)
            => map(specs, BuildSyntax).ToSyntaxList();
    }
}