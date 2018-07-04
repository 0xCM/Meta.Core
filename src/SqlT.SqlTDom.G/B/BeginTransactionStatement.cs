////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BeginTransactionStatement : TransactionStatement, ISqlTDomStatement
    {
        public bool Distributed
        {
            get;
            set;
        }

        public bool MarkDefined
        {
            get;
            set;
        }

        public ValueExpression MarkDescription
        {
            get;
            set;
        }
    }
}