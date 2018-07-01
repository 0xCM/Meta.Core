//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes an automatic property
    /// </summary>
    public sealed class AutoPropertySpec : PropertySpec
    {
        public AutoPropertySpec
            (
                IClrElementName DeclaringTypeName,
                ClrPropertyName Name,
                ClrTypeReference PropertyType,
                ClrAccessKind? AccessLevel =  null,
                int? DeclarationOrder = null,
                string Documentation = null,
                ClrAccessKind? ReadAccessLevel = null,
                ClrAccessKind? WriteAccessLevel = null,
                bool IsStatic = false,
                bool IsAbstract = false,
                bool IsVirtual = false,
                bool IsOverride = false,
                bool IsSealed = false,
                IEnumerable<AttributionSpec> Attributions = null,
                ClrCustomMemberIdentifier CustomMember = null,
                bool IsNew = false
            )
            :
            base
            (
                DeclaringTypeName,
                Name: Name,
                PropertyType: PropertyType,
                AccessLevel: AccessLevel,
                DeclarationOrder: DeclarationOrder,
                Documentation: new ElementDescription(Documentation),
                ReadAccessLevel: ReadAccessLevel,
                WriteAccessLevel: WriteAccessLevel,
                IsAbstract: IsAbstract,
                IsStatic: IsStatic,
                IsVirtual: IsVirtual,
                IsOverride: IsOverride,
                IsSealed: IsSealed,
                Attributions: Attributions,
                CustomMember: CustomMember,
                IsNew : IsNew
            )
        {
        }

        public override string ToString()
            => $"{AccessLevel} {PropertyType} {PropertyName}" + "{get; set;}";
    }
}