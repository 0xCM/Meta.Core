//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Schema;

    using static metacore;

    public class XsdComplexTypeInfo : XsdTypeInfo<XsdComplexTypeInfo>
    {
        readonly XmlSchemaComplexType Type;


        public XsdComplexTypeInfo(XmlSchemaComplexType Type, Func<string, Option<XsdSimpleTypeInfo>> SimpleTypeLU,
            Func<string, Option<XsdAttributeGroupInfo>> AttributeGroupLU)
        {
            this.Type = Type;
            this.DeclaredAttributes
                = map(Type.GetAttributes(),
                        x => new XsdAttributeInfo(x, SimpleTypeLU));

            var grouprefs
                = map(Type.GetAttributeGroupReferences(),
                    x => new XsdAttributeGroupRefInfo(x));

            this.ReferencedAttributes
                = rolist(
                    from r in grouprefs
                    let groupedAttributes = AttributeGroupLU(r.Name).Map(x => x.Attributes)
                    where groupedAttributes.IsSome()
                    let list = groupedAttributes.Require()
                    from item in list
                    select item
                    );

            this.Attributes = unionize(DeclaredAttributes, ReferencedAttributes).ToReadOnlyList();

        }

        public override string Name
            => Type.Name;

        public ReadOnlyList<XsdAttributeInfo> DeclaredAttributes { get; }

        public ReadOnlyList<XsdAttributeInfo> ReferencedAttributes { get; }

        public ReadOnlyList<XsdAttributeInfo> Attributes { get; }

    }
}