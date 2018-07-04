////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MergeActionClause : TSqlFragment, ISqlTDomElement
    {
        public MergeCondition Condition
        {
            get;
            set;
        }

        public BooleanExpression SearchCondition
        {
            get;
            set;
        }

        public MergeAction Action
        {
            get;
            set;
        }
    }
}