////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class RemoteDataArchiveAlterTableOption : TableOption, ISqlTDomOption
    {
        public RdaTableOption RdaTableOption
        {
            get;
            set;
        }

        public MigrationState MigrationState
        {
            get;
            set;
        }

        public bool IsMigrationStateSpecified
        {
            get;
            set;
        }

        public bool IsFilterPredicateSpecified
        {
            get;
            set;
        }

        public FunctionCall FilterPredicate
        {
            get;
            set;
        }
    }
}