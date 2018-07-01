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
    /// Characterizes an enumeration literal
    /// </summary>
    public sealed class EnumLiteralSpec : MemberSpec<EnumLiteralSpec, ClrEnumLiteralName>
    {
        public EnumLiteralSpec(ClrEnumName DeclaringTypeName, ClrEnumLiteralName Name,
                CoreDataValue LiteralValue = null, int? DeclarationOrder = null,
                CodeDocumentationSpec Documentation = null, 
                IEnumerable<AttributionSpec> Attributions = null) 
                    : base(DeclaringTypeName, Name, Documentation, DeclarationOrder, 
                        ClrAccessKind.Default, false, Attributions, ClrCustomMemberIdentifier.Empty)
                            => this.LiteralValue = LiteralValue;            

        /// <summary>
        /// The (integral) literal value, if specified
        /// </summary>
        public Option<CoreDataValue> LiteralValue { get; }
       
        public override string ToString()
            => $"{Name} {LiteralValue.Map(v => " = " +  v.ToClrValue().ToString(), () => String.Empty)}";
    }
}
    