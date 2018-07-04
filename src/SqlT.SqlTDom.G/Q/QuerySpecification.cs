////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class QuerySpecification : QueryExpression, ISqlTDomElement
    {
        public UniqueRowFilter UniqueRowFilter
        {
            get;
            set;
        }

        public TopRowFilter TopRowFilter
        {
            get;
            set;
        }

        public IList<SelectElement> SelectElements
        {
            get;
            set;
        }

        public FromClause FromClause
        {
            get;
            set;
        }

        public WhereClause WhereClause
        {
            get;
            set;
        }

        public GroupByClause GroupByClause
        {
            get;
            set;
        }

        public HavingClause HavingClause
        {
            get;
            set;
        }
    }
}