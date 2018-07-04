////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class TextModificationStatement : TSqlStatement, ISqlTDomStatement
    {
        public bool Bulk
        {
            get;
            set;
        }

        public ColumnReferenceExpression Column
        {
            get;
            set;
        }

        public ValueExpression TextId
        {
            get;
            set;
        }

        public Literal Timestamp
        {
            get;
            set;
        }

        public bool WithLog
        {
            get;
            set;
        }
    }
}