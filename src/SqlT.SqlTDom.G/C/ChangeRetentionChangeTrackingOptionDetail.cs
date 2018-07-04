////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ChangeRetentionChangeTrackingOptionDetail : ChangeTrackingOptionDetail, ISqlTDomElement
    {
        public Literal RetentionPeriod
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