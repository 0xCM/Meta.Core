////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class IIfCall : PrimaryExpression, ISqlTDomElement
    {
        public BooleanExpression Predicate
        {
            get;
            set;
        }

        public ScalarExpression ThenExpression
        {
            get;
            set;
        }

        public ScalarExpression ElseExpression
        {
            get;
            set;
        }
    }
}