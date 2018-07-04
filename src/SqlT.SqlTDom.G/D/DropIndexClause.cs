////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DropIndexClause : DropIndexClauseBase, ISqlTDomElement
    {
        public Identifier Index
        {
            get;
            set;
        }

        public SchemaObjectName Object
        {
            get;
            set;
        }

        public IList<IndexOption> Options
        {
            get;
            set;
        }
    }
}