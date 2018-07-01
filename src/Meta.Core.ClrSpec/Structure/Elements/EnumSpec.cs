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
    /// Characterizes an enum
    /// </summary>
    public sealed class EnumSpec : TypeSpec<EnumSpec>
    {
        public EnumSpec(ClrEnumName Name, ClrTypeReference UnderlyingType,
                    params (string literalName,object literalValue)[] literals)
            : this(Name, ClrAccessKind.Public, UnderlyingType,
                  map(literals, literal 
                      => new EnumLiteralSpec(Name, 
                          literal.literalName, ~ CoreDataValue.FromObject(literal.literalValue))))
        {

        }

        public EnumSpec(ClrEnumName Name, ClrAccessKind AccessLevel, ClrTypeReference UnderlyingType, 
            IEnumerable<EnumLiteralSpec> Literals,  CodeDocumentationSpec Documentation = null, 
            IEnumerable<AttributionSpec> Attributions = null, IClrElementName DeclaringType = null)
            : base(Name, Documentation, AccessLevel,Attributions ?? array<AttributionSpec>(),
                TypeParameters : array<TypeParameter>(), BaseTypes: array<ClrTypeClosure>(),
                ImplicitRealizations : array<ClrInterfaceName>(), DeclaringType: DeclaringType,
                IsStatic: false,Members: array(Literals))
        {
            this.UnderlyingType = UnderlyingType;
        }

        public  ClrTypeReference UnderlyingType { get; }        

        public override string ToString()
            => $"enum {Name} : {UnderlyingType}" + " { }";
    }
}