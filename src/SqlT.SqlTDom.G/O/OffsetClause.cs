////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OffsetClause : TSqlFragment, ISqlTDomElement
    {
        public ScalarExpression OffsetExpression
        {
            get;
            set;
        }

        public ScalarExpression FetchExpression
        {
            get;
            set;
        }
    }
}