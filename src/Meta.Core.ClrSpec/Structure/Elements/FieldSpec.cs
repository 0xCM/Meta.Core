//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static metacore;
using static ClrBehaviorSpec;
public static partial class ClrStructureSpec
{     
    /// <summary>
    /// Characterizes a field
    /// </summary>
    public sealed class FieldSpec : MemberSpec<FieldSpec,ClrFieldName>
    {
        public FieldSpec(IClrElementName DeclaringTypeName, ClrFieldName Name, ClrTypeReference FieldType,
            ClrAccessKind? AccessLevel = null, int? DeclarationOrder = null, CodeDocumentationSpec Documentation = null,
            bool IsStatic = false, bool IsReadOnly = false, bool IsConst = false, 
            IEnumerable<AttributionSpec> Attributions = null, FieldInitializerSpec Initializer = null,
            ClrCustomMemberIdentifier CustomMember = null) 
                : base(DeclaringTypeName, Name, Documentation, DeclarationOrder, AccessLevel ?? ClrAccessKind.Default,
                    IsStatic, Attributions, CustomMember)
        {
            this.FieldType = FieldType;
            this.IsReadOnly = IsReadOnly;
            this.IsConst = IsConst;
            this.FieldInitializer = Initializer;
        }

        /// <summary>
        /// Specifies a reference to the field's type
        /// </summary>
        public ClrTypeReference FieldType { get; }

        /// <summary>
        /// Specifies wither the field is declared with a readonly modifier
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Specifies wither the field is declared with a const modifier
        /// </summary>
        public bool IsConst { get; }

        /// <summary>
        /// Specifies a field initializer expression
        /// </summary>
        public Option<FieldInitializerSpec> FieldInitializer { get; }

        /// <summary>
        /// Specifies whether the field is a literal value
        /// </summary>
        public bool IsLiteral
            => FieldInitializer.Map(x => x.LiteralValue.Exists).ValueOrDefault();
        
        public override string ToString()
            => $"{Name} : {FieldType}";

    }
}