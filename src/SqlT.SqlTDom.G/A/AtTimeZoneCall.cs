////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AtTimeZoneCall : PrimaryExpression, ISqlTDomElement
    {
        public ScalarExpression DateValue
        {
            get;
            set;
        }

        public ScalarExpression TimeZone
        {
            get;
            set;
        }
    }
}