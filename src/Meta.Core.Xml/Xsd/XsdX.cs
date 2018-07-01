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

    public static class XsdExtensions
    {
        public static IEnumerable<XmlSchemaAttribute> GetAttributes(this XmlSchemaObjectCollection x)
            => x.OfType<XmlSchemaAttribute>();

        public static IEnumerable<XmlSchemaSimpleType> GetSimpleTypes(this XmlSchema x)
            => x.Items.OfType<XmlSchemaSimpleType>();

        public static IEnumerable<XmlSchemaComplexType> GetComplexTypes(this XmlSchema x)
            => x.Items.OfType<XmlSchemaComplexType>();

        public static IEnumerable<XmlSchemaAttributeGroup> GetAttributeGroups(this XmlSchema x)
            => x.Items.OfType<XmlSchemaAttributeGroup>();

        public static IEnumerable<XmlSchemaAttribute> GetAttributes(this XmlSchemaComplexType x)
            => x.Attributes.GetAttributes();

        public static IEnumerable<XmlSchemaAttributeGroupRef> GetAttributeGroupReferences(this XmlSchemaComplexType x)
            => x.Attributes.OfType<XmlSchemaAttributeGroupRef>();
    }

}