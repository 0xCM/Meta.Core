////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OverClause : TSqlFragment, ISqlTDomElement
    {
        public IList<ScalarExpression> Partitions
        {
            get;
            set;
        }

        public OrderByClause OrderByClause
        {
            get;
            set;
        }

        public WindowFrameClause WindowFrameClause
        {
            get;
            set;
        }
    }
}