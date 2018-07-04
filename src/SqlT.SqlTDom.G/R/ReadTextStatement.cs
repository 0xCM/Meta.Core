////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ReadTextStatement : TSqlStatement, ISqlTDomStatement
    {
        public ColumnReferenceExpression Column
        {
            get;
            set;
        }

        public ValueExpression TextPointer
        {
            get;
            set;
        }

        public ValueExpression Offset
        {
            get;
            set;
        }

        public ValueExpression Size
        {
            get;
            set;
        }

        public bool HoldLock
        {
            get;
            set;
        }
    }
}