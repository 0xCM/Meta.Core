////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SystemVersioningTableOption : TableOption, ISqlTDomOption
    {
        public OptionState OptionState
        {
            get;
            set;
        }

        public OptionState ConsistencyCheckEnabled
        {
            get;
            set;
        }

        public SchemaObjectName HistoryTable
        {
            get;
            set;
        }
    }
}