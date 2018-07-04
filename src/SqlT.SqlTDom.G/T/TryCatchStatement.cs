////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TryCatchStatement : TSqlStatement, ISqlTDomStatement
    {
        public StatementList TryStatements
        {
            get;
            set;
        }

        public StatementList CatchStatements
        {
            get;
            set;
        }
    }
}