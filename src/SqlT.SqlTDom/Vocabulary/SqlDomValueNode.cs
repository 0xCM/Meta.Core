//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;


    public class SqlDomRoot 
    {

        public SqlDomRoot
        (
            SqlDomTypeDescriptor DomType, 
            IEnumerable<SqlDomAttributeValue> Attributes,             
            IEnumerable<SqlDomAssociationValue> Associations,
            IEnumerable<SqlDomCollectionValue> Collections,
            object SourceValue
        )
        {

            this.DomType = DomType;
            this.Associations = rolist(Associations);
            this.Collections = rolist(Collections);
            this.Attributes = rolist(Attributes);
            this.SourceValue = SourceValue;
        }

        public SqlDomTypeDescriptor DomType { get; }

        public object SourceValue { get; }

        public IReadOnlyList<SqlDomAttributeValue> Attributes { get; }

        public IReadOnlyList<SqlDomAssociationValue> Associations { get; }

        public IReadOnlyList<SqlDomCollectionValue> Collections { get; }


    }




}