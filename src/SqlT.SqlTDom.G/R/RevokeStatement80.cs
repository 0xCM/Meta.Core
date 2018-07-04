////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class RevokeStatement80 : SecurityStatementBody80, ISqlTDomStatement
    {
        public bool GrantOptionFor
        {
            get;
            set;
        }

        public bool CascadeOption
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