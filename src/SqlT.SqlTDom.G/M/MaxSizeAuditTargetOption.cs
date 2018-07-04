////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MaxSizeAuditTargetOption : AuditTargetOption, ISqlTDomOption
    {
        public bool IsUnlimited
        {
            get;
            set;
        }

        public Literal Size
        {
            get;
            set;
        }

        public MemoryUnit Unit
        {
            get;
            set;
        }
    }
}