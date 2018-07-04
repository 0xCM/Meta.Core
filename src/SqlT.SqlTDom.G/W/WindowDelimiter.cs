////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WindowDelimiter : TSqlFragment, ISqlTDomElement
    {
        public WindowDelimiterType WindowDelimiterType
        {
            get;
            set;
        }

        public ScalarExpression OffsetValue
        {
            get;
            set;
        }
    }
}