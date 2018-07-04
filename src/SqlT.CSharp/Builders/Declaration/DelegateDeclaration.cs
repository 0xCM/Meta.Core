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
        public static SyntaxKind[] GetModifiers(this DelegateSpec spec)
        {
            var modifiers = new List<SyntaxKind>();
            modifiers.AddRange(spec.AccessLevel.ToSyntaxKinds());
            return modifiers.ToArray();
        }

        public static DelegateDeclarationSyntax WithModifiers(this DelegateDeclarationSyntax x, DelegateSpec spec)
            => x.WithModifiers(spec.GetModifiers().ToTokens());

    }

}
