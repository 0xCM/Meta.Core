////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WhereClause : TSqlFragment, ISqlTDomElement
    {
        public BooleanExpression SearchCondition
        {
            get;
            set;
        }

        public CursorId Cursor
        {
            get;
            set;
        }
    }
}