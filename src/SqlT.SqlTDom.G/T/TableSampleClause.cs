////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TableSampleClause : TSqlFragment, ISqlTDomElement
    {
        public bool System
        {
            get;
            set;
        }

        public ScalarExpression SampleNumber
        {
            get;
            set;
        }

        public TableSampleClauseOption TableSampleClauseOption
        {
            get;
            set;
        }

        public ScalarExpression RepeatSeed
        {
            get;
            set;
        }
    }
}