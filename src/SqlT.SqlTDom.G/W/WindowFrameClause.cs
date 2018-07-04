////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WindowFrameClause : TSqlFragment, ISqlTDomElement
    {
        public WindowDelimiter Top
        {
            get;
            set;
        }

        public WindowDelimiter Bottom
        {
            get;
            set;
        }

        public WindowFrameType WindowFrameType
        {
            get;
            set;
        }
    }
}