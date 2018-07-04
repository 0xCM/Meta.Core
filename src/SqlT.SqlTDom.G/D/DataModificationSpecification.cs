////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class DataModificationSpecification : TSqlFragment, ISqlTDomElement
    {
        public TableReference Target
        {
            get;
            set;
        }

        public TopRowFilter TopRowFilter
        {
            get;
            set;
        }

        public OutputIntoClause OutputIntoClause
        {
            get;
            set;
        }

        public OutputClause OutputClause
        {
            get;
            set;
        }
    }
}