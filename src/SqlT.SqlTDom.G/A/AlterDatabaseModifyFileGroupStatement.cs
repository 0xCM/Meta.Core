////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseModifyFileGroupStatement : AlterDatabaseStatement, ISqlTDomAlterStatement
    {
        public Identifier FileGroup
        {
            get;
            set;
        }

        public Identifier NewFileGroupName
        {
            get;
            set;
        }

        public bool MakeDefault
        {
            get;
            set;
        }

        public ModifyFileGroupOption UpdatabilityOption
        {
            get;
            set;
        }

        public AlterDatabaseTermination Termination
        {
            get;
            set;
        }
    }
}