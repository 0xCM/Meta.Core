////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class InsertMergeAction : MergeAction, ISqlTDomElement
    {
        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }

        public ValuesInsertSource Source
        {
            get;
            set;
        }
    }
}