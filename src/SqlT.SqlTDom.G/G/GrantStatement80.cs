////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class GrantStatement80 : SecurityStatementBody80, ISqlTDomStatement
    {
        public bool WithGrantOption
        {
            get;
            set;
        }

        public Identifier AsClause
        {
            get;
            set;
        }
    }
}