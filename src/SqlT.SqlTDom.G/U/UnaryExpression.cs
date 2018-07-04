////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UnaryExpression : ScalarExpression, ISqlTDomExpression
    {
        public UnaryExpressionType UnaryExpressionType
        {
            get;
            set;
        }

        public ScalarExpression Expression
        {
            get;
            set;
        }
    }
}