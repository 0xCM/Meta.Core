////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class StatementList : TSqlFragment, ISqlTDomElement
    {
        public IList<TSqlStatement> Statements
        {
            get;
            set;
        }
    }
}