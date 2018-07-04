////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ColumnReferenceExpression : PrimaryExpression, ISqlTDomExpression
    {
        public ColumnType ColumnType
        {
            get;
            set;
        }

        public MultiPartIdentifier MultiPartIdentifier
        {
            get;
            set;
        }
    }
}