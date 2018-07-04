////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class InPredicate : BooleanExpression, ISqlTDomElement
    {
        public ScalarExpression Expression
        {
            get;
            set;
        }

        public ScalarSubquery Subquery
        {
            get;
            set;
        }

        public bool NotDefined
        {
            get;
            set;
        }

        public IList<ScalarExpression> Values
        {
            get;
            set;
        }
    }
}