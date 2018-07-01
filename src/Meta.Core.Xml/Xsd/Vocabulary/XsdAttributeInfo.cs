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
    using System.Xml;
    using System.Xml.Schema;

    using static metacore;


    public class XsdAttributeInfo : XsdTypeInfo<XsdAttributeInfo>
    {
        readonly XmlSchemaAttribute Attribute;


        public XsdAttributeInfo(XmlSchemaAttribute Attribute, Func<string, Option<XsdSimpleTypeInfo>> TypeLU)
        {
            this.Attribute = Attribute;
            this.AttributeType = TypeLU(Attribute.Name);
        }

        public override string Name
            => Attribute.Name;

        public Option<XsdSimpleTypeInfo> AttributeType { get; }

        public string AttributeTypeName
            => Attribute.SchemaTypeName.Name;

        public override string ToString()
            => $"{Name} : {AttributeTypeName}";
    }


}