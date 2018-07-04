////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseTermination : TSqlFragment, ISqlTDomElement
    {
        public bool ImmediateRollback
        {
            get;
            set;
        }

        public Literal RollbackAfter
        {
            get;
            set;
        }

        public bool NoWait
        {
            get;
            set;
        }
    }
}