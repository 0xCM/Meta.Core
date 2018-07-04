////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class QualifiedJoin : JoinTableReference, ISqlTDomElement
    {
        public BooleanExpression SearchCondition
        {
            get;
            set;
        }

        public QualifiedJoinType QualifiedJoinType
        {
            get;
            set;
        }

        public JoinHint JoinHint
        {
            get;
            set;
        }
    }
}