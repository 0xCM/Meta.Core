////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TargetRecoveryTimeDatabaseOption : DatabaseOption, ISqlTDomOption
    {
        public Literal RecoveryTime
        {
            get;
            set;
        }

        public TimeUnit Unit
        {
            get;
            set;
        }
    }
}