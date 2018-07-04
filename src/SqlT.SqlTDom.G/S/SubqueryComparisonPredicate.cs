////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SubqueryComparisonPredicate : BooleanExpression, ISqlTDomElement
    {
        public ScalarExpression Expression
        {
            get;
            set;
        }

        public BooleanComparisonType ComparisonType
        {
            get;
            set;
        }

        public ScalarSubquery Subquery
        {
            get;
            set;
        }

        public SubqueryComparisonPredicateType SubqueryComparisonPredicateType
        {
            get;
            set;
        }
    }
}