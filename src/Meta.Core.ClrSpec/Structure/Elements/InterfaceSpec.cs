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
    /// Characterizes an interface
    /// </summary>
    public sealed class InterfaceSpec : TypeSpec<InterfaceSpec>
    {       
        public InterfaceSpec
            (
                ClrInterfaceName Name,
                CodeDocumentationSpec Documentation = null,
                ClrAccessKind? AccessLevel = null,
                IEnumerable<AttributionSpec> Attributions = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                IEnumerable<ClrTypeClosure> BaseTypes = null,
                IClrElementName DeclaringType = null,
                bool IsPartial = false,
                IEnumerable<IClrMemberSpec> Members = null
            )
            : base
            (
                Name: Name,
                Documentation: Documentation,
                AccessLevel: AccessLevel ?? ClrAccessKind.Public,
                Attributions: Attributions ?? array<AttributionSpec>(),
                TypeParameters: TypeParameters ?? array<TypeParameter>(),
                BaseTypes: BaseTypes ?? array<ClrTypeClosure>(),
                ImplicitRealizations : array<ClrInterfaceName>(),
                DeclaringType: DeclaringType,
                IsStatic: false,
                Members: Members,
                IsPartial: IsPartial
            )
        {
        
        }
    }

}