//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes a delegate
    /// </summary>
    public sealed class DelegateSpec : TypeSpec<DelegateSpec>
    {
        public readonly IClrElementName ReturnTypeName;
        public readonly IReadOnlyList<MethodParameterSpec> MethodParameters;

        public DelegateSpec
            (
                ClrDelegateName Name,
                ClrAccessKind AccessLevel,
                IClrElementName ReturnTypeName,
                CodeDocumentationSpec Documentation = null,
                IEnumerable<AttributionSpec> Attributions = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                IClrElementName DeclaringType = null,
                params MethodParameterSpec[] Parameters
            )
            : base
            (
                Name,
                Documentation,
                AccessLevel,
                Attributions ?? array<AttributionSpec>(),
                TypeParameters ?? array<TypeParameter>(),
                array<ClrTypeClosure>(),
                array<ClrInterfaceName>(),
                DeclaringType,
                false,
                array<IClrMemberSpec>()
            )
        {
            this.ReturnTypeName = ReturnTypeName;
            this.MethodParameters = rovalues(Parameters);
        }


    }


}