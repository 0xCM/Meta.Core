////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DropIndexStatement : TSqlStatement, ISqlTDomDropStatement
    {
        public IList<DropIndexClauseBase> DropIndexClauses
        {
            get;
            set;
        }

        public bool IsIfExists
        {
            get;
            set;
        }
    }
}