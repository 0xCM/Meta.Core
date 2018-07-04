////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption, ISqlTDomOption
    {
        public bool HasIncremental
        {
            get;
            set;
        }

        public OptionState IncrementalState
        {
            get;
            set;
        }
    }
}