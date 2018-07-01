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

using static ClrBehaviorSpec;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes a constructor declaration
    /// </summary>
    public class ConstructorSpec : MethodSpec<ConstructorSpec, ClrConstructorName>
    {
        public ConstructorSpec
            (
                IClrElementName DeclaringTypeName,
                ClrAccessKind? AccessLevel = null,
                bool IsStatic = false,
                MethodBodySpec Body = null,
                CodeDocumentationSpec Documentation = null,
                ClrCustomMemberIdentifier CustomMember = null,
                IEnumerable<MethodParameterSpec> MethodParameters = null,
                IEnumerable<AttributionSpec> Attributions = null,
                ConstructorInvocationSpec BaseInvocation = null
            )
            : base(
                  DeclaringTypeName: DeclaringTypeName,
                  Name: new ClrConstructorName(DeclaringTypeName.SimpleName),
                  AccessLevel: AccessLevel ?? ClrAccessKind.Public,
                  IsStatic: IsStatic,
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
        {
            this.BaseInvocation = BaseInvocation;
        }

        /// <summary>
        /// If present, specifies the base constructor invocation expression
        /// </summary>
        public Option<ConstructorInvocationSpec> BaseInvocation { get; }
    }


}
