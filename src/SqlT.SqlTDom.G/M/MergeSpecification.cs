////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MergeSpecification : DataModificationSpecification, ISqlTDomElement
    {
        public Identifier TableAlias
        {
            get;
            set;
        }

        public TableReference TableReference
        {
            get;
            set;
        }

        public BooleanExpression SearchCondition
        {
            get;
            set;
        }

        public IList<MergeActionClause> ActionClauses
        {
            get;
            set;
        }
    }
}