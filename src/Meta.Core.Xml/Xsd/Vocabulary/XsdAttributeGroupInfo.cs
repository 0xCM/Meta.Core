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

    public class XsdAttributeGroupInfo
    {

        XmlSchemaAttributeGroup AttributeGroup;

        public XsdAttributeGroupInfo(XmlSchemaAttributeGroup AttributeGroup, Func<string, Option<XsdSimpleTypeInfo>> SimpleTypeLU)
        {
            this.AttributeGroup = AttributeGroup;
            this.Attributes = map(AttributeGroup.Attributes.GetAttributes(), x => new XsdAttributeInfo(x, SimpleTypeLU));
        }

        public ReadOnlyList<XsdAttributeInfo> Attributes { get; }

        public string Name
            => AttributeGroup.Name;

        public override string ToString()
            => Name;
    }
}