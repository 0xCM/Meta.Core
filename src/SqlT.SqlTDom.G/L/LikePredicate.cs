////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class LikePredicate : BooleanExpression, ISqlTDomElement
    {
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

        public bool NotDefined
        {
            get;
            set;
        }

        public bool OdbcEscape
        {
            get;
            set;
        }

        public ScalarExpression EscapeExpression
        {
            get;
            set;
        }
    }
}