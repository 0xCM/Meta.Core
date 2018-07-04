////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class CredentialStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Literal Identity
        {
            get;
            set;
        }

        public Literal Secret
        {
            get;
            set;
        }

        public bool IsDatabaseScoped
        {
            get;
            set;
        }
    }
}