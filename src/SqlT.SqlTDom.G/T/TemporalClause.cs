////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TemporalClause : TSqlFragment, ISqlTDomElement
    {
        public TemporalClauseType TemporalClauseType
        {
            get;
            set;
        }

        public ScalarExpression StartTime
        {
            get;
            set;
        }

        public ScalarExpression EndTime
        {
            get;
            set;
        }
    }
}