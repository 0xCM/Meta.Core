////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SetUserStatement : TSqlStatement, ISqlTDomStatement
    {
        public ValueExpression UserName
        {
            get;
            set;
        }

        public bool WithNoReset
        {
            get;
            set;
        }
    }
}