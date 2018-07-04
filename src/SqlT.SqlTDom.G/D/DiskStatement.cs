////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DiskStatement : TSqlStatement, ISqlTDomStatement
    {
        public DiskStatementType DiskStatementType
        {
            get;
            set;
        }

        public IList<DiskStatementOption> Options
        {
            get;
            set;
        }
    }
}