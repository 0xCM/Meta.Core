////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class QueryExpression : TSqlFragment, ISqlTDomExpression
    {
        public OrderByClause OrderByClause
        {
            get;
            set;
        }

        public OffsetClause OffsetClause
        {
            get;
            set;
        }

        public ForClause ForClause
        {
            get;
            set;
        }
    }
}