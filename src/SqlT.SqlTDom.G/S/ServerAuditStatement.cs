////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ServerAuditStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier AuditName
        {
            get;
            set;
        }

        public AuditTarget AuditTarget
        {
            get;
            set;
        }

        public IList<AuditOption> Options
        {
            get;
            set;
        }

        public BooleanExpression PredicateExpression
        {
            get;
            set;
        }
    }
}