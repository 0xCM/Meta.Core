////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SelectStatement : StatementWithCtesAndXmlNamespaces, ISqlTDomStatement
    {
        public QueryExpression QueryExpression
        {
            get;
            set;
        }

        public SchemaObjectName Into
        {
            get;
            set;
        }

        public IList<ComputeClause> ComputeClauses
        {
            get;
            set;
        }
    }
}