////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseSetStatement : AlterDatabaseStatement, ISqlTDomAlterStatement
    {
        public AlterDatabaseTermination Termination
        {
            get;
            set;
        }

        public IList<DatabaseOption> Options
        {
            get;
            set;
        }
    }
}