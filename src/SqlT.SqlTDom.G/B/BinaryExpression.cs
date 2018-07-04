////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BinaryExpression : ScalarExpression, ISqlTDomExpression
    {
        public BinaryExpressionType BinaryExpressionType
        {
            get;
            set;
        }

        public ScalarExpression FirstExpression
        {
            get;
            set;
        }

        public ScalarExpression SecondExpression
        {
            get;
            set;
        }
    }
}