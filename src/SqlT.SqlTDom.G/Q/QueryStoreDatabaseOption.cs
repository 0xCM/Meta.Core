////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class QueryStoreDatabaseOption : DatabaseOption, ISqlTDomOption
    {
        public bool Clear
        {
            get;
            set;
        }

        public bool ClearAll
        {
            get;
            set;
        }

        public OptionState OptionState
        {
            get;
            set;
        }

        public IList<QueryStoreOption> Options
        {
            get;
            set;
        }
    }
}