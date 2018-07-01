//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Schema;

    using static metacore;

    public class XsdSimpleTypeInfo : XsdTypeInfo<XsdComplexTypeInfo>
    {
        readonly XmlSchemaSimpleType Type;

        public XsdSimpleTypeInfo(XmlSchemaSimpleType Type)
        {
            var baseSchemaType = Type.Content;

            this.Type = Type;

            switch (Type.Content)
            {
                case XmlSchemaSimpleTypeRestriction r:
                    ContentInfo = new XsdSimpleRestrictionInfo(r);
                    break;
                case XmlSchemaSimpleTypeUnion u:
                    ContentInfo = new XsdSimpleUnionInfo(u);
                    break;
                case XmlSchemaSimpleTypeList l:
                    ContentInfo = new XsdSimpleListInfo(l);
                    break;
            }
        }

        public override string Name
            => Type.Name;

        public XsdSimpleTypeConentInfo ContentInfo { get; }

        public override string ToString()
            => $"{Name}: {ContentInfo}";

        public bool DefinesEnum
            => (ContentInfo as XsdSimpleRestrictionInfo)?.DefinesEnumLiterals() ?? false;

        public IEnumerable<string> EnumLiterals
            => (ContentInfo as XsdSimpleRestrictionInfo).EnumerationLiterals ?? stream<string>();
    }

}