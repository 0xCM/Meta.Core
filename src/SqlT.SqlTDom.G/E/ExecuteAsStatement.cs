////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExecuteAsStatement : TSqlStatement, ISqlTDomStatement
    {
        public bool WithNoRevert
        {
            get;
            set;
        }

        public VariableReference Cookie
        {
            get;
            set;
        }

        public ExecuteContext ExecuteContext
        {
            get;
            set;
        }
    }
}