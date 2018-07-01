//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Base type for property specifiers
    /// </summary>
    public abstract class PropertySpec : MemberSpec<PropertySpec,ClrPropertyName>
    {
        public PropertySpec(IClrElementName DeclaringTypeName,  ClrPropertyName Name, ClrTypeReference PropertyType,
                ClrAccessKind? AccessLevel = null, int? DeclarationOrder = null, CodeDocumentationSpec Documentation = null,
                bool CanRead = true, ClrAccessKind? ReadAccessLevel = null, bool CanWrite = true,
                ClrAccessKind? WriteAccessLevel = null, bool IsStatic = false, bool IsAbstract = false, bool IsVirtual = false,
                bool IsOverride = false, bool IsSealed = false, IEnumerable<AttributionSpec> Attributions = null,
                ClrCustomMemberIdentifier CustomMember = null,bool IsNew = false)
                   : base(DeclaringTypeName, Name, Documentation, DeclarationOrder, AccessLevel ?? ClrAccessKind.Default,
                        IsStatic, Attributions ?? array<AttributionSpec>(), CustomMember)
        {
            this.PropertyType = PropertyType;
            this.CanRead = CanRead;
            this.ReadAccessLevel = ReadAccessLevel ?? ClrAccessKind.Default;
            this.CanWrite = CanWrite;
            this.WriteAccessLevel = WriteAccessLevel ?? ClrAccessKind.Default;
            this.IsAbstract = IsAbstract;
            this.IsVirtual = IsVirtual;
            this.IsOverride = IsOverride;
            this.IsSealed = IsSealed;
            this.IsNew = IsNew;
        }

        /// <summary>
        /// Specifies the type of the property
        /// </summary>
        public ClrTypeReference PropertyType { get; }

        /// <summary>
        /// Specifies whether the property can be read
        /// </summary>
        public bool CanRead { get; }

        /// <summary>
        /// Specifies the visibility of the read accessor
        /// </summary>
        public ClrAccessKind ReadAccessLevel { get; }

        /// <summary>
        /// Specifies whether the property can be written to
        /// </summary>
        public bool CanWrite { get; }

        /// <summary>
        /// Specifies the visibility of the write accessor
        /// </summary>
        public ClrAccessKind WriteAccessLevel { get; }

        /// <summary>
        /// Specifies whether the property is abstract
        /// </summary>
        public bool IsAbstract { get; }

        /// <summary>
        /// Specifies whether the property is virtual
        /// </summary>
        public bool IsVirtual { get; }

        /// <summary>
        /// Specifies whether the property is an override
        /// </summary>
        public bool IsOverride { get; }

        /// <summary>
        /// Specifies whether a sealed modifier has been applied to the property
        /// </summary>
        public bool IsSealed { get; }

        /// <summary>
        /// Specifies whether a new modifier has been applied to the property
        /// </summary>
        public bool IsNew { get; }

        /// <summary>
        /// Specifies the name of the property
        /// </summary>
        public ClrPropertyName PropertyName
            => (ClrPropertyName)this.Name;

        public override bool IsProperty
            => true;
    }

}
