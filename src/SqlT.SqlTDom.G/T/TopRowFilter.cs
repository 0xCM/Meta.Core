////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TopRowFilter : TSqlFragment, ISqlTDomElement
    {
        public ScalarExpression Expression
        {
            get;
            set;
        }

        public bool Percent
        {
            get;
            set;
        }

        public bool WithTies
        {
            get;
            set;
        }
    }
}