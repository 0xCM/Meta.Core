////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class PivotedTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public TableReference TableReference
        {
            get;
            set;
        }

        public IList<Identifier> InColumns
        {
            get;
            set;
        }

        public ColumnReferenceExpression PivotColumn
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> ValueColumns
        {
            get;
            set;
        }

        public MultiPartIdentifier AggregateFunctionIdentifier
        {
            get;
            set;
        }
    }
}