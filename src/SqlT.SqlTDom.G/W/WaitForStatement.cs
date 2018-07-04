////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WaitForStatement : TSqlStatement, ISqlTDomStatement
    {
        public WaitForOption WaitForOption
        {
            get;
            set;
        }

        public ValueExpression Parameter
        {
            get;
            set;
        }

        public ScalarExpression Timeout
        {
            get;
            set;
        }

        public WaitForSupportedStatement Statement
        {
            get;
            set;
        }
    }
}