////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class KillStatement : TSqlStatement, ISqlTDomStatement
    {
        public ScalarExpression Parameter
        {
            get;
            set;
        }

        public bool WithStatusOnly
        {
            get;
            set;
        }
    }
}