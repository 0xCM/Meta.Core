////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BooleanBinaryExpression : BooleanExpression, ISqlTDomExpression
    {
        public BooleanBinaryExpressionType BinaryExpressionType
        {
            get;
            set;
        }

        public BooleanExpression FirstExpression
        {
            get;
            set;
        }

        public BooleanExpression SecondExpression
        {
            get;
            set;
        }
    }
}