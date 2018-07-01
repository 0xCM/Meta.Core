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
    /// Base type for member specifications
    /// </summary>
    /// <typeparam name="S">The derived subtype</typeparam>
    /// <typeparam name="N">The member name</typeparam>
    public abstract class MemberSpec<S,N> : ElementSpec<S>, IClrMemberSpec
        where S : MemberSpec<S,N>
        where N : IClrElementName
    {

        protected MemberSpec(IClrElementName DeclaringTypeName, N MemberName,
                CodeDocumentationSpec Documentation, int? DeclarationOrder, ClrAccessKind AccessLevel,
                bool IsStatic, IEnumerable<AttributionSpec> Attributions, 
                ClrCustomMemberIdentifier CustomMember)
                    : base(MemberName, Documentation, AccessLevel, Attributions)
        {
            this.DeclaringTypeName = DeclaringTypeName;
            this.DeclarationOrder = DeclarationOrder;
            this.IsStatic = IsStatic;
            this.CustomMember = CustomMember ?? ClrCustomMemberIdentifier.Empty;
        }

        public int? DeclarationOrder { get; }

        public bool IsStatic { get; }

        public ClrCustomMemberIdentifier CustomMember { get; }

        public IClrElementName DeclaringTypeName { get; }

        bool IClrMemberSpec.IsStatic
            => IsStatic;

        bool IClrMemberSpec.IsProperty
            => IsProperty;

        ClrCustomMemberIdentifier IClrMemberSpec.CustomMember
            => CustomMember;

        bool IClrMemberSpec.IsCustom
            => CustomMember != ClrCustomMemberIdentifier.Empty;

        IClrElementName IClrMemberSpec.DeclaringTypeName
            => DeclaringTypeName;

        public virtual bool IsProperty
            => false;
        public override string ToString()
            => $"{Name}";
    }

}