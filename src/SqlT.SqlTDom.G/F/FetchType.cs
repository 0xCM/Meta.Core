////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FetchType : TSqlFragment, ISqlTDomElement
    {
        public FetchOrientation Orientation
        {
            get;
            set;
        }

        public ScalarExpression RowOffset
        {
            get;
            set;
        }
    }
}