////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OutputIntoClause : TSqlFragment, ISqlTDomElement
    {
        public IList<SelectElement> SelectColumns
        {
            get;
            set;
        }

        public TableReference IntoTable
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> IntoTableColumns
        {
            get;
            set;
        }
    }
}