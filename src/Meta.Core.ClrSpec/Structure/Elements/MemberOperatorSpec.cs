//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes an operator defined by a type
    /// </summary>
    public class MemberOperatorSpec : MethodSpec<MemberOperatorSpec,ClrMemberOperatorName>
    {
        public MemberOperatorSpec
            (
                IClrElementName DeclaringTypeName,
                ClrAccessKind? AccessLevel = null,
                MethodBodySpec Body = null,
                CodeDocumentationSpec Documentation = null,
                ClrCustomMemberIdentifier CustomMember = null,
                IEnumerable<MethodParameterSpec> MethodParameters = null,
                IEnumerable<AttributionSpec> Attributions = null
            )
            : base(
                  DeclaringTypeName: DeclaringTypeName,
                  Name: new ClrMemberOperatorName(DeclaringTypeName.SimpleName),
                  AccessLevel: AccessLevel ?? ClrAccessKind.Public,
                  IsStatic: true,
                  IsExtension: false,
                  IsAbstract: false,
                  IsVirtual: false,
                  IsOverride: false,
                  IsSealed: false,
                  IsPartial: false,
                  Body: Body,
                  Documentation: Documentation,
                  CustomMemberKind: CustomMember,
                  MethodParameters: MethodParameters,
                  Attributions: Attributions)
        { }
    }
}
