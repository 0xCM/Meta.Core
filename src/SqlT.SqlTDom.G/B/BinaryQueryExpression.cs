////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BinaryQueryExpression : QueryExpression, ISqlTDomExpression
    {
        public BinaryQueryExpressionType BinaryQueryExpressionType
        {
            get;
            set;
        }

        public bool All
        {
            get;
            set;
        }

        public QueryExpression FirstQueryExpression
        {
            get;
            set;
        }

        public QueryExpression SecondQueryExpression
        {
            get;
            set;
        }
    }
}