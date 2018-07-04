////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UnpivotedTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public TableReference TableReference
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> InColumns
        {
            get;
            set;
        }

        public Identifier PivotColumn
        {
            get;
            set;
        }

        public Identifier ValueColumn
        {
            get;
            set;
        }
    }
}