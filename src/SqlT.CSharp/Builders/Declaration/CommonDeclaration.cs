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
        public static MemberDeclarationSyntax BuildSyntax(this IClrElementSpec spec)
            => _BuildSyntax((dynamic)spec);

        public static SyntaxList<MemberDeclarationSyntax> BuildSyntaxList(this IEnumerable<IClrElementSpec> specs)
            => map(specs, BuildSyntax).ToSyntaxList();
   
        public static MemberDeclarationSyntax DeclareMember(this IClrMemberSpec spec)
            => cast<MemberDeclarationSyntax>(Declare((dynamic)spec));

        public static BaseTypeDeclarationSyntax DeclareType(this IClrTypeSpec spec)
            => DeclareType((dynamic)spec);

        public static SyntaxList<MemberDeclarationSyntax> DeclareMembers(this IClrTypeSpec spec)        
            => map(spec.Members.Where(x => not(x.IsCustom)), m => DeclareMember(m))
                    .Union(spec.DeclareCustomMembers()).ToSyntaxList();       
    }
}
