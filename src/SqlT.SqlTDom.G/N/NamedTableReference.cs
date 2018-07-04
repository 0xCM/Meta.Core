////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class NamedTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public SchemaObjectName SchemaObject
        {
            get;
            set;
        }

        public IList<TableHint> TableHints
        {
            get;
            set;
        }

        public TableSampleClause TableSampleClause
        {
            get;
            set;
        }

        public TemporalClause TemporalClause
        {
            get;
            set;
        }
    }
}