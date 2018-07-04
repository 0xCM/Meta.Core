////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BooleanTernaryExpression : BooleanExpression, ISqlTDomExpression
    {
        public BooleanTernaryExpressionType TernaryExpressionType
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

        public ScalarExpression ThirdExpression
        {
            get;
            set;
        }
    }
}