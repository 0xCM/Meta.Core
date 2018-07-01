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
    /// Characterizes a struct
    /// </summary>
    public sealed class StructSpec : TypeSpec<StructSpec>
    {
        public StructSpec
            (
                ClrStructName Name,
                CodeDocumentationSpec Documentation = null,
                ClrAccessKind? AccessLevel = null,
                IEnumerable<AttributionSpec> Attributions = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                IEnumerable<ClrTypeClosure> BaseTypes = null,
                IEnumerable<ClrInterfaceName> ImplicitRealizations = null,
                IClrElementName DeclaringType = null,
                bool IsPartial = false,
                params IClrMemberSpec[] Members
            )
            : base
            (
                Name,
                Documentation,
                AccessLevel ?? ClrAccessKind.Public,
                Attributions ?? array<AttributionSpec>(),
                TypeParameters ?? array<TypeParameter>(),
                BaseTypes ?? array<ClrTypeClosure>(),
                ImplicitRealizations ?? array<ClrInterfaceName>(),
                DeclaringType,
                false,
                Members,
                IsPartial: IsPartial
            )
        { }
    }
}