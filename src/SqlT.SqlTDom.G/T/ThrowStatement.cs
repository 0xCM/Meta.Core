////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ThrowStatement : TSqlStatement, ISqlTDomStatement
    {
        public ValueExpression ErrorNumber
        {
            get;
            set;
        }

        public ValueExpression Message
        {
            get;
            set;
        }

        public ValueExpression State
        {
            get;
            set;
        }
    }
}