////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CommonTableExpression : TSqlFragment, ISqlTDomExpression
    {
        public Identifier ExpressionName
        {
            get;
            set;
        }

        public IList<Identifier> Columns
        {
            get;
            set;
        }

        public QueryExpression QueryExpression
        {
            get;
            set;
        }
    }
}