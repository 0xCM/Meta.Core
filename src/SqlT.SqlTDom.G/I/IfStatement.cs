////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class IfStatement : TSqlStatement, ISqlTDomStatement
    {
        public BooleanExpression Predicate
        {
            get;
            set;
        }

        public TSqlStatement ThenStatement
        {
            get;
            set;
        }

        public TSqlStatement ElseStatement
        {
            get;
            set;
        }
    }
}