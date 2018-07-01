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
    using System.Xml;
    using System.Xml.Schema;

    using static metacore;
    

    public class XsdSimpleRestrictionInfo : XsdSimpleTypeConentInfo<XsdSimpleRestrictionInfo>
    {
        readonly XmlSchemaSimpleTypeRestriction Restriction;

        public XsdSimpleRestrictionInfo(XmlSchemaSimpleTypeRestriction Restriction)
        {
            this.Restriction = Restriction;
            this.BaseTypeName = Restriction.BaseTypeName.Name;
            this.EnumerationLiterals = map(Restriction.Facets.OfType<XmlSchemaEnumerationFacet>(), x => x.Value).Distinct().ToReadOnlyList();
            this.Patterns = map(Restriction.Facets.OfType<XmlSchemaPatternFacet>(), x => x.Value);
        }


        public string BaseTypeName { get; }

        public ReadOnlyList<string> EnumerationLiterals { get; }

        public ReadOnlyList<string> Patterns { get; }

        public override string ToString()
        {
            if (EnumerationLiterals.Count != 0)
                return string.Join(",", EnumerationLiterals);
            else if (Patterns.Count != 0)
                return string.Join(" | ", Patterns);
            else
                return BaseTypeName;

        }

        public bool DefinesEnumLiterals()
            => EnumerationLiterals.Any();

    }


}