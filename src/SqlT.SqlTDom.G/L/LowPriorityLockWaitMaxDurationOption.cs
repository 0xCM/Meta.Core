////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class LowPriorityLockWaitMaxDurationOption : LowPriorityLockWaitOption, ISqlTDomOption
    {
        public Literal MaxDuration
        {
            get;
            set;
        }

        public Nullable<TimeUnit> Unit
        {
            get;
            set;
        }
    }
}